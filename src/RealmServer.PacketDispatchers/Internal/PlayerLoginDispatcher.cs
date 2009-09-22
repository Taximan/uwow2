using System;
using System.IO;
using Hazzik.Creatures;
using Hazzik.Data;
using Hazzik.Data.Fake.Templates;
using Hazzik.Map;
using Hazzik.Net;
using Hazzik.Objects;
using Hazzik.Objects.Update;

namespace Hazzik.RealmServer.PacketDispatchers.Internal {
	[PacketHandlerClass(WMSG.CMSG_PLAYER_LOGIN)]
	internal class PlayerLoginDispatcher : IPacketDispatcher {
		#region IPacketDispatcher Members

		public void Dispatch(ISession session, IPacket packet) {
			BinaryReader reader = packet.CreateReader();
			ulong guid = reader.ReadUInt64();
			Player player = session.Account.GetPlayer(guid);
			if(null == player) {
				session.SendCharacterLoginFiled();
				return;
			}

			session.Player = player;
			ObjectManager.Add(player);
			Creature creature = Creature.Create(new Creature647());
			creature.NpcFlags = NpcFlags.Banker;
			creature.BaseHealth = 500;
			creature.Health = 500;
			creature.PosX = player.PosX;
			creature.PosY = player.PosY;
			creature.PosZ = player.PosZ;
			ObjectManager.Add(creature);
			GameObject gameObject = GameObject.Create(Repository.GameObjectTemplate.FindById(2489));
			gameObject.PosX = player.PosX;
			gameObject.PosY = player.PosY;
			gameObject.PosZ = player.PosZ;
			ObjectManager.Add(gameObject);
			session.SendLoginVerifyWorld();

			session.SendAccountDataTimes();

			session.SendLoginSetTimeSpeed();
			session.SendSetProficiency(2, -1);
			session.SendSetProficiency(4, -1);
			session.SendSetProficiency(6, -1);
			session.SendInitialSpells();
			var manager = new UpdateManager(player);
			manager.UpdateObjects();

			session.SendTimeSyncReq();

			manager.StartUpdateTimer();
		}

		#endregion
	}
}