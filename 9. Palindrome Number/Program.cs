using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Palindrome_Number
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (IsPalindrome(69752) != false)
				throw new InvalidOperationException();
			if (IsPalindrome(121) != true)
				throw new InvalidOperationException();
			if (IsPalindrome(-121) != false)
				throw new InvalidOperationException();
			if (IsPalindrome(10) != false)
				throw new InvalidOperationException();
		}

		// Runtime: 76 ms, faster than 45.24% of C# online submissions for Palindrome Number.
		// Memory Usage: 29.4 MB, less than 30.95% of C# online submissions for Palindrome Number.
		public static bool IsPalindrome(int x)
		{
			if (x < 0)
				return false;

			// decompose integer
			List<int> digits = new();

			{
				int i = x;
				while (i > 9)
				{
					digits.Insert(0, i % 10);

					i /= 10;
				}
				digits.Insert(0, i);
			}

			// determine if palindrome
			int digCount = digits.Count;

			for (int i = 0, j = digCount - 1; i < (digCount / 2); i++, j--)
			{
				int left = digits[i];
				int right = digits[j];
				if (left == right)
					continue;
				return false;
			}

			return true;

		}

		
	}
}
