using System;

namespace Library.Sorting
{
	public static class Helpers
	{
		public static void SwapIfNeeded<T>(ref T left, ref T right, SortingDirection sorting, Action onSwap = null)
		where T : struct, IComparable<T>
		{
			if (ShoudSwap(left, right, sorting))
			{
				Swap(ref left, ref right);

				onSwap?.Invoke();
			}
		}

		public static bool ShoudSwap<T>(T left, T right, SortingDirection sorting)
			where T : struct, IComparable<T>
		{
			var res = left.CompareTo(right);

			if (res == 0)
			{
				return false;
			}

			switch (sorting)
			{
				case SortingDirection.Ascending:
					return res > 0;
				case SortingDirection.Descending:
					return res < 0;
				default:
					throw new ArgumentOutOfRangeException(nameof(sorting), sorting, null);
			}
		}

		public static void Swap<T>(ref T left, ref T right)
			where T : struct, IComparable<T>
		{
			var tmp = left;

			left = right;
			right = tmp;
		}
	}
}
