using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Longest_Palindromic_Substring
{
	public class Program
	{

		// Given a string s, return the longest palindromic substring in s.

		// Example 1:

		// Input: s = "babad"
		// Output: "bab"
		// Explanation: "aba" is also a valid answer.
		// Example 2:

		// Input: s = "cbbd"
		// Output: "bb"

		// Constraints:

		// 1 <= s.length <= 1000
		// s consist of only digits and English letters.


		public static void Main(string[] args)
		{
			if ("bab" != LongestPalindrome("babad"))
				throw new InvalidOperationException();
			if ("bb" != LongestPalindrome("cbbd"))
				throw new InvalidOperationException();
		}

		public static string LongestPalindrome(string s)
		{
			int len = s.Length;

			string longestPalindrome = "";

			for (int windowStart = 0; windowStart < len; windowStart++)
			{
				for (int windowEnd = len; windowEnd != windowStart; windowEnd--)
				{
					string sub = s.Substring(windowStart, windowEnd - windowStart);
					bool isPalindrome = IsPalindrome(sub);


					if (isPalindrome)
					{
						if (sub.Length > longestPalindrome.Length)
							longestPalindrome = sub;
					}

					if ((windowEnd - windowStart) < longestPalindrome.Length)
						break;
				}
			}

			return longestPalindrome;
		}

		public static bool IsPalindrome(string s)
		{
			bool result = true;
			int len = s.Length;

			for (int i = 0, j = len - 1; i < (len / 2); i++, j--)
			{
				if (s[i] != s[j])
				{
					result = false;
					break;
				}
			}

			return result;
		}



	}
}
