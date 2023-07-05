using System;
using System.Collections.Generic;
using System.Linq;

namespace _0013.Roman_to_Integer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (RomanToInt("MCMXCIV") != 1994)
				throw new InvalidOperationException();
			if (RomanToInt("III") != 3)
				throw new InvalidOperationException();
			if (RomanToInt("LVIII") != 58) 
				throw new InvalidOperationException();
			
		}

		/*
		Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

		Symbol Value
		I             1
		V             5
		X             10
		L             50
		C             100
		D             500
		M             1000
		For example, 2 is written as II in Roman numeral, just two one's added together. 
		12 is written as XII, which is simply X + II. The number 27 is written as XXVII, 
		which is XX + V + II.

		Roman numerals are usually written largest to smallest from left to right.
		However, the numeral for four is not IIII. Instead, the number four is written 
		as IV.Because the one is before the five we subtract it making four. The same 
		principle applies to the number nine, which is written as IX.There are six 
		instances where subtraction is used:

		I can be placed before V (5) and X(10) to make 4 and 9. 
		X can be placed before L(50) and C(100) to make 40 and 90. 
		C can be placed before D(500) and M(1000) to make 400 and 900.
		Given a roman numeral, convert it to an integer.



		Example 1:

		Input: s = "III"
		Output: 3
		Explanation: III = 3.
		Example 2:

		Input: s = "LVIII"
		Output: 58
		Explanation: L = 50, V= 5, III = 3.
		Example 3:

		Input: s = "MCMXCIV"
		Output: 1994
		Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
		*/

		//Runtime: 76 ms, faster than 85.25% of C# online submissions for Roman to Integer.
		//Memory Usage: 40.2 MB, less than 12.81% of C# online submissions for Roman to Integer.

		public static int RomanToInt(string s)
		{
			// Symbol Value
			// I             1
			// V             5
			// X             10
			// L             50
			// C             100
			// D             500
			// M             1000

			int total = 0;

			for (int i = 0; i < s.Length; i++)
			{
				int tmp = 0;
				
				switch (s[i])
				{
					case 'M':
						tmp = 1000;
						break;
					case 'D':
						tmp = 500;
						break;
					case 'C':
						tmp = 100;

						// If we aren't at the end of the string, check the next character.
						if (i+1 != s.Length)
						{
							switch (s[i + 1])
							{
								case 'M':
								case 'D':
									tmp *= -1;
									break;
							}
						}


						break;
					case 'L':
						tmp = 50;
						break;
					case 'X':
						tmp = 10;

						// If we aren't at the end of the string, check the next character.
						if (i + 1 != s.Length)
						{
							switch (s[i + 1])
							{
								case 'L':
								case 'C':
									tmp *= -1;
									break;
							}
						}

						break;
					case 'V':
						tmp = 5;
						break;
					case 'I':
						tmp = 1;

						// If we aren't at the end of the string, check the next character.
						if (i + 1 != s.Length)
						{
							switch (s[i + 1])
							{
								case 'V':
								case 'X':
									tmp *= -1;
									break;
							}
						}

						break;
					default:

						break;
				}

				total += tmp;
			}


			return total;
		}
	}
}
