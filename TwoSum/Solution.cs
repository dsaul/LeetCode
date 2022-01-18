using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
	internal class Solution
	{
		public static int[] TwoSum(int[] nums, int target)
		{
			int[] work = new int[nums.Length];
			Array.Copy(nums, work, nums.Length);
			Array.Sort(work);

			int? idxBig = null;


			for (int i = work.Length-1; i >= 0; i--)
			{
				if (work[i] > target)
					continue;
				if (null == idxBig && work[i] <= target)
				{
					idxBig = i;
					continue;
				}

				if (null == idxBig) // this should never be hit.
					throw new InvalidOperationException();

				if (work[i] + work[idxBig.Value] == target)
				{
					return new int[] { Array.IndexOf(nums,work[i]), Array.IndexOf(nums, work[idxBig.Value]) };
				}

				// If we get to this point, reset the big index to null and the index to one under the big index.
				if (i == 0)
				{
					i = idxBig.Value - 1;
					idxBig = null;
				}
			}

			return new int[] { };

		}
	}
}
