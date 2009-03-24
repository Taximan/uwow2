using System;
using System.Collections;
using System.IO;
using Hazzik.Objects;

namespace Hazzik {
	public class ObjectUpdater : IUpdateBlock {
		private readonly WorldObject _obj;
		private readonly BitArray _required;
		private readonly Player _to;
		private bool _changed;
		private bool _isNew = true;
		private BitArray _mask;
		private uint[] _sendedValues;

		public ObjectUpdater(Player to, WorldObject obj) {
			_to = to;
			_obj = obj;
			_required = to.GetRequeredMask(_obj);
			_sendedValues = new uint[_obj.MaxValues];
		}

		#region IUpdateBlock Members

		public bool IsEmpty {
			get {
				if(!_changed) {
					_mask = BuildMask(out _changed);
				}
				return !_changed;
			}
		}

		public void Write(BinaryWriter writer) {
			writer.WritePackGuid(_obj.Guid);
			if(_isNew) {
				writer.Write((byte)_obj.TypeId);
				writer.Write((byte)(_obj != _to ? _obj.UpdateFlag : _obj.UpdateFlag | UpdateFlags.Self));
				_obj.WriteCreateBlock(writer);
				if(_obj.UpdateFlag.Has(UpdateFlags.HighGuid)) {
					writer.Write((uint)0x00);
				}
				if(_obj.UpdateFlag.Has(UpdateFlags.LowGuid)) {
					writer.Write((uint)0x00);
				}
				if(_obj.UpdateFlag.Has(UpdateFlags.TargetGuid)) {
					writer.WritePackGuid(0x00);
				}
				if(_obj.UpdateFlag.Has(UpdateFlags.Transport)) {
					writer.Write((uint)0x00);
				}
				_isNew = false;
			}
			WriteMask(writer);
			for(int i = 0; i < _mask.Length; i++) {
				if(_mask[i]) {
					writer.Write(_sendedValues[i]);
				}
			}
			_changed = false;
		}

		public UpdateType UpdateType {
			get { return !_isNew ? UpdateType.Values : (_obj != _to ? UpdateType.CreateObject : UpdateType.CreateObject2); }
		}

		#endregion

		private void WriteMask(BinaryWriter writer) {
			var length = (byte)GetLengthInDwords(_mask.Length);
			var buffer = new byte[length << 2];
			_mask.CopyTo(buffer, 0);
			writer.Write(length);
			writer.Write(buffer);
		}

		private BitArray BuildMask(out bool changed) {
			changed = false;
			var values = new uint[_obj.MaxValues];
			var mask = new BitArray(Math.Min(_required.Length, values.Length));
			for(int i = 0; i < mask.Length; i++) {
				changed |= mask[i] = _required[i] && _sendedValues[i] != (values[i] = _obj.GetValue(i));
			}
			_sendedValues = values;
			return mask;
		}

		private static int GetLengthInDwords(int bitsCount) {
			return (bitsCount >> 5) + (bitsCount % 32 != 0 ? 1 : 0);
		}
	}
}