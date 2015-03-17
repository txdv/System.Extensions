using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace System.Net.Sockets
{
	public static class TcpClientExtensions
	{
		public static async Task ConnectAsync(this TcpClient client, IPEndPoint ipEndPoint)
		{
			await client.ConnectAsync(ipEndPoint.Address, ipEndPoint.Port);
		}
	}
}

