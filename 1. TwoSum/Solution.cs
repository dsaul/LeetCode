using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
	internal class Solution
	{
		public static int[] TwoSumBruteForce(int[] nums, int target)
		{
			//Input: nums = [2,7,11,15], target = 9
			//Output: [0,1]
			//Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].


			int[] ret = new int[] { -1, -1 };

			for (int i=0; i<nums.Length; i++)
			{
				for (int j=nums.Length-1; j>=0; j--)
				{
					if (j == i)
						continue;

					if (nums[j] + nums[i] == target)
					{
						ret = new int[] { j, i };
						break;
					}

				}
			}

			return ret;
		}

		public static int[]? TwoSumHashTable(int[] nums, int target)
		{
			int[]? ret = null;

			// nums val as dict key, nums index as dict value
			Dictionary<int, int> map = new();

			for (int i=0; i<nums.Length; i++)
			{
				map[nums[i]] = i;
			}

			//Then, in the second iteration, we check if each element's complement
			//(target - nums[i]target−nums[i]) exists in the hash table. If it does
			//exist, we return current element's index and its complement's index.
			//Beware that the complement must not be nums[i]nums[i] itself!

			for(int i=0; i<nums.Length; i++)
			{
				var targetComplement = target - nums[i];
				if (map.ContainsKey(targetComplement) && map[targetComplement] != i)
				{
					ret = new int[] { i, map[targetComplement] };
					break;
				}
			}

			return ret;

		}



	}
}
