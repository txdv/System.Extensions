using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Extensions
{
	public static class CombinationExtensions
	{
		public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T[]> arrays)
		{
			if (!arrays.Any()) {
				yield return Enumerable.Empty<T>();
				yield break;
			}

			foreach (var element in arrays.First()) {
				foreach (var combintation in Combinations(arrays.Skip(1))) {
					yield return new[] { element }.Concat(combintation);
				}
			}
		}
	}
}

