using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Utilities {
	private static DateTime _1970 = new DateTime(1970, 1, 1);

	public static long GetCurrentTimeMillis() {
		return (long)((DateTime.UtcNow - _1970).TotalMilliseconds);
	}
}
