using System;
using System.IO;
using System.Net.Sockets;

namespace Hazzik.Net {
	public abstract class ClientBase : ISession {
		protected Socket _socket;
		protected IPacketProcessor _processor;
		private Stream _stream;

		protected ClientBase(Socket socket) {
			_socket = socket;
		}

		public abstract IPacket ReadPacket();
		public abstract void Send(IPacket packet);

		public virtual void Start() {
			try {
				ReadPacketAsync(packet => {
				                	_processor.Process(packet);
				                	Start();
				                });
			}
			catch(SocketException) {
			}
			catch(Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
			//_socket.Close();
		}

		public virtual Stream GetStream() {
			//if(_stream == null) {
			_stream = new NetworkStream(_socket, false);
			//}
			return _stream;
		}

		public abstract void ReadPacketAsync(Action<IPacket> func);

		protected void SetProcessor(IPacketProcessor processor) {
			_processor = processor;
		}
	}
}