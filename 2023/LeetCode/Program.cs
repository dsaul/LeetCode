using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace _00001_Two_Sum
{
	[TestClass]
	public class _00001_Two_Sum
	{
		// Given an array of integers nums and an integer target,
		// return indices of the two numbers such that they add up to target.

		// You may assume that each input would have exactly one solution,
		// and you may not use the same element twice.

		// You can return the answer in any order.

		// Example 1:
		// Input: nums = [2,7,11,15], target = 9
		// Output: [0,1]
		// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

		// Example 2:
		// Input: nums = [3,2,4], target = 6
		// Output: [1,2]

		// Example 3:
		// Input: nums = [3,3], target = 6
		// Output: [0,1]

		public static int[] TwoSumSimple(int[] nums, int target)
		{
			int[] result = new int[2] { -1, -1 };

			for (int i = 0; i<nums.Length; i++)
			{
				for (int j = 0; j < nums.Length; j++)
				{
					if (j == i)
						continue;

					if (nums[i] + nums[j] == target)
					{
						result[0] = i;
						result[1] = j;
						goto end;
					}
				}
			}

			end:
			return result;
		}

		[TestMethod]
		public void SimpleTest1()
		{
			int[] result = _00001_Two_Sum.TwoSumSimple(new int[] { 2, 7, 11, 15 }, 9);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
		}

		[TestMethod]
		public void SimpleTest2()
		{
			int[] result = _00001_Two_Sum.TwoSumSimple(new int[] { 3, 2, 4 }, 6);
			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 2);
		}

		[TestMethod]
		public void SimpleTest3()
		{
			int[] result = _00001_Two_Sum.TwoSumSimple(new int[] { 3, 3 }, 6);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
		}

		[TestMethod]
		public void SimpleTest4()
		{
			int[] result = _00001_Two_Sum.TwoSumSimple(new int[] { -3, 4, 3, 90 }, 0);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 2);
		}
	}
}