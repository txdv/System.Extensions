using System;
using System.Text;

namespace System
{
	public static class EncodingExtensions
	{
		public static string GetString(this Encoding encoding, ArraySegment<byte> segment)
		{
			return encoding.GetString(segment.Array, segment.Offset, segment.Count);
		}

		public static ArraySegment<byte> GetArraySegment(this Encoding encoding, string text)
		{
			return default(ArraySegment<byte>);
			//return encoding.GetBytes(text).ToArraySegment();
		}
	}
}