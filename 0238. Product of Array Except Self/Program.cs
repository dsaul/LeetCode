using System;
using System.Collections.Generic;
using System.Linq;

namespace _0238.Product_of_Array_Except_Self
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var res1 = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
			var res2 = ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 });
		}

		public static int[] ProductExceptSelf(int[] nums)
		{
			int[] prefix = new int[nums.Length];
			int[] postfix = new int[nums.Length];
			int[] result = new int[nums.Length];

			int pre = 1;
			int post = 1;

			// calculate the prefixes and the postfixes.
			for (int i = 0, j = nums.Length - 1; i < nums.Length; i++, j--)
			{
				// Prefix
				pre *= nums[i];
				prefix[i] = pre;

				// Postfix
				post *= nums[j];
				postfix[j] = post;
			}

			// Create final result.
			for (int i = 0; i < nums.Length; i++)
			{
				int left = (i - 1) < 0 ? 1 : prefix[i - 1];
				int right = (i + 1) >= nums.Length ? 1 : postfix[i + 1];

				result[i] = left * right;
			}


			return result;
		}
	}
}
