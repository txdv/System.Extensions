using System;
using System.Text;
using System.Security.Cryptography;

namespace System.Security.Cryptography
{
	public static class ComputeHashExtensions
	{
		#region ComputeHash

		#region ByteArray

		public static byte[] ComputeHash(this ArraySegment<byte> data, HashAlgorithm hashAlgorithm)
		{
			return hashAlgorithm.ComputeHash(data.Array, data.Offset, data.Count);
		}

		public static byte[] ComputeHash(this byte[] data, HashAlgorithm hashAlgorithm)
		{
			return hashAlgorithm.ComputeHash(data);
		}

		public static byte[] ComputeHash<THashAlgorithm>(this ArraySegment<byte> data)
			where THashAlgorithm : HashAlgorithm, new()
		{
			var hashAlgorithm = new THashAlgorithm();
			return data.ComputeHash(hashAlgorithm);
		}

		public static byte[] ComputeHash<THashAlgorithm>(this byte[] data)
			where THashAlgorithm : HashAlgorithm, new()
		{
			var hashAlgorithm = new THashAlgorithm();
			return data.ComputeHash(hashAlgorithm);
		}

		#endregion

		#region String

		public static byte[] ComputeHash(this string @string, HashAlgorithm hashAlgorithm, Encoding encoding)
		{
			return hashAlgorithm.ComputeHash(encoding.GetBytes(@string));
		}

		public static byte[] ComputeHash(this string @string, HashAlgorithm hashAlgorithm)
		{
			return @string.ComputeHash(hashAlgorithm, Encoding.Default);
		}

		public static byte[] ComputeHash<THashAlgorithm>(this string @string, Encoding encoding)
			where THashAlgorithm : HashAlgorithm, new()
		{
			var hashAlgorithm = new THashAlgorithm();
			return @string.ComputeHash(hashAlgorithm, encoding);
		}

		public static byte[] ComputeHash<THashAlgorithm>(this string @string)
			where THashAlgorithm : HashAlgorithm, new()
		{
			return @string.ComputeHash<THashAlgorithm>(Encoding.Default);
		}

		#endregion

		#endregion
	}
}

