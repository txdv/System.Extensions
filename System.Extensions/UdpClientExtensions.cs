using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace System.Extensions
{
	public static class UdpClientExtensions
	{
		public static int Send(this UdpClient client, byte[] datagram, int bytes, IPAddress address, int port)
		{
			return client.Send(datagram, bytes, new IPEndPoint(address, port));
		}

		public static int Send(this UdpClient client, byte[] datagram, IPAddress address, int port)
		{
			return client.Send(datagram, datagram.Length, new IPEndPoint(address, port));
		}

		public static int Send(this UdpClient client, byte[] datagram, IPEndPoint ipEndPoint)
		{
			return client.Send(datagram, datagram.Length, ipEndPoint);
		}

		public static int Send(this UdpClient client, byte[] datagram, string host, int port)
		{
			return client.Send(datagram, datagram.Length, host, port);
		}

		#region string

		public static int Send(this UdpClient client, Encoding encoding, string text, IPEndPoint iPEndPoint)
		{
			return client.Send(encoding.GetBytes(text), iPEndPoint);
		}

		public static int Send(this UdpClient client, string text, IPEndPoint iPEndPoint)
		{
			return client.Send(Encoding.Default, text, iPEndPoint);
		}

		public static int Send(this UdpClient client, Encoding encoding, string text, IPAddress address, int port)
		{
			return client.Send(encoding.GetBytes(text), address, port);
		}

		public static int Send(this UdpClient client, string text, IPAddress address, int port)
		{
			return client.Send(Encoding.Default, text, address, port);
		}

		public static int Send(this UdpClient client, Encoding encoding, string text, string host, int port)
		{
			return client.Send(encoding.GetBytes(text), host, port);
		}

		public static int Send(this UdpClient client, string text, string host, int port)
		{
			return client.Send(Encoding.Default, text, host, port);
		}

		#endregion

		#region Async

		public static async Task<int> SendAsync(this UdpClient client, byte[] datagram, int bytes, IPAddress address, int port)
		{
			return await client.SendAsync(datagram, bytes, new IPEndPoint(address, port));
		}

		public static async Task<int> SendAsync(this UdpClient client, byte[] datagram, IPAddress address, int port)
		{
			return await client.SendAsync(datagram, datagram.Length, new IPEndPoint(address, port));
		}

		public static async Task<int> SendAsync(this UdpClient client, byte[] datagram, IPEndPoint endPoint)
		{
			return await client.SendAsync(datagram, datagram.Length, endPoint);
		}

		public static async Task<int> SendAsync(this UdpClient client, byte[] datagram, string host, int port)
		{
			return await client.SendAsync(datagram, datagram.Length, host, port);
		}

		#region string

		public static async Task<int> SendAsync(this UdpClient client, Encoding encoding, string text, IPEndPoint iPEndPoint)
		{
			return await client.SendAsync(encoding.GetBytes(text), iPEndPoint);
		}

		public static async Task<int> SendAsync(this UdpClient client, string text, IPEndPoint iPEndPoint)
		{
			return await client.SendAsync(Encoding.Default, text, iPEndPoint);
		}

		public static async Task<int> SendAsync(this UdpClient client, Encoding encoding, string text, IPAddress address, int port)
		{
			return await client.SendAsync(encoding.GetBytes(text), address, port);
		}

		public static async Task<int> SendAsync(this UdpClient client, string text, IPAddress address, int port)
		{
			return await client.SendAsync(Encoding.Default, text, address, port);
		}

		public static async Task<int> SendAsync(this UdpClient client, Encoding encoding, string text, string host, int port)
		{
			return await client.SendAsync(encoding.GetBytes(text), host, port);
		}

		public static async Task<int> SendAsync(this UdpClient client, string text, string host, int port)
		{
			return await client.SendAsync(Encoding.Default, text, host, port);
		}

		#endregion

		#endregion
	}
}