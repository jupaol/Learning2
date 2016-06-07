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

		public int Swaps { get; }

		public override string ToString()
		{
			return $"{base.ToString()} and Swaps: {Swaps:n0}";
		}
	}
}
