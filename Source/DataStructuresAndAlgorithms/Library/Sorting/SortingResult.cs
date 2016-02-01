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
				throw new ArgumentNullException("res");
			}

			Res = res;
			Iterations = iterations;
		}

		public T[] Res { get; private set; }

		public int Iterations { get; private set; }

		public override string ToString()
		{
			return string.Format("Sorting: {0:n0} elements took {1:n0} iterations", Res.Length, Iterations);
		}
	}
}
