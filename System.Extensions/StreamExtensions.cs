using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
	public static class StreamExtensions
	{
		public static void Write(this Stream stream, ArraySegment<byte> segment)
		{
			stream.Write(segment.Array, segment.Offset, segment.Count);
		}

		public static void Write(this Stream stream, byte[] array, int offset)
		{
			stream.Write(array, offset, array.Length - offset);
		}

		public static void Write(this Stream stream, byte[] array)
		{
			stream.Write(array, 0);
		}

		#region string

		public static void Write(this Stream stream, Encoding encoding, string text)
		{
			stream.Write(encoding.GetBytes(text));
		}

		public static void Write(this Stream stream, string text)
		{
			stream.Write(Encoding.Default, text);
		}

		#endregion

		public static Task WriteAsync(this Stream stream, ArraySegment<byte> segment)
		{
			return stream.WriteAsync(segment.Array, segment.Offset, segment.Count);
		}

		public static Task WriteAsync(this Stream stream, byte[] array, int offset)
		{
			return stream.WriteAsync(array, offset, array.Length - offset);
		}

		public static Task WriteAsync(this Stream stream, byte[] array)
		{
			return stream.WriteAsync(array, 0);
		}

		#region string

		public static Task WriteAsync(this Stream stream, Encoding encoding, string text)
		{
			return stream.WriteAsync(encoding.GetBytes(text));
		}

		public static Task WriteAsync(this Stream stream, string text)
		{
			return stream.WriteAsync(Encoding.Default, text);
		}

		#endregion

		#region Sync

		public static int Read(this Stream stream, ArraySegment<byte> segment)
		{
			return stream.Read(segment.Array, segment.Offset, segment.Count);
		}

		public static int Read(this Stream stream, byte[] buffer, int offset)
		{
			return stream.Read(buffer, offset, buffer.Length - offset);
		}

		public static int Read(this Stream stream, byte[] buffer)
		{
			return stream.Read(buffer, 0);
		}

		public static ArraySegment<byte> ReadArraySegment(this Stream stream, ArraySegment<byte> segment)
		{
			return segment.Take(stream.Read(segment));
		}

		public static ArraySegment<byte> ReadArraySegment(this Stream stream, byte[] buffer, int offset, int count)
		{
			return stream.ReadArraySegment(buffer.ToArraySegment(offset, count));
		}

		public static ArraySegment<byte> ReadArraySegment(this Stream stream, byte[] buffer, int offset)
		{
			return stream.ReadArraySegment(buffer, offset, buffer.Length - offset);
		}

		public static ArraySegment<byte> ReadArraySegment(this Stream stream, byte[] buffer)
		{
			return stream.ReadArraySegment(buffer, 0);
		}

		#endregion

		#region Async

		public static Task<int> ReadAsync(this Stream stream, ArraySegment<byte> segment)
		{
			return stream.ReadAsync(segment.Array, segment.Offset, segment.Count);
		}

		public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset)
		{
			return stream.ReadAsync(buffer, offset, buffer.Length - offset);
		}

		public static Task<int> ReadAsync(this Stream stream, byte[] buffer)
		{
			return stream.ReadAsync(buffer, 0);
		}

		public static async Task<ArraySegment<byte>> ReadArraySegmentAsync(this Stream stream, ArraySegment<byte> segment)
		{
			return segment.Take(await stream.ReadAsync(segment));
		}

		public static Task<ArraySegment<byte>> ReadArraySegmentAsync(this Stream stream, byte[] buffer, int offset, int count)
		{
			return stream.ReadArraySegmentAsync(buffer.ToArraySegment(offset, count));
		}

		public static Task<ArraySegment<byte>> ReadArraySegmentAsync(this Stream stream, byte[] buffer, int offset)
		{
			return stream.ReadArraySegmentAsync(buffer, offset, buffer.Length - offset);
		}

		public static Task<ArraySegment<byte>> ReadArraySegmentAsync(this Stream stream, byte[] buffer)
		{
			return stream.ReadArraySegmentAsync(buffer, 0);
		}

		#endregion

		public static void ReadBlock(this Stream stream, byte[] buffer, int offset, int count)
		{
			while (count > 0) {
				int n = stream.Read(buffer, offset, count);
				offset += n;
				count -= n;
			}
		}

		public static void ReadBlock(this Stream stream, byte[] buffer)
		{
			stream.ReadBlock(buffer, 0, buffer.Length);
		}

		public static void ReadBlock(this Stream stream, ArraySegment<byte> buffer)
		{
			stream.ReadBlock(buffer.Array, buffer.Offset, buffer.Count);
		}
	}
}

