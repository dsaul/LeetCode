using System;
using System.Collections.Generic;
using System.Linq;

namespace _0217.Contains_Duplicate
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (true != ContainsDuplicate(new int[] { 1, 2, 3, 1 }))
				throw new InvalidOperationException();
			if (false != ContainsDuplicate(new int[] { 1, 2, 3, 4 }))
				throw new InvalidOperationException();
			if (true != ContainsDuplicate(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }))
				throw new InvalidOperationException();
		}

		public static bool ContainsDuplicate(int[] nums)
		{
			HashSet<int> set = new HashSet<int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (set.Contains(nums[i]))
					return true;

				set.Add(nums[i]);
			}
			return false;
		}
	}
}
