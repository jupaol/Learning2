using System;
using FluentAssertions;
using Library.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests.Sorting
{
	[TestClass]
	public class BubbleSortTests
	{
		[TestClass]
		public class TheSortUsingClassicBubbleMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingClassicBubble();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_same_array_when_the_length_is_0_or_1()
			{
				int[] source;
				int[] res;

				source = G.Get(1);
				res = source.SortUsingClassicBubble().Res;
				res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingClassicBubble().Res;
				res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_same_array_sorted_ascending()
			{
				int[] res;
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var fullRes = source.SortUsingClassicBubble();
				res = fullRes.Res;
				res.Should().ContainInOrder(G.Expected);
				ReferenceEquals(source, res).Should().BeTrue();

				Console.WriteLine(fullRes);
			}
		}

		[TestClass]
		public class TheSortUsingBubbleSwapConditionMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingBubbleSwapCondition();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_same_array_when_the_length_is_0_or_1()
			{
				int[] source;
				int[] res;

				source = G.Get(1);
				res = source.SortUsingBubbleSwapCondition().Res;
				res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingBubbleSwapCondition().Res;
				res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_same_array_sorted_ascending()
			{
				int[] res;
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var fullRes = source.SortUsingBubbleSwapCondition();
				res = fullRes.Res;
				res.Should().ContainInOrder(G.Expected);
				ReferenceEquals(source, res).Should().BeTrue();

				Console.WriteLine(fullRes);
			}
		}

		[TestClass]
		public class TheSortUsingBubbleSwapConditionAndNthConditionMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingBubbleSwapConditionAndNthCondition();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_same_array_when_the_length_is_0_or_1()
			{
				int[] source;
				int[] res;

				source = G.Get(1);
				res = source.SortUsingBubbleSwapConditionAndNthCondition().Res;
				res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingBubbleSwapConditionAndNthCondition().Res;
				res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_same_array_sorted_ascending()
			{
				int[] res;
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var fullRes = source.SortUsingBubbleSwapConditionAndNthCondition();
				res = fullRes.Res;
				res.Should().ContainInOrder(G.Expected);
				ReferenceEquals(source, res).Should().BeTrue();

				Console.WriteLine(fullRes);
			}
		}

		[TestClass]
		public class TheSortUsingBubbleSwapConditionSkippingElementsAfterLastSwapMethod
		{
			[TestMethod]
			public void it_should_throw_if_source_is_null()
			{
				int[] source = null;

				Action a = () => source.SortUsingBubbleSwapConditionSkippingElementsAfterLastSwap();

				a.ShouldThrow<ArgumentNullException>().WithMessage("*source*");
			}

			[TestMethod]
			public void it_should_return_same_array_when_the_length_is_0_or_1()
			{
				int[] source;
				int[] res;

				source = G.Get(1);
				res = source.SortUsingBubbleSwapConditionSkippingElementsAfterLastSwap().Res;
				res.Should().BeSameAs(source);

				source = new int[0];
				res = source.SortUsingBubbleSwapConditionSkippingElementsAfterLastSwap().Res;
				res.Should().BeSameAs(source);
			}

			[TestMethod]
			public void it_should_return_same_array_sorted_ascending()
			{
				int[] res;
				var source = new int[G.Source.Length];

				Array.Copy(G.Source, source, G.Source.Length);

				var fullRes = source.SortUsingBubbleSwapConditionSkippingElementsAfterLastSwap();
				res = fullRes.Res;
				res.Should().ContainInOrder(G.Expected);
				ReferenceEquals(source, res).Should().BeTrue();

				Console.WriteLine(fullRes);
			}
		}
	}
}
