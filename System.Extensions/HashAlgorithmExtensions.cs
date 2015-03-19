﻿using System;
using System.Security.Cryptography;

namespace System.Security.Cryptography
{
	public static class HashAlgorithmExtensions
	{
		public static void ComputeHash(this HashAlgorithm hashAlgorithm, ArraySegment<byte> buffer)
		{
			hashAlgorithm.ComputeHash(buffer.Array, buffer.Offset, buffer.Count);
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
	}
}