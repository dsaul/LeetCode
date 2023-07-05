using System;
using System.Collections.Generic;
using System.Linq;

namespace _0153.Find_Minimum_in_Rotated_Sorted_Array
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (1 != FindMin(new int[] { 3, 4, 5, 1, 2 }))
				throw new InvalidOperationException();
			if (0 != FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 }))
				throw new InvalidOperationException();
			if (11 != FindMin(new int[] { 11, 13, 15, 17 }))
				throw new InvalidOperationException();
		}

		public static int FindMin(int[] nums)
		{
			int res = nums[0];

			int leftIdx = 0;
			int rightIdx = nums.Length - 1;

			while (leftIdx <= rightIdx)
			{
				if (nums[leftIdx] < nums[rightIdx])
				{
					res = Math.Min(res, nums[leftIdx]);
					break;
				}

				int midIdx = (leftIdx + rightIdx) / 2;

				res = Math.Min(res, nums[midIdx]);
				if (nums[midIdx] >= nums[leftIdx])
				{
					leftIdx = midIdx + 1;
				}
				else
				{
					rightIdx = midIdx - 1;
				}

			}

			return res;


		}
	}
}
