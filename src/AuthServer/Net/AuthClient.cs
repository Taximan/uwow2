﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Hazzik.Helper;
using Hazzik.Net;

namespace Hazzik.Net {

	#region stuff

	public enum eAuthResults {
		REALM_AUTH_SUCCESS = 0,
		REALM_AUTH_FAILURE = 0x01,                                ///< Unable to connect
		REALM_AUTH_UNKNOWN1 = 0x02,                               ///< Unable to connect
		REALM_AUTH_ACCOUNT_BANNED = 0x03,                         ///< This <game> account has been closed and is no longer available for use. Please go to <site>/banned.html for further information.
		REALM_AUTH_NO_MATCH = 0x04,                               ///< The information you have entered is not valid. Please check the spelling of the account name and password. If you need help in retrieving a lost or stolen password, see <site> for more information
		REALM_AUTH_UNKNOWN2 = 0x05,                               ///< The information you have entered is not valid. Please check the spelling of the account name and password. If you need help in retrieving a lost or stolen password, see <site> for more information
		REALM_AUTH_ACCOUNT_IN_USE = 0x06,                         ///< This account is already logged into <game>. Please check the spelling and try again.
		REALM_AUTH_PREPAID_TIME_LIMIT = 0x07,                     ///< You have used up your prepaid time for this account. Please purchase more to continue playing
		REALM_AUTH_SERVER_FULL = 0x08,                            ///< Could not log in to <game> at this time. Please try again later.
		REALM_AUTH_WRONG_BUILD_NUMBER = 0x09,                     ///< Unable to validate game version. This may be caused by file corruption or interference of another program. Please visit <site> for more information and possible solutions to this issue.
		REALM_AUTH_UPDATE_CLIENT = 0x0a,                          ///< Downloading
		REALM_AUTH_UNKNOWN3 = 0x0b,                               ///< Unable to connect
		REALM_AUTH_ACCOUNT_FREEZED = 0x0c,                        ///< This <game> account has been temporarily suspended. Please go to <site>/banned.html for further information
		REALM_AUTH_UNKNOWN4 = 0x0d,                               ///< Unable to connect
		REALM_AUTH_UNKNOWN5 = 0x0e,                               ///< Connected.
		REALM_AUTH_PARENTAL_CONTROL = 0x0f                        ///< Access to this account has been blocked by parental controls. Your settings may be changed in your account preferences at <site>
	};

	#endregion

	public class AuthClient : ClientBase {

		static BigInteger bi_N = new BigInteger("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7", 16);
		static BigInteger bi_g = 7;
		static BigInteger bi_k = 3;
		static MD5 md5 = MD5.Create();
		static SHA1 sha1 = SHA1.Create();

		private BigInteger bi_b = BigInteger.genPseudoPrime(160, 5, Utility.seed2);
		private BigInteger bi_v;
		private BigInteger bi_B;
		private BigInteger bi_s = BigInteger.genPseudoPrime(256, 5, Utility.seed2);
		private Account _account;

		public AuthClient(Socket client) :
			base(client) {
			_serverList.Add(new ServerInfo {
				Type = 0,
				Locked = 0,
				Status = 0,
				Name = "TestRealm",
				Address = "127.0.0.1:3725",
				CharactersCount = 1,
				Language = (byte)8,
				Population = 1,
				Unk = 0
			});
			Start();
		}

		public override void ProcessData(IPacket packet) {
			using(var reader = packet.GetReader()) {
				var code = (RMSG)packet.Code;

				switch(code) {
				case (RMSG)0:
				case (RMSG)2:
					HandleLogonChallenge(reader);
					break;

				case (RMSG)1:
				case (RMSG)3:
					HandleLogonProof(reader);
					break;

				case (RMSG)4:
					break;

				case (RMSG)0x10:
					HandleRealmList(reader);
					break;

				case (RMSG)0x32:
					HandleXferAccept(reader);
					break;

				case (RMSG)0x33:
					HandleXferResume(reader);
					break;

				case (RMSG)0x34:
					HandleXferCancel(reader);
					break;

				default:
					Console.WriteLine("Receive unknown command {0}", code);
					break;
				}
			}
		}

		private List<ServerInfo> _serverList = new List<ServerInfo>();

		private bool _canSendPatch = true;
		private byte[] patchAvailable {
			get {
				using(var s = (Stream)new FileStream("wow-patch.mpq", FileMode.OpenOrCreate)) {
					MD5 md5 = new MD5CryptoServiceProvider();

					using(var w = new BinaryWriter(new MemoryStream())) {
						w.Write((byte)RMSG.XFER_INITIATE); // send patch :)
						w.Write("Patch");
						w.Write(s.Length);
						w.Write(md5.ComputeHash(s));
						return (w.BaseStream as MemoryStream).ToArray();
					}
				}
			}
		}

