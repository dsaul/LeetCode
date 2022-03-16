using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0014.Longest_Common_Prefix
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (LongestCommonPrefix(new string[] { "cir", "car" }) != "c")
				throw new InvalidOperationException();
			if (LongestCommonPrefix(new string[] { "flower", "flow", "flight" }) != "fl")
				throw new InvalidOperationException();
			if (LongestCommonPrefix(new string[] { "dog", "racecar", "car" }) != "")
				throw new InvalidOperationException();
		}

		// Runtime: 88 ms, faster than 96.95% of C# online submissions for Longest Common Prefix.
		// Memory Usage: 39.8 MB, less than 21.67% of C# online submissions for Longest Common Prefix.
		public static string LongestCommonPrefix(string[] strs)
		{
			StringBuilder sb = new StringBuilder();

			int shortLen = int.MaxValue;

			// get shortest length
			foreach (string str in strs)
				if (str.Length < shortLen)
					shortLen = str.Length;

			for (int i=0; i<shortLen; i++)
			{
				char? c = null;
				bool matches = true;
				foreach (string str in strs)
				{
					if (c == null)
					{
						c = str[i];
					}
					else if (c.Value != str[i])
					{
						matches = false;
						break;
					}
				}

				if (null != c && true == matches)
					sb.Append(c.Value);
				if (false == matches)
					break;

			}


			string ret = sb.ToString();
			return ret;
		}
	}
}
