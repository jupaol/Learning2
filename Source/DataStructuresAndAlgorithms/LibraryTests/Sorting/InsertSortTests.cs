using System;
using FluentAssertions;
using Library.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests.Sorting
{
	[TestClass]
	public class InsertSortTests
	{
		[TestClass]
		public class TheSortUsingClassiccInsertMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingClassiccInsert();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_the_array_when_it_has_one_or_zero_elements()
			{
				int[] source;
				SwappingSortingResult<int> res;
				int[] resArray;

				source = new int[0];
				res = source.SortUsingClassiccInsert();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);

				source = new[] {3};
				res = source.SortUsingClassiccInsert();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_the_sorted_array()
			{
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var res = source.SortUsingClassiccInsert();
				var resArray = res.Res;
				resArray.Should().BeSameAs(source).And.ContainInOrder(G.Expected);

				Console.WriteLine(res);
			}
		}

		[TestClass]
		public class TheSortUsingClassiccInsertNoIfsMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingClassiccInsertNoIfs();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_the_array_when_it_has_one_or_zero_elements()
			{
				int[] source;
				SwappingSortingResult<int> res;
				int[] resArray;

				source = new int[0];
				res = source.SortUsingClassiccInsertNoIfs();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);

				source = new[] { 3 };
				res = source.SortUsingClassiccInsertNoIfs();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_the_sorted_array()
			{
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var res = source.SortUsingClassiccInsertNoIfs();
				var resArray = res.Res;
				resArray.Should().BeSameAs(source).And.ContainInOrder(G.Expected);

				Console.WriteLine(res);
			}
		}

		[TestClass]
		public class TheSortUsingClassiccInsertNoIfsOneSwapForCurrentElementMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingClassiccInsertNoIfsOneSwapForCurrentElement();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_the_array_when_it_has_one_or_zero_elements()
			{
				int[] source;
				SwappingSortingResult<int> res;
				int[] resArray;

				source = new int[0];
				res = source.SortUsingClassiccInsertNoIfsOneSwapForCurrentElement();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);

				source = new[] { 3 };
				res = source.SortUsingClassiccInsertNoIfsOneSwapForCurrentElement();
				resArray = res.Res;
				resArray.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_the_sorted_array()
			{
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var res = source.SortUsingClassiccInsertNoIfsOneSwapForCurrentElement();
				var resArray = res.Res;
				resArray.Should().BeSameAs(source).And.ContainInOrder(G.Expected);

				Console.WriteLine(res);
			}
		}
	}
}
