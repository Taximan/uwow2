using System;
using System.IO;
using Hazzik.Creatures;
using Hazzik.GameObjects;
using Hazzik.Gossip;
using Hazzik.Items;
using Hazzik.Map;
using Hazzik.Objects;
using Hazzik.Objects.Update;

namespace Hazzik.Net {
	public class Session : ISession {
		private readonly IWorldClient _client;
		private Player _player;

		public Session(IWorldClient sender) {
			_client = sender;
		}

		#region ISession Members

		public Player Player {
			get { return _player; }
			set {
				if(null == value) {
					_player.Session = null;
					_player = value;
				}
				else {
					_player = value;
					_player.Session = this;
				}
			}
		}

		public Account Account { get; set; }

		public IWorldClient Client {
			get { return _client; }
		}

		public void SendHeartBeat() {
			IPacket packet = WorldPacketFactory.Create(WMSG.MSG_MOVE_HEARTBEAT);
			BinaryWriter writer = packet.CreateWriter();
			writer.WritePackGuid(Player.Guid);
			Player.MovementInfo.Write(writer);
			SendNear(Player, packet);
		}

		public void SendInitialSpells() {
			_client.Send(GetInitialSpellsPkt());
		}

		public void SendNameQueryResponce(Player player) {
			_client.Send(GetNameQueryResponcePkt(player));
		}

		public void SendRealmSplitPkt(uint unk1) {
			_client.Send(GetRealmSplitPkt(unk1));
		}

		public void SendCharEnum() {
			_client.Send(Account.GetCharEnumPkt());
		}

		public void SendCharCreate() {
			_client.Send(GetCharCreatePkt(47));
		}

		public void SendCharacterLoginFiled() {
			_client.Send(GetCharacterLoginFiledPkt(0x44));
		}

		public void SendLoginVerifyWorld() {
			_client.Send(GetLoginVerifyWorldPkt(Player));
		}

		public void SendAccountDataTimes() {
			_client.Send(GetAccountDataTimesPkt());
		}

		public void SendLoginSetTimeSpeed() {
			_client.Send(GetLoginSetTimeSpeedPkt());
		}

		public void SendTimeSyncReq() {
			_client.Send(GetTimeSyncReqPkt());
		}

		public void SendLogoutComplete() {
			_client.Send(GetLogoutCompletePkt());
		}

		public void SendLogoutResponce() {
			_client.Send(GetLogoutResponcePkt(LogoutResponses.Accepted));
		}

		public void SendLogoutCancelAck() {
			_client.Send(GetLogoutCancelAckPkt());
		}

		public void SendShowBank(ulong guid) {
			_client.Send(GetShowBankPkt(guid));
		}

		public void SendDestroy(WorldObject item) {
			_client.Send(GetDestroyObjectPkt(item));
		}

		public void SendCreatureQueryResponce(CreatureTemplate creature) {
			_client.Send(GetCreatureQueryResponse(creature));
		}

		public void SendGameObjectQueryResponce(GameObjectTemplate template) {
			_client.Send(GetGameObjectQueryResponcePkt(template));
		}

		public void SendItemQuerySingleResponse(ItemTemplate template) {
			_client.Send(GetItemQuerySingleResponsePkt(template));
		}

		public void SendSetProficiency(byte type, int bitmask) {
			_client.Send(GetSetProficiencyPkt(type, bitmask));
		}

		public void SendNpcTextUpdate(NpcTexts text) {
			_client.Send(GetNpcTextUpdatePkt(text));
		}

		public void SendStandstateUpdate() {
			_client.Send(new WorldPacket(WMSG.SMSG_STANDSTATE_UPDATE, new[] { (byte)_player.StandState }));
		}

		public void SendGossipMessage(ulong targetGuid, GossipMessage message) {
			_client.Send(GetGossipMessagePkt(targetGuid, message));
		}

		public void SendUpdateObjects(IPacketBuilder builder) {
			if(!builder.IsEmpty) {
				_client.Send(builder.Build());
			}
		}

