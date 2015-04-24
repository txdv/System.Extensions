using System;
using System.Security.Cryptography;

namespace System.Security.Cryptography
{
	public static class HashAlgorithmExtensions
	{
		public static byte[] ComputeHash(this HashAlgorithm hashAlgorithm, ArraySegment<byte> buffer)
		{
			return hashAlgorithm.ComputeHash(buffer.Array, buffer.Offset, buffer.Count);
		}

		public static void TransformBlock(this HashAlgorithm hashAlgorithm, byte[] input, byte[] outputBuffer, int outputOffset)
		{
			hashAlgorithm.TransformBlock(input, 0, input.Length, outputBuffer, outputOffset);
		}

		public static void TransformBlock(this HashAlgorithm hashAlgorithm, byte[] input, byte[] outputBuffer)
		{
			hashAlgorithm.TransformBlock(input, 0, input.Length, outputBuffer, 0);
		}

		public static void TransformBlock(this HashAlgorithm hashAlgorithm, ArraySegment<byte> input, byte[] outputBuffer, int outputOffset)
		{
			hashAlgorithm.TransformBlock(input.Array, input.Offset, input.Count, outputBuffer, outputOffset);
		}

		public static void TransformBlock(this HashAlgorithm hashAlgorithm, ArraySegment<byte> input)
		{
			hashAlgorithm.TransformBlock(input, null, 0);
		}

		public static void TransformFinalBlock(this HashAlgorithm hashAlgorithm, ArraySegment<byte> input)
		{
			hashAlgorithm.TransformFinalBlock(input.Array, input.Offset, input.Count);
		}

		static byte[] emptyBuffer = new byte[0];

		public static void TransformFinalBlock(this HashAlgorithm hashAlgorithm)
		{
			hashAlgorithm.TransformFinalBlock(emptyBuffer, 0, 0);
		}

		public static void TransformFinalBlock(this HashAlgorithm hashAlgorithm, byte[] buffer)
		{
			hashAlgorithm.TransformFinalBlock(buffer, 0, buffer.Length);
		}
	}
}
