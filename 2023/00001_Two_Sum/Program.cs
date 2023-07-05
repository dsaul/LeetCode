using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace _00001_Two_Sum
{
	public static class Program
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

		public static int[] TwoSum(int[] nums, int target)
		{
			int[] result = new int[2] { -1, -1 };

			// Sort the input.
			int[] sortedNums = new int[nums.Length];
			Array.Copy(nums, sortedNums, nums.Length);
			Array.Sort(sortedNums);

			// Find the values.
			int j = result.Length - 1;
			int i = sortedNums.Length;
			int remainder = target;
			while ((--i) >= 0)
			{
				int num = sortedNums[i];
				if (num > remainder) 
					continue;

				result[j] = num;
				j--;
				remainder -= num;
			}

			// Convert values to indexes.
			List<int> usedIndexes = new();
			for (int k=0; k< result.Length; k++)
			{
				int resVal = result[k];

				for (int l=0; l < nums.Length; l++)
				{
					if (usedIndexes.Contains(l))
						continue;

					int numVal = nums[l];

					if (resVal == numVal)
					{
						result[k] = l;
						usedIndexes.Add(l);
						break;
					}
				}
				
			}

			// Ensure order smallest index to largest.
			Array.Sort(result);

			return result;
		}
	}

	[TestClass]
	public class TwoSumTest
	{
		[TestMethod]
		public void Test1()
		{
			int[] result = Program.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
		}

		[TestMethod]
		public void Test2()
		{
			int[] result = Program.TwoSum(new int[] { 3, 2, 4 }, 6);
			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 2);
		}

		[TestMethod]
		public void Test3()
		{
			int[] result = Program.TwoSum(new int[] { 3, 3 }, 6);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
		}

		[TestMethod]
		public void Test4()
		{
			int[] result = Program.TwoSum(new int[] { -3, 4, 3, 90 }, 0);
			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 2);
		}
	}
}