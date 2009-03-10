using System;

namespace Hazzik.Objects {
	[Flags]
	public enum GameObjectFlags : ushort {
		InUse = 0x01,
		Locked = 0x02,
		ConditionalInteraction = 0x04,
		Transport = 0x08,
		DoesNotDespawn = 0x20,
		Triggered = 0x40,
	}
}