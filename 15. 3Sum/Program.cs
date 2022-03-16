using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._3Sum
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var a3 = ThreeSum(new int[] { 0, 0, 0 });
			var a2 = ThreeSum(new int[] { -3, 3, 4, -3, 1, 2 });
			var a1 = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
		}

		// Runtime: 185 ms, faster than 87.54% of C# online submissions for 3Sum.
		// Memory Usage: 47 MB, less than 78.42% of C# online submissions for 3Sum.
		public static IList<IList<int>> ThreeSum(int[] nums)
		{
			List<IList<int>> list = new List<IList<int>>();
			
			Array.Sort(nums);

			// We need to find A,B,C
			

			// For a, because there are no duplicates, we don't want to start with the same number.
			for (int idxA = 0; idxA < nums.Length; idxA++)
			{
				// skip if previous number was the same
				if (idxA > 0 && nums[idxA - 1] == nums[idxA])
					continue;

				// Now we need to use pointers to find the next two numbers.
				int leftIdx = idxA + 1;
				int rightIdx = nums.Length - 1;

				while (leftIdx < rightIdx)
				{
					int sum = nums[idxA] + nums[leftIdx] + nums[rightIdx];

					if (sum > 0) // too big
					{
						rightIdx--;
					}
					else if (sum < 0) // too small
					{
						leftIdx++;
					}
					else // just right
					{
						int numB = nums[leftIdx];


						list.Add(new int[3] { nums[idxA], numB, nums[rightIdx] });

						while (leftIdx < rightIdx && nums[leftIdx] == numB)
							leftIdx++;



					}
				}
			}

			return list;
		}
	}
}
