using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _4.Median_of_Two_Sorted_Arrays
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }) != 2.0)
				throw new InvalidOperationException();
			if (FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }) != 2.0)
				throw new InvalidOperationException();
		}

		/*
Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
		 * */

		public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			List<int> combined = new List<int>();
			combined.AddRange(nums1);
			combined.AddRange(nums2);

			combined.Sort();

			int count = combined.Count;
			int halfRemainder = count % 2;
			if (halfRemainder == 1)
			{
				double result = combined[count / 2];

				return result;
			}
			else
			{
				int idxA = (int)Math.Ceiling(count / 2d);
				int a = combined[idxA];
				int idxB = idxA - 1;
				int b = combined[idxB];

				double result = (a + b) / 2d;

				return result;
			}
		}
	}
}
