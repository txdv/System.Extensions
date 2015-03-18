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
		
		public static string GetString(this Encoding encoding, ArraySegment<byte>? segment)
		{
			if (!segment.HasValue) {
				return null;
			} else {
				var value = segment.Value;
				return encoding.GetString(value.Array, value.Offset, value.Count);
			}
		}

		public static ArraySegment<byte> GetArraySegment(this Encoding encoding, string text)
		{
			return encoding.GetBytes(text).ToArraySegment();
		}

		public static string ToString(this ArraySegment<byte> segment, Encoding encoding)
		{
			return encoding.GetString(segment);
		}

		public static string ToString(byte[] buffer, Encoding encoding)
		{
			return encoding.GetString(buffer);
		}
	}
}
