using System;
using System.Linq;

namespace System
{
	public static class HexExtensions
	{
		public static string ToHex(this byte[] bytes)
		{
			return String.Join(string.Empty, Array.ConvertAll(bytes, x => x.ToString("x2")));
		}

		public static string ToHex(this ArraySegment<byte> segment)
		{
			return String.Join(String.Empty, segment.Select((x) => x.ToString("x2")));
		}
	}
}

