using System;

namespace Library.Sorting
{
	public class SwappingSortingResult<T> : SortingResult<T>
		where T : struct, IComparable<T>
	{
		public SwappingSortingResult(T[] res, int iterations, int swaps)
			: base(res, iterations)
		{
			Swaps = swaps;
		}

		public int Swaps { get; private set; }

		public override string ToString()
		{
			return string.Format("{0} and Swaps: {1:n0}", base.ToString(), Swaps);
		}
	}
}
