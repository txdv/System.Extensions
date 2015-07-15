using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
	public static class StringExtensions
	{
		#region StartsWith

		public static bool StartsWith(this string str, params string[] strings)
		{
			return StartsWith(str, strings as IEnumerable<string>);
		}

		public static bool StartsWith(this string str, IEnumerable<string> strings)
		{
			return strings.Select(value => str.StartsWith(value)).Contains(true);
		}

		#endregion

		#region SkipPrefix

		public static string SkipPrefix(this string str, string prefix)
		{
			if (str.StartsWith(prefix)) {
				return str.Substring(prefix.Length);
			} else {
				return str;
			}
		}

		public static string SkipPrefix(this string str, params string[] prefixes)
		{
			foreach (var prefix in prefixes) {
				if (str.StartsWith(prefix)) {
					return str.Substring(prefix.Length);
				}
			}
			return str;
		}

		#endregion
	}
}

