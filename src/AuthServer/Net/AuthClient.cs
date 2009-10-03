using System;
using System.IO;
using System.Net.Sockets;

namespace Hazzik.Net {
	public class AuthClient : ClientBase {
		public AuthClient(Socket client) :
			base(client) {
			processor = new AuthPacketProcessor(this);
		}

		public override IPacket ReadPacket() {
			Stream stream = GetStream();
			int code = ReadCode(stream);
			int size = ReadSize(stream, code);
			var buffer = new byte[size];
			stream.Read(buffer, 0, buffer.Length);
			return new AuthPacket((RMSG)code, buffer);
		}

		public override void ReadPacketAsync(Action<IPacket> callback) {
			Stream stream = GetStream();
			int code = ReadCode(stream);
			int size = ReadSize(stream, code);
			var buffer = new byte[size];
			stream.ReadAsync(buffer, 0, buffer.Length, () => callback(new AuthPacket((RMSG)code, buffer)));
		}

		public override void Send(IPacket packet) {
			Stream data = GetStream();
			Stream head = data;

			WriteCode(head, packet);
			WriteSize(head, packet);
			packet.WriteBody(data);
		}

		private static int ReadCode(Stream stream) {
			return stream.ReadByte();
		}

		private static void WriteCode(Stream stream, IPacket packet) {
			stream.WriteByte((byte)packet.Code);
		}

		public static int ReadSize(Stream stream, int code) {
			var reader = new BinaryReader(stream);
			switch((RMSG)code) {
			case RMSG.AUTH_LOGON_CHALLENGE:
			case RMSG.AUTH_LOGON_RECODE_CHALLENGE:
				byte unk = reader.ReadByte();
				return reader.ReadUInt16();
			case RMSG.AUTH_LOGON_PROOF:
				return 0x4A;
			case RMSG.AUTH_LOGON_RECODE_PROOF:
				return 0x39;
			case RMSG.REALM_LIST:
				return 0x04;
			case RMSG.XFER_RESUME:
				return 0x08;
				//case RMSG.XFER_ACCEPT:
				//case RMSG.XFER_CANCEL:
				//default:
				//   return 0x00;
			}
			return 0x00;
		}

		public static void WriteSize(Stream stream, IPacket packet) {
			if((RMSG)packet.Code == RMSG.REALM_LIST || (RMSG)packet.Code == RMSG.XFER_DATA) {
				stream.WriteByte((byte)(packet.Size));
				stream.WriteByte((byte)(packet.Size >> 0x08));
			}
		}
	}
}