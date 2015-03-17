using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace System.Net.Sockets
{
	public static class TcpClientExtensions
	{
		public static void Connect(this TcpClient client, IPEndPoint ipEndPoint)
		{
			client.Connect(ipEndPoint.Address, ipEndPoint.Port);
		}

		public static void Connect(this TcpClient client, IPHostEntry ipHostEntry, int port)
		{
			client.Connect(ipHostEntry.AddressList, port);
		}

		public static async Task ConnectAsync(this TcpClient client, IPEndPoint ipEndPoint)
		{
			await client.ConnectAsync(ipEndPoint.Address, ipEndPoint.Port);
		}

		public static async Task ConnectAsync(this TcpClient client, IPHostEntry ipHostEntry, int port)
		{
			await client.ConnectAsync(ipHostEntry.AddressList, port);
		}
	}
}

