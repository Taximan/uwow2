using System;
using Hazzik.Items;

namespace Hazzik.Objects {
	public partial class Container : Item, IContainer {
		private readonly IInventory _inventory;

		public Container(ItemTemplate template)
			: base(template) {
			Type |= ObjectTypes.Container;
			NumSlots = (uint)template.ContainerSlots;
			_inventory = new ContainerInventory(this, (uint)template.ContainerSlots);
		}

		public override ObjectTypeId TypeId {
			get { return ObjectTypeId.Container; }
		}

		#region IContainer Members

		public IInventory Inventory {
			get { return _inventory; }
		}

		#endregion
	}
}