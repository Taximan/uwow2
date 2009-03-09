﻿using System;
using System.IO;
using Hazzik.Attributes;
using Hazzik.Map;
using Hazzik.Net;
using Hazzik.Objects;

namespace Hazzik.PacketHandlers {
	[PacketHandlerClass]
	public class MoveHandlers {
		[WorldPacketHandler(WMSG.MSG_MOVE_START_FORWARD)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_BACKWARD)]
		[WorldPacketHandler(WMSG.MSG_MOVE_STOP)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_STRAFE_LEFT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_STRAFE_RIGHT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_STOP_STRAFE)]
		[WorldPacketHandler(WMSG.MSG_MOVE_JUMP)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_TURN_LEFT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_TURN_RIGHT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_STOP_TURN)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_PITCH_UP)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_PITCH_DOWN)]
		[WorldPacketHandler(WMSG.MSG_MOVE_STOP_PITCH)]
		[WorldPacketHandler(WMSG.MSG_MOVE_SET_RUN_MODE)]
		[WorldPacketHandler(WMSG.MSG_MOVE_SET_WALK_MODE)]
		[WorldPacketHandler(WMSG.MSG_MOVE_START_SWIM)]
		[WorldPacketHandler(WMSG.MSG_MOVE_STOP_SWIM)]
		[WorldPacketHandler(WMSG.MSG_MOVE_SET_FACING)]
		[WorldPacketHandler(WMSG.MSG_MOVE_SET_PITCH)]
		[WorldPacketHandler(WMSG.MSG_MOVE_ROOT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_UNROOT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_HEARTBEAT)]
		[WorldPacketHandler(WMSG.MSG_MOVE_KNOCK_BACK)]
		[WorldPacketHandler(WMSG.MSG_MOVE_HOVER)]
		public static void HandleMSG_MOVE_(ClientBase client, IPacket packet) {
			var me = ((WorldClient)client).Player;
			var responce = GetMoveResponce(packet, me.Guid);
			foreach(var player in ObjectManager.GetPlayersNear(me)) {
				if(player != me) {
					player.Client.Send(responce);
				}
			}
			var reader = packet.CreateReader();
			reader.BaseStream.Seek(0, SeekOrigin.Begin);
			me.MovementInfo.Read(reader);
		}

		private static IPacket GetMoveResponce(IPacket packet, ulong guid) {
			var responce = new WorldPacket((WMSG)packet.Code);
			var w = responce.CreateWriter();
			w.WritePackGuid(guid);
			w.Write(packet.CreateReader().ReadBytes(packet.Size));
			return responce;
		}
	}
}
