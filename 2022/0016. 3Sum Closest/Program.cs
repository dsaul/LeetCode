using System;
using System.Collections.Generic;
using System.Linq;

namespace _0016._3Sum_Closest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1) != 2)
				throw new InvalidOperationException();
			if (ThreeSumClosest(new int[] { 0, 0, 0 }, 1) != 0)
				throw new InvalidOperationException();
		}

		public static int ThreeSumClosest(int[] nums, int target)
		{
			Array.Sort(nums);

			// we need to find a,b,c, where the sum is closest to the target

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


						//list.Add(new int[3] { nums[idxA], numB, nums[rightIdx] });

						while (leftIdx < rightIdx && nums[leftIdx] == numB)
							leftIdx++;



					}
				}
			}
		}

	}
}
