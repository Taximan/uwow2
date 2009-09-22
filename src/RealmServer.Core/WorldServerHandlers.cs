using System;
using System.IO;
using System.Linq;
using Hazzik.Attributes;
using Hazzik.Data;
using Hazzik.Map;
using Hazzik.Net;
using Hazzik.Objects;
using Hazzik.Objects.Update;

namespace Hazzik {
	[PacketHandlerClass]
	public static class WorldServerHandlers {
		[WorldPacketHandler(WMSG.CMSG_NAME_QUERY)]
		public static void HandleNameQuery(ISession session, IPacket packet) {
			var reader = packet.CreateReader();
			var guid = reader.ReadUInt64();

			var player = ObjectManager.GetPlayersNear(session.Player).FirstOrDefault(x => x.Guid == guid);

			if(player != null) {
				session.Client.Send(player.GetNameQueryResponcePkt());
			}
		}

		[WorldPacketHandler(WMSG.CMSG_REALM_SPLIT)]
		public static void HandleRealmSplit(ISession session, IPacket packet) {
			var r = packet.CreateReader();
			var unk1 = r.ReadUInt32();

			session.Client.Send(GetRealmSplitPkt(unk1));
		}

		private static IPacket GetRealmSplitPkt(uint unk1) {
			var responce = WorldPacketFactory.Create(WMSG.SMSG_REALM_SPLIT);
			var w = responce.CreateWriter();
			w.Write(unk1);
			//0-normal, 1-split, 2-split pending;
			w.Write(0);
			w.WriteCString(DateTime.Now.AddDays(1).ToShortDateString());
			return responce;
		}

		[WorldPacketHandler(WMSG.CMSG_CHAR_ENUM)]
		public static void HandleCharEnum(ISession session, IPacket packet) {
			session.Client.Send(session.Account.GetCharEnumPkt());
		}

		[WorldPacketHandler(WMSG.CMSG_CHAR_CREATE)]
		public static void HandleCharCreate(ISession client, IPacket packet) {
			var account = client.Account;
			var r = packet.CreateReader();
			var player = new Player {
				Name = r.ReadCString(),
				Race = (Races)r.ReadByte(),
				Classe = (Classes)r.ReadByte(),
				Gender = (GenderType)r.ReadByte(),
				Skin = r.ReadByte(),
				Face = r.ReadByte(),
				HairStyle = r.ReadByte(),
				HairColor = r.ReadByte(),
				FacialHair = r.ReadByte(),
			};
			new FakeCharacterCreateHandler(player).Init();
			account.AddPlayer(player);
			//Repository.Account.Save(account);
			//Repository.Account.SubmitChanges();
			client.Client.Send(Account.GetCharCreatePkt(47));
		}

		[WorldPacketHandler(WMSG.CMSG_PLAYER_LOGIN)]
		public static void HandlePlayerLogin(ISession session, IPacket packet) {
			var reader = packet.CreateReader();
			var guid = reader.ReadUInt64();
			var player = session.Account.GetPlayer(guid);
			if(null == player) {
				session.Client.Send(Account.GetCharacterLoginFiledPkt(0x44));
				return;
			}

			session.Player = player;
			ObjectManager.Add(player);
			//ObjectManager.Add(new Creature(new Creature647()) {
			//   NpcFlags = /*NpcFlags.Gossip | NpcFlags.QuestGiver |*/ NpcFlags.Banker,
			//   BaseHealth = 500,
			//   Health = 500,
			//   PosX = player.PosX,
			//   PosY = player.PosY,
			//   PosZ = player.PosZ,
			//});
			var gameObject = GameObject.Create(Repository.GameObjectTemplate.FindById(2489));
			gameObject.PosX = player.PosX;
			gameObject.PosY = player.PosY;
			gameObject.PosZ = player.PosZ;
			ObjectManager.Add(gameObject);
			session.Client.Send(player.GetLoginVerifyWorldPkt());

			session.Client.Send(Account.GetAccountDataTimesPkt());

			session.Client.Send(GetLoginSetTimeSpeedPkt());
			session.Client.Send(GetProf(2, -1));
			session.Client.Send(GetProf(4, -1));
			session.Client.Send(GetProf(6, -1));
			session.Client.Send(player.GetInitialSpellsPkt());
			var manager = new UpdateManager(player);
			manager.UpdateObjects();

			session.Client.Send(GetTimeSyncReqPkt());

			manager.StartUpdateTimer();
		}

		private static IPacket GetProf(byte type, int bitmask) {
			var packet = WorldPacketFactory.Create(WMSG.SMSG_SET_PROFICIENCY);
			var writer = packet.CreateWriter();
			writer.Write(type);
			writer.Write(bitmask);
			return packet;
		}

		private static IPacket GetTimeSyncReqPkt() {
			return new WorldPacket(WMSG.SMSG_TIME_SYNC_REQ, new byte[4]);
		}

		private static IPacket GetLoginSetTimeSpeedPkt() {
			var result = WorldPacketFactory.Create(WMSG.SMSG_LOGIN_SETTIMESPEED);
			var w = result.CreateWriter();
			w.Write(GetActualTime());
			w.Write(0.01666667F);
			return result;
		}

		[WorldPacketHandler(WMSG.CMSG_SETSHEATHED)]
		public static void HandleSetSheathed(ISession client, IPacket packet) {
			client.Player.Sheath = (SheathType)packet.CreateReader().ReadInt32();
		}

		[WorldPacketHandler(WMSG.CMSG_STANDSTATECHANGE)]
		public static void HandleStandStateChange(ISession client, IPacket packet) {
			client.Player.StandState = (StandStates)packet.CreateReader().ReadByte();
		}

		[WorldPacketHandler(WMSG.CMSG_LOGOUT_REQUEST)]
		public static void HandleLogoutRequest(ISession client, IPacket packet) {
			client.Player.StandState = StandStates.Sitting;
			client.Client.Send(GetLogoutResponcePkt(LogoutResponses.Accepted));
			client.Player = null;
			client.Client.Send(GetLogoutCompletePkt());
		}

		private static IPacket GetLogoutCompletePkt() {
			return WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_COMPLETE);
		}

		[WorldPacketHandler(WMSG.CMSG_LOGOUT_CANCEL)]
		public static void HandleLogoutCancel(ISession client, IPacket packet) {
			client.Player.StandState = StandStates.Standing;
			client.Client.Send(GetLogoutCancelAckPkt());
		}

		private static IPacket GetLogoutCancelAckPkt() {
			return WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_CANCEL_ACK);
		}

		private static IPacket GetLogoutResponcePkt(LogoutResponses error) {
			var result = WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_RESPONSE);
			var writer = result.CreateWriter();
			writer.Write((byte)error);
			writer.Write(0);
			return result;
		}

		public static uint GetActualTime() {
			var time = DateTime.Now;
			var year = time.Year - 2000;
			var month = time.Month - 1;
			var day = time.Day - 1;
			var dayOfWeek = (int)time.DayOfWeek;
			var hour = time.Hour;
			var minute = time.Minute;

			return (uint)(minute | (hour << 0x06) | (dayOfWeek << 0x0B) | (day << 0x0E) | (month << 0x14) | (year << 0x18));
		}
	}
}