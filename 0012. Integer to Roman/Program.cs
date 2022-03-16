using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0012.Integer_to_Roman
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (IntToRoman(1994) != "MCMXCIV")
				throw new InvalidOperationException();
			if (IntToRoman(3) != "III")
				throw new InvalidOperationException();
			if (IntToRoman(58) != "LVIII")
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
		For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

		Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:

		I can be placed before V (5) and X(10) to make 4 and 9. 
		X can be placed before L(50) and C(100) to make 40 and 90. 
		C can be placed before D(500) and M(1000) to make 400 and 900.
		Given an integer, convert it to a roman numeral.



		Example 1:

		Input: num = 3
		Output: "III"
		Explanation: 3 is represented as 3 ones.
		Example 2:

		Input: num = 58
		Output: "LVIII"
		Explanation: L = 50, V = 5, III = 3.
		Example 3:

		Input: num = 1994
		Output: "MCMXCIV"
		Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
		*/

		//Runtime: 73 ms, faster than 88.58% of C# online submissions for Integer to Roman.
		//Memory Usage: 37.7 MB, less than 64.39% of C# online submissions for Integer to Roman.

		public static string IntToRoman(int num)
		{
			if (num > 3999 || num < 1)
				throw new InvalidOperationException();

			StringBuilder sb = new();

			int remainder = num;

			string ret;

			while (remainder != 0)
			{
				switch (remainder)
				{
					case int i when i >= 1000 && i <= 3999:
						sb.Append("M");
						remainder -= 1000;
						break;
					case int i when i >= 900 && i <= 999:
						sb.Append("CM");
						remainder -= 900;
						break;
					case int i when i >= 800 && i <= 899:
						sb.Append("DCCC");
						remainder -= 800;
						break;
					case int i when i >= 700 && i <= 799:
						sb.Append("DCC");
						remainder -= 700;
						break;
					case int i when i >= 600 && i <= 699:
						sb.Append("DC");
						remainder -= 600;
						break;
					case int i when i >= 500 && i <= 599:
						sb.Append("D");
						remainder -= 500;
						break;
					case int i when i >= 400 && i <= 499:
						sb.Append("CD");
						remainder -= 400;
						break;
					case int i when i >= 100 && i <= 399:
						sb.Append("C");
						remainder -= 100;
						break;
					case int i when i >= 90 && i <= 99:
						sb.Append("XC");
						remainder -= 90;
						break;
					case int i when i >= 80 && i <= 89:
						sb.Append("LXXX");
						remainder -= 80;
						break;
					case int i when i >= 70 && i <= 79:
						sb.Append("LXX");
						remainder -= 70;
						break;
					case int i when i >= 60 && i <= 69:
						sb.Append("LX");
						remainder -= 60;
						break;
					case int i when i >= 50 && i <= 59:
						sb.Append("L");
						remainder -= 50;
						break;
					case int i when i >= 40 && i <= 49:
						sb.Append("XL");
						remainder -= 40;
						break;
					case int i when i >= 10 && i <= 39:
						sb.Append("X");
						remainder -= 10;
						break;
					case int i when i == 9:
						sb.Append("IX");
						remainder -= 9;
						break;
					case int i when i == 8:
						sb.Append("VIII");
						remainder -= 8;
						break;
					case int i when i == 7:
						sb.Append("VII");
						remainder -= 7;
						break;
					case int i when i == 6:
						sb.Append("VI");
						remainder -= 6;
						break;
					case int i when i == 5:
						sb.Append("V");
						remainder -= 5;
						break;
					case int i when i == 4:
						sb.Append("IV");
						remainder -= 4;
						break;
					case int i when i >= 1 && i <= 3:
						sb.Append("I");
						remainder -= 1;
						break;
				}

			}

			ret = sb.ToString();

			return ret;
		}
	}
}
