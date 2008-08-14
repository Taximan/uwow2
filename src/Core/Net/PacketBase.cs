﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hazzik.Net {
	public class PacketBase : IPacket {
		private Stream _stream;

		protected internal PacketBase(int code, byte[] data) {
			_stream = new MemoryStream(data, false);
			this.Code = code;
		}

		protected internal PacketBase(int code) {
			_stream = new MemoryStream();
			this.Code = code;
		}

		public int Code { get; set; }

		public int Size { get { return (int)_stream.Length; } }

		public Stream GetStream() {
			if(_stream == null) {
				_stream = new MemoryStream();
			}
			return _stream;
		}

		public BinaryReader GetReader() {
			return new BinaryReader(this.GetStream());
		}

		public BinaryWriter GetWriter() {
			return new BinaryWriter(this.GetStream());
		}
	}
}
