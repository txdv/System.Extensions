using System;
using System.Collections.Generic;

namespace System.Extensions
{
	public static class DefaultExtensions
	{
		// http://referencesource.microsoft.com/#System.Core/System/Linq/Enumerable.cs,8087366974af11d2
		/// <summary>
		/// Returns the first element of the sequence or a default value specified by the user if no such element is found.
		/// </summary>
		/// <returns>The or default.</returns>
		/// <param name="source">source sequence</param>
		/// <param name="defaultValue">default value to be returned if no element is found in the sequence</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
		{
			Ensure.ArgumentNotNull(source, nameof(source));

			IList<TSource> list = source as IList<TSource>;
			if (list != null) {
				if (list.Count > 0) {
					return list[0];
				}
			} else {
				using (IEnumerator<TSource> e = source.GetEnumerator()) {
					if (e.MoveNext()) {
						return e.Current;
					}
				}
			}
			return defaultValue;
		}

		// http://referencesource.microsoft.com/#System.Core/System/Linq/Enumerable.cs,b7e5965cab68b1cf,references
		/// <summary>
		/// Returns the first element of the sequence that satisfies a condition or a default value specified by the user if no such element is found.
		/// </summary>
		/// <returns>The or default.</returns>
		/// <param name="source">source sequence</param>
		/// <param name="defaultValue">default value to be returned if no element is found in the sequence</param>
		/// <param name="predicate">predicate that specifies the condition</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue, Func<TSource, bool> predicate)
		{
			Ensure.ArgumentNotNull(source, nameof(source));
			Ensure.ArgumentNotNull(predicate, nameof(predicate));

			using (IEnumerator<TSource> e = source.GetEnumerator()) {
				if (e.MoveNext()) {
					if (predicate(e.Current)) {
						return e.Current;
					}
				}
			}

			return defaultValue;
		}

		/// <summary>
		/// Returns the last element of the sequence or a default value specified by the user if no such element is found.
		/// </summary>
		/// <returns>The or default.</returns>
		/// <param name="source">source sequence</param>
		/// <param name="defaultValue">default value to be returned if no element is found in the sequence</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue) {
			Ensure.ArgumentNotNull(source, nameof(source));

			IList<TSource> list = source as IList<TSource>;

			if (list != null) {
				int count = list.Count;
				if (count > 0) return list[count - 1];
			} else {
				using (IEnumerator<TSource> e = source.GetEnumerator()) {
					if (e.MoveNext()) {
						TSource result;
						do {
							result = e.Current;
						} while (e.MoveNext());
						return result;
					}
				}
			}

			return defaultValue;
		}

		/// <summary>
		/// Returns the last element of the sequence that satisfies a condition or a default value specified by the user if no such element is found.
		/// </summary>
		/// <returns>The or default.</returns>
		/// <param name="source">source sequence</param>
		/// <param name="defaultValue">default value to be returned if no element is found in the sequence</param>
		/// <param name="predicate">predicate that specifies the condition</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue, Func<TSource, bool> predicate) {
			Ensure.ArgumentNotNull(source, nameof(source));
			Ensure.ArgumentNotNull(predicate, nameof(predicate));

			TSource result = defaultValue;
			foreach (TSource element in source) {
				if (predicate(element)) {
					result = element;
				}
			}

			return result;
		}
	}
}