		#endregion

		public static void SendNear(Positioned me, IPacket responce) {
			foreach(Player player in ObjectManager.GetPlayersNear(me)) {
				if(player.Session != null) {
					player.Session.Client.Send(responce);
				}
			}
		}

		public static void SendNearExceptMe(Positioned me, IPacket responce) {
			foreach(Player player in ObjectManager.GetPlayersNear(me)) {
				if(player != me && player.Session != null) {
					player.Session.Client.Send(responce);
				}
			}
		}

		private IPacket GetInitialSpellsPkt() {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_INITIAL_SPELLS);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write((byte)0);
			writer.Write((ushort)Player.Spells.Count);
			foreach(int i in Player.Spells) {
				writer.Write(i);
			}
			writer.Write((ushort)0);
			return packet;
		}

		private static IPacket GetNameQueryResponcePkt(Player player) {
			IPacket result = WorldPacketFactory.Create(WMSG.SMSG_NAME_QUERY_RESPONSE);
			BinaryWriter writer = result.CreateWriter();
			writer.WritePackGuid(player.Guid);
			writer.Write((byte)0); // this is a type, ranging from 0-3
			writer.WriteCString(player.Name);
			writer.WriteCString("");
			writer.Write((byte)player.Race);
			writer.Write((byte)player.Gender);
			writer.Write((byte)player.Classe);
			writer.Write(true);
			writer.WriteCString(player.Name);
			writer.WriteCString(player.Name);
			writer.WriteCString(player.Name);
			writer.WriteCString(player.Name);
			return result;
		}

		private static IPacket GetRealmSplitPkt(uint unk1) {
			IPacket responce = WorldPacketFactory.Create(WMSG.SMSG_REALM_SPLIT);
			BinaryWriter w = responce.CreateWriter();
			w.Write(unk1);
			//0-normal, 1-split, 2-split pending;
			w.Write(0);
			w.WriteCString(DateTime.Now.AddDays(1).ToShortDateString());
			return responce;
		}

		private static IPacket GetCharCreatePkt(int error) {
			return new WorldPacket(WMSG.SMSG_CHAR_CREATE, new[] { (byte)error });
		}

		private static IPacket GetCharacterLoginFiledPkt(int error) {
			return new WorldPacket(WMSG.SMSG_CHARACTER_LOGIN_FAILED, new[] { (byte)error });
		}

		private static IPacket GetLoginVerifyWorldPkt(Player player) {
			IPacket result = WorldPacketFactory.Create(WMSG.SMSG_LOGIN_VERIFY_WORLD);
			BinaryWriter writer = result.CreateWriter();
			writer.Write(player.MapId);
			writer.Write(player.PosX);
			writer.Write(player.PosY);
			writer.Write(player.PosZ);
			writer.Write(player.Facing);
			return result;
		}

		private static IPacket GetAccountDataTimesPkt() {
			return new WorldPacket(WMSG.SMSG_ACCOUNT_DATA_TIMES, new byte[0x80]);
		}

		private static IPacket GetTimeSyncReqPkt() {
			return new WorldPacket(WMSG.SMSG_TIME_SYNC_REQ, new byte[4]);
		}

