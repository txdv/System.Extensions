using System;
using System.Collections.Generic;

namespace System
{
	public static class DictionaryExtensions
	{
		public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> create)
		{
			TValue @value;
			if (!dictionary.TryGetValue(key, out @value)) {
				@value = create();
				dictionary[key] = @value;
			}
			return @value;
		}
	}
}
