using System;

namespace Library.Sorting
{
	public class SortingResult<T>
		where T : struct, IComparable<T>
	{
		public SortingResult(T[] res, int iterations)
		{
			if (res == null)
			{
				throw new ArgumentNullException(nameof(res));
			}

			Res = res;
			Iterations = iterations;
		}

		public T[] Res { get; }

		public int Iterations { get; }

		public override string ToString()
		{
			return $"Sorting: {Res.Length:n0} elements took {Iterations:n0} iterations";
		}
	}
}
