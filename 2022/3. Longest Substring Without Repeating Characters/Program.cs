using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _3.Longest_Substring_Without_Repeating_Characters
{
	public class Program
	{
		public static void Main(string[] args)
		{

			
			Debug.Assert(LengthOfLongestSubstring("dvdf") == 3);
			Debug.Assert(LengthOfLongestSubstring("abcabcbb") == 3);
			Debug.Assert(LengthOfLongestSubstring("bbbbb") == 1);
			Debug.Assert(LengthOfLongestSubstring("pwwkew") == 3);
		}

		/*
Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
		*/

		public static int LengthOfLongestSubstring(string s)
		{
			HashSet<char> usedChars = new();

			int largest = 0;
			int curCount = 0;

			for (int i=0; i<s.Length; i++)
			{
				char c = s[i];

				if (usedChars.Contains(c))
				{
					curCount = 0;
					usedChars = new();

					// rewind to previous instance of c if it exists.
					int lastIdx = s.LastIndexOf(c, i-1);
					i = lastIdx; // will be incremented by the for loop
					continue;
				}

				usedChars.Add(c);
				curCount++;

				if (largest < curCount)
					largest = curCount;

			}

			return largest;
		}
	}
}
