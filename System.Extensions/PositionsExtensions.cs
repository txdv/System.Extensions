using System;
using System.Linq;

namespace System.Collections.Generic
{
	public static class PositionsExtension
	{
		/// <summary>
		/// Returns the first position of an element specified by the predicate.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="predicate">Predicate.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static int Position<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Positions<TSource>(source, predicate).FirstOrDefault();
		}

		/// <summary>
		/// Returns the first position of an element present in the elements argument.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="elements">Elements.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static int Position<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> elements)
		{
			return source.Position(elements.Contains);
		}

		/// <summary>
		/// Returns the first position of an element present in the elements argument.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="elements">Elements.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static int Position<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
		{
			return source.Position(elements as IEnumerable<TSource>);
		}

		/// <summary>
		/// Returns the positions of the elements in an IEnumerable specified by the predict.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="predicate">Predicate to determine whether to return the position of an element in the source or not.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static IEnumerable<int> Positions<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			Ensure.NotSupported<TSource, System.Collections.IDictionary>();
			Ensure.ArgumentNotNull(source, nameof(source));
			Ensure.ArgumentNotNull(predicate, nameof(predicate));

			int i = 0;
			foreach (var element in source) {
				if (predicate(element)) {
					yield return i;
				}
				i++;
			}
		}

		/// <summary>
		/// Returns the positions of the elements present in the elements argument.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="elements">Elements.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static IEnumerable<int> Positions<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> elements)
		{
			return source.Positions(elements.Contains);
		}

		/// <summary>
		/// Returns the positions of the elements present in the elements argument.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="elements">Elements.</param>
		/// <typeparam name="TSource">The 1st type parameter.</typeparam>
		public static IEnumerable<int> Positions<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
		{
			return source.Positions(elements as IEnumerable<TSource>);
		}
	}
}