		private static IPacket GetLogoutCompletePkt() {
			return WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_COMPLETE);
		}

		private static IPacket GetLogoutResponcePkt(LogoutResponses error) {
			IPacket result = WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_RESPONSE);
			BinaryWriter writer = result.CreateWriter();
			writer.Write((byte)error);
			writer.Write(0);
			return result;
		}

		private static IPacket GetLogoutCancelAckPkt() {
			return WorldPacketFactory.Create(WMSG.SMSG_LOGOUT_CANCEL_ACK);
		}

		private static IPacket GetShowBankPkt(ulong guid) {
			IPacket responce = WorldPacketFactory.Create(WMSG.SMSG_SHOW_BANK);
			BinaryWriter writer = responce.CreateWriter();
			writer.Write(guid);
			return responce;
		}

		private static IPacket GetDestroyObjectPkt(WorldObject obj) {
			IPacket result = WorldPacketFactory.Create(WMSG.SMSG_DESTROY_OBJECT);
			BinaryWriter writer = result.CreateWriter();
			writer.Write(obj.Guid);
			return result;
		}

		private static IPacket GetCreatureQueryResponse(CreatureTemplate template) {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_CREATURE_QUERY_RESPONSE);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write(template.Id);
			writer.WriteCString(template.Name);
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString(template.GuildName);
			writer.Write((uint)template.Flags);
			writer.Write((uint)template.Type);
			writer.Write((uint)template.Family);
			writer.Write((uint)template.Rank);
			writer.Write(0);
			writer.Write(0); // SpellGroupId
			writer.Write(template.DisplayId);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0);
			writer.Write(1f);
			writer.Write(1f);
			writer.Write((byte)0);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0); // id from CreatureMovement.dbc
			return packet;
		}

		private static IPacket GetGameObjectQueryResponcePkt(GameObjectTemplate template) {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_GAMEOBJECT_QUERY_RESPONSE);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write(template.Id);
			writer.Write((uint)template.Type);
			writer.Write(template.DisplayId);
			writer.WriteCString(template.Name);
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString("");
			writer.WriteCString("");
			for(int i = 0; i < template.Fields.Length; i++) {
				writer.Write(template.Fields[i]);
			}
			writer.Write(template.ScaleX);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0);
			writer.Write(0);
			return packet;
		}

		private static IPacket GetItemQuerySingleResponsePkt(ItemTemplate template) {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_ITEM_QUERY_SINGLE_RESPONSE);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write(template.Id);
			writer.Write(template.ObjectClass);
			writer.Write(template.SubClass);
			writer.Write(template.Unk1);
			writer.WriteCString(template.Name);
			writer.WriteCString(template.Name2);
			writer.WriteCString(template.Name3);
			writer.WriteCString(template.Name4);
			writer.Write(template.DisplayId);
			writer.Write(template.Quality);
			writer.Write(template.Flags);
			writer.Write(template.BuyPrice);
			writer.Write(template.SellPrice);
			writer.Write((int)template.InventoryType);
			writer.Write(template.RequiredClassMask);
			writer.Write(template.RequiredRaceMask);
			writer.Write(template.Level);
			writer.Write(template.RequiredLevel);
			writer.Write(template.RequiredSkill);
			writer.Write(template.RequiredSkillValue);
			writer.Write(template.RequiredSpell);
			writer.Write(template.RequiredPvPRank);
			writer.Write(template.RequiredPvPMedal);
			writer.Write(template.RequiredFaction);
			writer.Write(template.RequiredFactionStanding);
			writer.Write(template.UniqueCount);
			writer.Write(template.MaxAmount);
			writer.Write(template.ContainerSlots);

			writer.Write(10);
			for(int i = 0; i < 10; i++) {
				writer.Write(template.bonuses[i].Type);
				writer.Write(template.bonuses[i].Value);
			}

			writer.Write(0); // NEW 3.0.2 ScalingStatDistribution.dbc 
			writer.Write(0); // NEW 3.0.2 ScalingStatFlags

			for(int i = 0; i < 2; i++) {
				writer.Write(template.damages[i].Min);
				writer.Write(template.damages[i].Max);
				writer.Write(template.damages[i].School);
			}

			for(int i = 0; i < 7; i++) {
				writer.Write(template.Resistance[i]);
			}

			writer.Write(template.AttackTime); // 
			writer.Write(template.ProjectileType);
			writer.Write(template.RangeModifier);

			for(int i = 0; i < 5; i++) {
				writer.Write(template.spells[i].Id);
				writer.Write(template.spells[i].Trigger);
				writer.Write(template.spells[i].Charges);
				writer.Write(template.spells[i].Cooldown);
				writer.Write(template.spells[i].CategoryId);
				writer.Write(template.spells[i].CategoryCooldown);
			}

			writer.Write(template.BondType);
			writer.WriteCString(template.Description);
			writer.Write(template.PageTextId);
			writer.Write(template.PaeCount);
			writer.Write(template.PageMaterial);
			writer.Write(template.QuestId);
			writer.Write(template.LockId);
			writer.Write(template.Material);
			writer.Write(template.SheathType);
			writer.Write(template.RandomPropertiesId);
			writer.Write(template.RandomSuffixId);
			writer.Write(template.BlockValue);
			writer.Write(template.SetId);
			writer.Write(template.MaxDurability);
			writer.Write(template.ZoneId);
			writer.Write(template.MapId);
			writer.Write(template.BagFamily);
			writer.Write(template.TotemCategory);

			for(int i = 0; i < 3; i++) {
				writer.Write(template.sockets[i].Color);
				writer.Write(template.sockets[i].Content);
			}

			writer.Write(template.SocketBonusEnchantId);
			writer.Write(template.GemPropertiesId);
			writer.Write(template.RequiredDisenchantingLevel);
			writer.Write(template.ArmorModifier);
			writer.Write(0);
			writer.Write(0);
			return packet;
		}

		private static IPacket GetSetProficiencyPkt(byte type, int bitmask) {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_SET_PROFICIENCY);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write(type);
			writer.Write(bitmask);
			return packet;
		}

		private static IPacket GetLoginSetTimeSpeedPkt() {
			IPacket result = WorldPacketFactory.Create(WMSG.SMSG_LOGIN_SETTIMESPEED);
			BinaryWriter w = result.CreateWriter();
			w.Write(WorldServerHandlers.GetActualTime());
			w.Write(0.01666667F);
			return result;
		}

		private static IPacket GetNpcTextUpdatePkt(NpcTexts texts) {
			IPacket responce = WorldPacketFactory.Create(WMSG.SMSG_NPC_TEXT_UPDATE);
			BinaryWriter writer = responce.CreateWriter();
			writer.Write(texts.Id);
			for(int i = 0; i < 8; i++) {
				NpcText text = texts.Texts[i];
				writer.Write(text.Probability);
				writer.WriteCString(text.Text0);
				writer.WriteCString(text.Text1);
				writer.Write(text.Language);
				for(int j = 0; (j < 3); j++) {
					writer.Write(text.Emote[j, 0]);
					writer.Write(text.Emote[j, 1]);
				}
			}
			return responce;
		}

		private static IPacket GetGossipMessagePkt(ulong guid, GossipMessage gossipMessage) {
			IPacket packet = WorldPacketFactory.Create(WMSG.SMSG_GOSSIP_MESSAGE);
			BinaryWriter writer = packet.CreateWriter();
			writer.Write(guid);
			writer.Write(0);
			writer.Write(gossipMessage.TextId);
			if((gossipMessage.GossipMenu != null) && (gossipMessage.GossipMenu.Count > 0)) {
				writer.Write(gossipMessage.GossipMenu.Count);
				foreach(GossipMenuItem menuItem in gossipMessage.GossipMenu) {
					writer.Write(menuItem.MenuId);
					writer.Write((byte)menuItem.Icon);
					writer.Write((byte)(menuItem.InputBox ? 1 : 0));
					writer.Write(menuItem.Cost);
					writer.WriteCString(menuItem.Text);
					writer.WriteCString(menuItem.AcceptText);
				}
			}
			else {
				writer.Write(0);
			}

			if((gossipMessage.QuestsMenu != null) && (gossipMessage.QuestsMenu.Count > 0)) {
				writer.Write(gossipMessage.QuestsMenu.Count);
				foreach(QuestsMenuItem menuItem in gossipMessage.QuestsMenu) {
					writer.Write(menuItem.Id);
					writer.Write(menuItem.Icon);
					writer.Write((uint)0);
					writer.Write(menuItem.Text);
				}
			}
			else {
				writer.Write(0);
			}
			return packet;
		}
	}
}