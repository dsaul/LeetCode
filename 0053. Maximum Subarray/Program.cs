using System;
using System.Collections.Generic;
using System.Linq;

namespace _0053.Maximum_Subarray
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (6 != MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }))
				throw new InvalidOperationException();
			if (1 != MaxSubArray(new int[] { 1 }))
				throw new InvalidOperationException();
			if (23 != MaxSubArray(new int[] { 5, 4, -1, 7, 8 }))
				throw new InvalidOperationException();
		}

		//Runtime: 192 ms, faster than 89.71% of C# online submissions for Maximum Subarray.
		//Memory Usage: 48.9 MB, less than 44.16% of C# online submissions for Maximum Subarray.
		public static int MaxSubArray(int[] nums)
		{
			//int maxWindowLeft = -1;
			//int maxWindowRight = -1;
			int maxWindowSum = int.MinValue;

			int curWindowLeft = -1;
			int curWindowRight = -1;
			int curWindowSum = int.MinValue;

			//-2, 1, -3, 4, -1, 2, 1, -5, 4
			for (int i = 0; i < nums.Length; i++)
			{
				int num = nums[i];
				
				// If we don't have a left window at all, take this to be the start.
				if (
					// reset if we haven't started
					curWindowLeft == -1 ||

					// reset if the window is negative and we have a value that is larger.
					(curWindowSum < 0 && num > curWindowSum)
					)
				 {
					curWindowLeft = i;
					curWindowRight = i;
					curWindowSum = num;
					goto updateMaxIfLarger;
				}

				
				curWindowRight++;
				curWindowSum += num;

			updateMaxIfLarger:

				if (curWindowSum > maxWindowSum)
				{
					//maxWindowLeft = curWindowLeft;
					//maxWindowRight = curWindowRight;
					maxWindowSum = curWindowSum;
				}

			}


			return maxWindowSum;
		}
	}
}