		private void sendPatch(string filename, long offset) {
			Thread th = new Thread(ThreadedSend);
			th.IsBackground = true;
			th.Start(new PatchInfo { FileName = filename, Offset = offset });
		}
		struct PatchInfo {
			public string FileName;
			public long Offset;
		}
		private void ThreadedSend(object state) {
			var pinfo = (PatchInfo)state;
			try {
				using(var s = (Stream)new FileStream(pinfo.FileName, FileMode.OpenOrCreate)) {
					byte[] buff = new byte[1503];
					s.Seek(pinfo.Offset, SeekOrigin.Begin);
					while(_canSendPatch && s.Position < s.Length) {
						var p = new AuthPacket(RMSG.XFER_DATA);
						var w = p.GetWriter();
						var n = s.Read(buff, 0, 1500);
						w.Write(buff, 0, n);
						this.WritePacket(p);
					}
				}
			} catch {
			}
		}

		ClientInfo _clientInfo;
		public void HandleLogonChallenge(BinaryReader gr) {
			var tag = gr.ReadCString();
			var verMajor = (int)gr.ReadByte();
			var verMinor = (int)gr.ReadByte();
			var verBuild = (int)gr.ReadByte();
			var verRevis = (int)gr.ReadUInt16();
			var platform = gr.ReadCString();
			var os = gr.ReadCString();
			var locale = Encoding.UTF8.GetString(gr.ReadBytes(4).Reverse());
			var timezone = gr.ReadInt32();
			var ip = new IPAddress(gr.ReadBytes(4));
			var accountName = gr.ReadString();

			_clientInfo = new ClientInfo {
				VersionInfo = new VersionInfo {
					ClientTag = tag,
					Version = new Version(verMajor, verMinor, verBuild, verRevis),
					Platform = platform,
					OS = os,
					Locale = locale,
				},
				TimeZone = timezone,
				IP = ip,
				AccountName = accountName,
			};

			_account = AccountManager.Instance.GetByName(accountName);
			if(_account == null) {
				_account = AccountManager.Instance.Create(accountName);
				AccountManager.Instance.SetPassword(_account, accountName);
				AccountManager.Instance.Save(_account);
				AccountManager.Instance.SubmitChanges();
			}

			bi_s = new BigInteger(_account.PasswordSalt.Reverse());
			bi_v = new BigInteger(_account.PasswordVerifier.Reverse());
			bi_B = (bi_v * bi_k + bi_g.modPow(bi_b, bi_N)) % bi_N;

			#region sending reply to client
			var p = new AuthPacket((int)RMSG.AUTH_LOGON_CHALLENGE);
			var w = p.GetWriter();
			{
				w.Write((byte)0);
				w.Write((byte)0);
				w.Write(bi_B.getBytes().Reverse());
				w.Write((byte)1);
				w.Write(bi_g.getBytes().Reverse());
				w.Write((byte)32);
				w.Write(bi_N.getBytes().Reverse());
				w.Write(bi_s.getBytes().Reverse());
				w.Write(new byte[16]);
				w.Write((byte)0);
			}
			this.WritePacket(p);
			#endregion
		}

