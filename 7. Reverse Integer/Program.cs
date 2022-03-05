using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleClassic1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (Reverse(123) != 321)
				throw new InvalidOperationException();
			if (Reverse(-123) != -321)
				throw new InvalidOperationException();
			if (Reverse(120) != 21)
				throw new InvalidOperationException();
		}



		/*
Given a signed 32-bit integer x, return x with 
its digits reversed. If reversing x causes the 
value to go outside the signed 32-bit integer 
range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 
64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
		*/

		public static int Reverse(int x)
		{
			bool isNegative = x < 0;

			int xAbs = Math.Abs(x);

			string xs = x.ToString();
			string xsr = new string(x.ToString().Reverse().ToArray());

			int res = int.Parse(xsr);
			if (isNegative)
				res *= -1;
			return res;
			
		}
	}
}
