using System;

namespace System
{
	internal static class Ensure
	{
		public static void ArgumentNotNull(object value, string name)
		{
			if (value == null) {
				throw new ArgumentNullException(name);
			}
		}

		public static void NotSupported<T, TClass>(string message)
		{
			if (typeof(T) is TClass) {
				throw new NotSupportedException(typeof(TClass).ToString() + " is not supported");
			}
		}

		public static void NotSupported<T, TClass>()
		{
			NotSupported<T, TClass>(typeof(TClass).ToString() + " is not supported");
		}
	}
}

