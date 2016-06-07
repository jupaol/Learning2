using System;

namespace Library.Sorting
{
	public static class SelectSort
	{
		/// <summary>
		/// Classic Select
		/// </summary>
		/// <remarks>
		/// Sorts to the right, picks up the smallest/largest (depending on if it's desc or asc)
		/// and puts it from left to right
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassicSelect<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 0; i < source.Length - 1; i++)
			{
				for (var j = i + 1; j < source.Length; j++)
				{
					if (Helpers.ShoudSwap(source[i], source[j], sorting))
					{
						Helpers.Swap(ref source[i], ref source[j]);
						swaps++;
					}

					iterations++;
				}
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Classic Select, swapping only once
		/// </summary>
		/// <remarks>
		/// Sorts to the right, picks up the smallest/largest (depending on if it's desc or asc)
		/// and puts it from left to right
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassicSelectSwappingOnce<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 0; i < source.Length - 1; i++)
			{
				var latestIndex = i;

				for (var j = i + 1; j < source.Length; j++)
				{
					if (Helpers.ShoudSwap(source[latestIndex], source[j], sorting))
					{
						latestIndex = j;
					}

					iterations++;
				}

				if (i != latestIndex)
				{
					Helpers.Swap(ref source[i], ref source[latestIndex]);
					swaps++;
				}
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}
	}
}
