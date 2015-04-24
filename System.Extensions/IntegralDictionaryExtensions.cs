using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
	public static class IncrementDictionaryExtensions
	{
		public static sbyte IncrementKey<T>(this IDictionary<T, sbyte> dictionary, T key)
		{
			sbyte i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static byte IncrementKey<T>(this IDictionary<T, byte> dictionary, T key)
		{
			byte i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static char IncrementKey<T>(this IDictionary<T, char> dictionary, T key)
		{
			char i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = (char)0;
			}
			dictionary[key] = i;
			return i;
		}
		public static short IncrementKey<T>(this IDictionary<T, short> dictionary, T key)
		{
			short i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static ushort IncrementKey<T>(this IDictionary<T, ushort> dictionary, T key)
		{
			ushort i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static int IncrementKey<T>(this IDictionary<T, int> dictionary, T key)
		{
			int i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static uint IncrementKey<T>(this IDictionary<T, uint> dictionary, T key)
		{
			uint i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static long IncrementKey<T>(this IDictionary<T, long> dictionary, T key)
		{
			long i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static ulong IncrementKey<T>(this IDictionary<T, ulong> dictionary, T key)
		{
			ulong i;
			if (dictionary.TryGetValue(key, out i)) {
				i++;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}

		public static sbyte DecrementKey<T>(this IDictionary<T, sbyte> dictionary, T key)
		{
			sbyte i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static byte DecrementKey<T>(this IDictionary<T, byte> dictionary, T key)
		{
			byte i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static char DecrementKey<T>(this IDictionary<T, char> dictionary, T key)
		{
			char i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = (char)0;
			}
			dictionary[key] = i;
			return i;
		}
		public static short DecrementKey<T>(this IDictionary<T, short> dictionary, T key)
		{
			short i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static ushort DecrementKey<T>(this IDictionary<T, ushort> dictionary, T key)
		{
			ushort i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static int DecrementKey<T>(this IDictionary<T, int> dictionary, T key)
		{
			int i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static uint DecrementKey<T>(this IDictionary<T, uint> dictionary, T key)
		{
			uint i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static long DecrementKey<T>(this IDictionary<T, long> dictionary, T key)
		{
			long i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
		public static ulong DecrementKey<T>(this IDictionary<T, ulong> dictionary, T key)
		{
			ulong i;
			if (dictionary.TryGetValue(key, out i)) {
				i--;
			} else {
				i = 0;
			}
			dictionary[key] = i;
			return i;
		}
	}
}

