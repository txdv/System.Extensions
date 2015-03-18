using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace System
{
	public static class SocketExtensions
	{
		#region Connect/Disconnect

		public static Task ConnectAsync(this Socket socket, EndPoint endPoint)
		{
			return Task.Factory.FromAsync(
				socket.BeginConnect(endPoint, null, null),
				socket.EndConnect
			);
		}

		public static Task DisconnectAsync(this Socket socket, bool reuseSocket)
		{
			return Task.Factory.FromAsync(
				socket.BeginDisconnect(reuseSocket, null, null),
				socket.EndDisconnect
			);
		}

		#endregion

		#region Send

		public static void Send(this Socket socket, ArraySegment<byte> segment, SocketFlags socketFlags)
		{
			socket.Send(segment.Array, segment.Offset, segment.Count, socketFlags);
		}

		public static void Send(this Socket socket, ArraySegment<byte> segment)
		{
			socket.Send(segment.Array, segment.Offset, segment.Count, SocketFlags.None);
		}

		public static void Send(this Socket socket, byte[] buffer, int offset, int count)
		{
			socket.Send(buffer.ToArraySegment(offset, count));
		}

		public static Task<int> SendAsync(this Socket socket, ArraySegment<byte> segment, SocketFlags socketFlags)
		{
			return Task<int>.Factory.FromAsync(
				socket.BeginSend(segment.Array, segment.Offset, segment.Count, socketFlags, null, null),
				socket.EndSend
			);
		}

		public static Task<int> SendAsync(this Socket socket, ArraySegment<byte> segment)
		{
			return SendAsync(socket, segment, SocketFlags.None);
		}

		public static Task<int> SendAsync(this Socket socket, byte[] buffer)
		{
			return SendAsync(socket, buffer.ToArraySegment());
		}

		public static Task<int> SendAsync(this Socket socket, byte[] buffer, int offset, int count)
		{
			return SendAsync(socket, buffer.ToArraySegment(offset, count));
		}

		#endregion

		#region Receive

		public static int Receive(this Socket socket, ArraySegment<byte> segment, SocketFlags socketFlags)
		{
			return socket.Receive(segment.Array, segment.Offset, segment.Count, socketFlags);
		}

		public static int Receive(this Socket socket, ArraySegment<byte> segment)
		{
			return socket.Receive(segment, SocketFlags.None);
		}

		public static ArraySegment<byte> ReceiveArraySegment(this Socket socket, ArraySegment<byte> segment)
		{
			return segment.Take(socket.Receive(segment));
		}

		public static ArraySegment<byte> ReceiveArraySegment(this Socket socket, byte[] buffer)
		{
			return socket.ReceiveArraySegment(buffer.ToArraySegment());
		}

		public static Task<int> ReceiveAsync(this Socket socket, byte[] buffer, int offset, int count, SocketFlags socketFlags)
		{
			return Task<int>.Factory.FromAsync(
				socket.BeginReceive(buffer, offset, count, socketFlags, null, null),
				socket.EndReceive
			);
		}

		public static Task<int> ReceiveAsync(this Socket socket, byte[] buffer, int offset, int count)
		{
			return socket.ReceiveAsync(buffer, offset, count, SocketFlags.None);
		}

		public static Task<int> ReceiveAsync(this Socket socket, ArraySegment<byte> segment)
		{
			return socket.ReceiveAsync(segment.Array, segment.Offset, segment.Count);
		}

		public static async Task<ArraySegment<byte>> ReceiveArraySegmentAsync(this Socket socket, ArraySegment<byte> segment)
		{
			return segment.Take(await socket.ReceiveAsync(segment));
		}

		public static async Task<ArraySegment<byte>> ReceiveArraySegmentAsync(this Socket socket, byte[] buffer)
		{
			return await socket.ReceiveArraySegmentAsync(buffer.ToArraySegment());
		}

		#endregion

		#region BeginAccept

		public static Task<Socket> AcceptAsync(this Socket socket)
		{
			return Task<Socket>.Factory.FromAsync(socket.BeginAccept(null, null), socket.EndAccept);
		}

		#endregion

		#region BeginReceiveFrom/BeginReceiveMessageFrom

		// TODO: THAT REF IS SUPER BAD

		public static Task<int> ReceiveFromAsync(this Socket socket, byte[] buffer, int offset, int count, SocketFlags flags, ref EndPoint remoteEnd)
		{
			return Task<int>.Factory.FromAsync(
				socket.BeginReceiveFrom(buffer, offset, count, flags, ref remoteEnd, null, null),
				(result) => {
					EndPoint tmp = new IPEndPoint(IPAddress.Any, 0);
					return socket.EndReceiveFrom(result, ref tmp);
					// TODO: can't assign remoteEnd with tmp, don't know what to do
				}
			);
		}

		public static Task<int> ReceiveFromAsync(this Socket socket, byte[] buffer, int offset, int count, ref EndPoint remoteEnd)
		{
			return socket.ReceiveFromAsync(buffer, offset, count, SocketFlags.None, ref remoteEnd);
		}

		public static Task<int> ReceiveFromAsync(this Socket socket, ArraySegment<byte> segment, ref EndPoint remoteEnd)
		{
			return socket.ReceiveFromAsync(segment.Array, segment.Offset, segment.Count, ref remoteEnd);
		}

		public static Task<ArraySegment<byte>> BeginReceiveArraySegmentFromAsync(this Socket socket, ArraySegment<byte> segment, ref EndPoint remoteEnd)
		{
			return socket.ReceiveFromAsync(segment, ref remoteEnd).ContinueWith((n) => segment.Take(n.Result));
		}

		#endregion

		public static Task SendFile(this Socket socket, string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions options)
		{
			return Task.Factory.FromAsync(
				socket.BeginSendFile(fileName, preBuffer, postBuffer, options, null, null),
				socket.EndSendFile
			);
		}

		public static Task SendFile(this Socket socket, string fileName)
		{
			return Task.Factory.FromAsync(
				socket.BeginSendFile(fileName, null, null),
				socket.EndSendFile
			);
		}

		public static Task<int> SendToAsync(this Socket socket, byte[] buffer, int offset, int count, SocketFlags flags, EndPoint remoteEndPoint)
		{
			return Task<int>.Factory.FromAsync(
				socket.BeginSendTo(buffer, offset, count, flags, remoteEndPoint, null, null),
				socket.EndSendTo
			);
		}

		public static Task<int> SendToAsync(this Socket socket, byte[] buffer, int offset, int count, EndPoint remoteEndPoint)
		{
			return socket.SendToAsync(buffer, offset, count, SocketFlags.None, remoteEndPoint);
		}

		public static Task<int> SendToAsync(this Socket socket, ArraySegment<byte> segment, EndPoint remoteEndPoint)
		{
			return socket.SendToAsync(segment.Array, segment.Offset, segment.Count, SocketFlags.None, remoteEndPoint);
		}
	}
}

