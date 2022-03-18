using System;
using System.Collections.Generic;
using System.Linq;

namespace _0152.Maximum_Product_Subarray
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (6 != MaxProduct(new int[] { 2, 3, -2, 4 }))
				throw new InvalidOperationException();
			if (0 != MaxProduct(new int[] { -2, 0, -1 }))
				throw new InvalidOperationException();
		}

		public static int MaxProduct(int[] nums)
		{
			int result = nums.Max();
			int curMin = 1;
			int curMax = 1;

			// 2, 3, -2, 4
			for (int i = 0; i < nums.Length; i++)
			{
				int num = nums[i];

				if (num == 0)
				{
					curMin = 1;
					curMax = 1;
					continue;
				}

				var possibleMins = new int[] { num * curMax, num * curMin, num };
				var possibleMaxes = new int[] { num * curMax, num * curMin, num };

				curMin = possibleMins.Min();
				curMax = possibleMaxes.Max();
				

				result = new int[] { result, curMin, curMax }.Max();
			}

			return result;
		}
	}
}
