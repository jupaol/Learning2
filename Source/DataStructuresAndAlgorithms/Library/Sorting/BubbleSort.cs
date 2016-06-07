using System;

namespace Library.Sorting
{
	public static class BubbleSort
	{
		/// <summary>
		/// Uses the classic bubble sort algorithm, using two nested loops without swap conditions
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassicBubble<T>(this T[] source, SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;

			for (var i = 1; i < source.Length - 1; i++)
			{
				for (var j = 1; j < source.Length; j++)
				{
					iterations++;

					Helpers.SwapIfNeeded(ref source[j - 1], ref source[j], sorting, () => swaps++);
				}
			}

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Bubble sort algorithm with simple swap conditions
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingBubbleSwapCondition<T>(this T[] source, SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;
			bool wasSwaped;

			do
			{
				wasSwaped = false;

				for (var j = 1; j < source.Length; j++)
				{
					iterations++;

					Helpers.SwapIfNeeded(ref source[j - 1], ref source[j], sorting, () =>
					{
						swaps++;
						wasSwaped = true;
					});
				}
			} while (wasSwaped);

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Bubble sort algorithm with swap condition and with Nth numbers condition
		/// </summary>
		/// <remarks>
		/// The Nth number condition specify that at Nth pass/iteration, it finds the Nth largest number so 
		/// we can skip looking at the N - 1 numbers on the Nth + 1 iteration (next iteration)
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingBubbleSwapConditionAndNthCondition<T>(this T[] source, SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;
			bool wasSwaped;
			var length = source.Length;

			do
			{
				wasSwaped = false;

				for (var j = 1; j < length; j++)
				{
					iterations++;

					Helpers.SwapIfNeeded(ref source[j - 1], ref source[j], sorting, () =>
					{
						swaps++;
						wasSwaped = true;
					});
				}

				length--;

			} while (wasSwaped);

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}

		/// <summary>
		/// Bubble sort algorithm with swap condition and with Nth numbers condition improved to skip all numbers after the last swap
		/// </summary>
		/// <remarks>
		/// The Nth number condition can be improved noticing that all numbers after the lasp swap are already sorted
		/// and therefore they can be skipped
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingBubbleSwapConditionSkippingElementsAfterLastSwap<T>(this T[] source, SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var iterations = 0;
			var swaps = 0;
			bool wasSwaped;
			var length = source.Length;
			var newLength = 0;

			do
			{
				wasSwaped = false;

				for (var j = 1; j < length; j++)
				{
					iterations++;

					var j1 = j;

					Helpers.SwapIfNeeded(ref source[j - 1], ref source[j], sorting, () =>
					{
						swaps++;
						wasSwaped = true;
						newLength = j1;
					});
				}

				length = newLength;

			} while (wasSwaped);

			return new SwappingSortingResult<T>(source, iterations, swaps);
		}
	}
}