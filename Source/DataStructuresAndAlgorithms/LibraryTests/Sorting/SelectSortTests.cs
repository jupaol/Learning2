using System;
using FluentAssertions;
using Library.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests.Sorting
{
	[TestClass]
	public class SelectSortTests
	{
		[TestClass]
		public class TheSortUsingClassicSelectMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				var source = default(int[]);
				Action a = () => source.SortUsingClassicSelect();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_sort_an_array_with_one_element()
			{
				var source = new[] {4};

				var res = source.SortUsingClassicSelect();

				res.Res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingClassicSelect();

				res.Res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_the_sorted_array()
			{
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var res = source.SortUsingClassicSelect();

				res.Res.Should().BeInAscendingOrder().And.ContainInOrder(G.Expected);

				Console.WriteLine(res);
			}
		}

		[TestClass]
		public class TheSortUsingClassicSelectSwappingOnceMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				var source = default(int[]);
				Action a = () => source.SortUsingClassicSelectSwappingOnce();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_sort_an_array_with_one_element()
			{
				var source = new[] {4};

				var res = source.SortUsingClassicSelectSwappingOnce();

				res.Res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingClassicSelectSwappingOnce();

				res.Res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_the_sorted_array()
			{
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var res = source.SortUsingClassicSelectSwappingOnce();

				res.Res.Should().BeInAscendingOrder().And.ContainInOrder(G.Expected);

				Console.WriteLine(res);
			}
		}
	}
}
