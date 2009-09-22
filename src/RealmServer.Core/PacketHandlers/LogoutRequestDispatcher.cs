using System;
using Hazzik.Attributes;
using Hazzik.Net;
using Hazzik.Objects;

namespace Hazzik.PacketHandlers {
	[PacketHandlerClass(WMSG.CMSG_LOGOUT_REQUEST)]
	internal class LogoutRequestDispatcher : IPacketDispatcher {
		#region IPacketDispatcher Members

		public void Dispatch(ISession client, IPacket packet) {
			client.Player.StandState = StandStates.Sitting;
			client.SendLogoutResponce();
			client.Player = null;
			client.SendLogoutComplete();
		}

		#endregion
	}
}