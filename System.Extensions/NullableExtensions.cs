using System;

namespace System
{
	public static class NullableExtensions
	{
		public static bool HasValueAndEquals<T>(this Nullable<T> nullable, T value) where T : struct
		{
			return nullable.HasValue && nullable.Value.Equals(value);
		}
	}
}

