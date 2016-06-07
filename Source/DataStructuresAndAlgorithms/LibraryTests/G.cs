using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTests
{
	public static class G
	{
		private static  readonly Random Random = new Random((int)DateTime.Now.Ticks);

		static G()
		{
			Source = Get(1000);
			Expected = Source.OrderBy(x => x).ToArray();
		}

		public static int[] Source { get; }

		public static int[] Expected { get; private set; }

		public static int[] Get(int max = 100000)
		{
			if (max <= 0)
			{
				throw new ArgumentException("Max should be grather than 0", nameof(max));
			}

			var list = new List<int>();

			for (var i = 0; i < max; i++)
			{
				list.Add(Random.Next(max*-1, max));
			}

			return list.ToArray();
		}
	}
}