		public void HandleLogonProof(BinaryReader gr) {

			BigInteger bi_A = new BigInteger(gr.ReadBytes(32).Reverse());
			BigInteger bi_M1 = new BigInteger(gr.ReadBytes(20).Reverse());
			Console.WriteLine(bi_A.ToHexString());
			Console.WriteLine(bi_M1.ToHexString());

			byte[] u = sha1.ComputeHash(Utility.Concat(bi_A.getBytes().Reverse(), bi_B.getBytes().Reverse()));
			BigInteger bi_u = new BigInteger(u.Reverse());

			BigInteger bi_Temp2 = (bi_A * bi_v.modPow(bi_u, bi_N)) % bi_N;			// v^u
			BigInteger bi_S = bi_Temp2.modPow(bi_b, bi_N);	// (Av^u)^b
			Console.WriteLine(bi_S.ToHexString());
			byte[] S = bi_S.getBytes().Reverse();
			byte[] S1 = new byte[16];
			byte[] S2 = new byte[16];

			for(int i = 0; i < 16; i++) {
				S1[i] = S[i * 2];
				S2[i] = S[i * 2 + 1];
			}

			byte[] SS_Hash = new byte[40];
			byte[] S1_Hash = sha1.ComputeHash(S1);
			byte[] S2_Hash = sha1.ComputeHash(S2);
			for(int i = 0; i < 20; i++) {
				SS_Hash[i * 2] = S1_Hash[i];
				SS_Hash[i * 2 + 1] = S2_Hash[i];
			}

			_account.SessionKey = (byte[])SS_Hash.Clone();
			AccountManager.Instance.SubmitChanges();

			byte[] N_Hash = sha1.ComputeHash(bi_N.getBytes().Reverse());
			byte[] G_Hash = sha1.ComputeHash(bi_g.getBytes().Reverse());
			for(int i = 0; (i < 20); i++) {
				N_Hash[i] ^= G_Hash[i];
			}

			byte[] UserHash = sha1.ComputeHash(Encoding.UTF8.GetBytes(_clientInfo.AccountName));

			byte[] Temp = Utility.Concat(N_Hash, UserHash);
			Temp = Utility.Concat(Temp, bi_s.getBytes().Reverse());
			Temp = Utility.Concat(Temp, bi_A.getBytes().Reverse());
			Temp = Utility.Concat(Temp, bi_B.getBytes().Reverse());
			Temp = Utility.Concat(Temp, SS_Hash);

			BigInteger bi_M1Temp = new BigInteger(sha1.ComputeHash(Temp).Reverse());
			if(bi_M1Temp != bi_M1) {
				var p = new AuthPacket(RMSG.AUTH_LOGON_PROOF);
				var w = p.GetWriter();
				w.Write((byte)4);
				w.Write((byte)3);
				w.Write((byte)0);

				this.WritePacket(p);
				return;
			}

			Temp = Utility.Concat(bi_A.getBytes().Reverse(), bi_M1Temp.getBytes().Reverse());
			Temp = Utility.Concat(Temp, SS_Hash);
			byte[] M2 = sha1.ComputeHash(Temp);

			#region Sending reply to client
			{
				var p = new AuthPacket(RMSG.AUTH_LOGON_PROOF);
				var w = p.GetWriter();
				w.Write((byte)0);
				w.Write(M2);
				w.Write((ushort)0);
				w.Write((uint)0);
				w.Write((uint)0);
				this.WritePacket(p);
			}
			#endregion
		}

		public void HandleRealmList(BinaryReader gr) {
			var p = new AuthPacket(RMSG.REALM_LIST);
			var w = p.GetWriter();
			{
				w.Write(1);
				w.Write((ushort)_serverList.Count);
				foreach(var info in _serverList) {
					/*
					 * 0 = normal
					 * 1 = pvp
					 * 6 = rp
					 * 8 = pvprp
					 */
					w.Write(info.Type);
					/*
					 * 1 = locked
					 */
					w.Write(info.Locked);
					/*
					 * 0 = green realmname
					 * 1 = red realmname
					 * 2 = offline

					 * 32 = recomended(blue)
					 * 64 = recomended(green)
					 * 128 = full(red)
					 */
					w.Write(info.Status);
					w.WriteCString(info.Name);
					w.WriteCString(info.Address);
					w.Write(info.Population);
					w.Write(info.CharactersCount);
					w.Write(info.Language);
					w.Write(info.Unk);
				}
				w.Write((ushort)2);
			}
			this.WritePacket(p);
		}

		public void HandleXferAccept(BinaryReader gr) {
			sendPatch("wow-patch.mpq", 0);
		}

		public void HandleXferResume(BinaryReader gr) {
			sendPatch("wow-patch.mpq", gr.ReadInt64());
		}

		public void HandleXferCancel(BinaryReader gr) {
			_canSendPatch = false;
		}

		public override IPacket ReadPacket() {
			using(var reader = new BinaryReader(this.GetStream())) {
				var code = (RMSG)reader.ReadByte();
				var size = 0;
				switch(code) {
				case RMSG.AUTH_LOGON_CHALLENGE:
				case RMSG.AUTH_LOGON_RECODE_CHALLENGE:
					var unk = reader.ReadByte();
					size = reader.ReadUInt16();
					break;
				case RMSG.AUTH_LOGON_PROOF:
					size = 0x4A;
					break;
				case RMSG.AUTH_LOGON_RECODE_PROOF:
					size = 0x39;
					break;
				case RMSG.REALM_LIST:
					size = 0x04;
					break;
				case RMSG.XFER_RESUME:
					size = 0x08;
					break;
				case RMSG.XFER_ACCEPT:
				case RMSG.XFER_CANCEL:
				default:
					size = 0x00;
					break;
				}
				return new AuthPacket(code, reader.ReadBytes(size));
			}
		}

		public override void WritePacket(IPacket packet) {
			var data = this.GetStream();
			var head = new BinaryWriter(data);

			head.Write((byte)packet.Code);
			if((RMSG)packet.Code == RMSG.REALM_LIST || (RMSG)packet.Code == RMSG.XFER_DATA) {
				head.Write((ushort)packet.Size);
			}

			var buff = new byte[1024];
			var bytesRead = 0;
			var packetStream = packet.GetStream();
			packetStream.Seek(0, SeekOrigin.Begin);
			while((bytesRead = packetStream.Read(buff, 0, 1024)) > 0) {
				data.Write(buff, 0, bytesRead);
			}
		}
	}
}
