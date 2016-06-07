using System;

namespace Library.Sorting
{
	public static class MergeSort
	{
		/// <summary>
		/// Classic merge sort
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sorting"></param>
		/// <returns></returns>
		public static SwappingSortingResult<T> SortUsingClassicMerge<T>(this T[] source,
			SortingDirection sorting = SortingDirection.Ascending)
			where T : struct, IComparable<T>
		{
			if (null == source)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return null;
		}
	}
}
