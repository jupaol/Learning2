using System;

namespace Library.Sorting
{
	public static class InsertSort
	{
		/// <summary>
		/// Classic Insert sorting algorithm
		/// </summary>
		/// <remarks>Sorts to the left</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassiccInsert<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException("source");
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 1; i < source.Length; i++)
			{
				for (var j = i; j > 0; j--)
				{
					iterations++;

					Helpers.SwapIfNeeded(ref source[j - 1], ref source[j], sorting, () => swaps++);
				}
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Classic Insert sorting algorithm. Variation to reduce if statements
		/// </summary>
		/// <remarks>Sorts to the left</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassiccInsertNoIfs<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException("source");
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 1; i < source.Length; i++)
			{
				var j = i;

				while (j > 0 && Helpers.ShoudSwap(source[j - 1], source[j], sorting))
				{
					Helpers.Swap(ref source[j - 1], ref source[j]);

					j--;
					swaps++;
					iterations++;
				}
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Classic Insert sorting algorithm. Variation to reduce if statements and to swap current
		/// element just once
		/// </summary>
		/// <remarks>Sorts to the left</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassiccInsertNoIfsOneSwapForCurrentElement<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException("source");
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 1; i < source.Length; i++)
			{
				var current = source[i];
				var j = i - 1;

				while (j >= 0 && Helpers.ShoudSwap(source[j], current, sorting))
				{
					source[j + 1] = source[j];

					j--;
					swaps++;
					iterations++;
				}

				source[j + 1] = current;
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}
	}
}
