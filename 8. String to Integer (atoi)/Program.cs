using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.String_to_Integer__atoi_
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (MyAtoi("-5-") != -5)
				throw new InvalidOperationException();
			if (MyAtoi("2147483648") != 2147483647)
				throw new InvalidOperationException();
			if (MyAtoi("2147483646") != 2147483646)
				throw new InvalidOperationException();

			



			if (MyAtoi("00000-42a1234") != 0)
				throw new InvalidOperationException();
			if (MyAtoi("+-12") != 0)
				throw new InvalidOperationException();
			
			if (MyAtoi("-2147483650") != int.MinValue)
				throw new InvalidOperationException();
			if (MyAtoi("42") != 42)
				throw new InvalidOperationException();
			if (MyAtoi("-42") != -42)
				throw new InvalidOperationException();
			if (MyAtoi("4193 with words") != 4193)
				throw new InvalidOperationException();
		}

		//Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer(similar to C/C++'s atoi function).

		//The algorithm for myAtoi(string s) is as follows:

		//Read in and ignore any leading whitespace.
		//Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either.This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
		//Read in next the characters until the next non-digit character or the end of the input is reached.The rest of the string is ignored.
		//Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
		//If the integer is out of the 32-bit signed integer range[-231, 231 - 1], then clamp the integer so that it remains in the range.Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
		//Return the integer as the final result.
		//Note:


		//Only the space character ' ' is considered a whitespace character.
		//Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.



		//Example 1:


		//Input: s = "42"
		//Output: 42
		//Explanation: The underlined characters are what is read in, the caret is the current reader position.
		//Step 1: "42" (no characters read because there is no leading whitespace)
		//         ^
		//Step 2: "42" (no characters read because there is neither a '-' nor '+')
		//         ^
		//Step 3: "42" ("42" is read in)
		//           ^
		//The parsed integer is 42.
		//Since 42 is in the range[-231, 231 - 1], the final result is 42.
		//Example 2:

		//Input: s = "   -42"
		//Output: -42
		//Explanation:
		//Step 1: "   -42" (leading whitespace is read and ignored)
		//            ^
		//Step 2: "   -42" ('-' is read, so the result should be negative)
		//             ^
		//Step 3: "   -42" ("42" is read in)
		//               ^
		//The parsed integer is -42.
		//Since -42 is in the range[-231, 231 - 1], the final result is -42.
		//Example 3:

		//Input: s = "4193 with words"
		//Output: 4193
		//Explanation:
		//Step 1: "4193 with words" (no characters read because there is no leading whitespace)
		//         ^
		//Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
		//         ^
		//Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
		//             ^
		//The parsed integer is 4193.
		//Since 4193 is in the range[-231, 231 - 1], the final result is 4193.



		//Constraints:

		//0 <= s.length <= 200
		//s consists of English letters(lower-case and upper-case), digits(0-9), ' ', '+', '-', and '.'.
		//Accepted
		//953,961
		//Sub


		// Runtime: 106 ms, faster than 43.15% of C# online submissions for String to Integer (atoi).
		// Memory Usage: 38 MB, less than 31.09% of C# online submissions for String to Integer (atoi).
		public static int MyAtoi(string s)
		{
			if (s == "2147483648")
				Console.WriteLine();
			
			
			// Read in and ignore any leading whitespace.

			// Check if the next character (if not already
			// at the end of the string) is '-' or '+'. Read
			// this character in if it is either.This determines
			// if the final result is negative or positive respectively.
			// Assume the result is positive if neither is present.

			// Read in next the characters until the next non-digit
			// character or the end of the input is reached.The rest
			// of the string is ignored.

			// First pass to extract number.
			bool initialWhitespace = true;
			bool? positive = null;
			List<char> chars = new();
			foreach(char c in s)
			{
				bool done = false;
				switch (c)
				{
					case ' ':
						if (!initialWhitespace)
							done = true;
						break;
					case '+':
						if (positive != null)
						{
							done = true;
							break;
						}
						positive = true;
						initialWhitespace = false;
						break;
					case '-':
						if (positive != null)
						{
							done = true;
							break;
						}
						positive = false;
						initialWhitespace = false;
						break;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						if (positive == null)
							positive = true;
						chars.Add(c);
						initialWhitespace = false;
						break;
					default:
						initialWhitespace = false;
						done = true;
						break;
				}
				if (done)
					break;
			}

			// Convert these digits into an integer (i.e. "123" -> 123,
			// "0032" -> 32). If no digits were read, then the integer
			// is 0. Change the sign as necessary (from step 2).

			int parsed = 0;

			foreach (char c in chars)
			{
				int firstDigitPlace;
				switch (c)
				{
					case '0':
						firstDigitPlace = 0;
						break;
					case '1':
						firstDigitPlace = 1;
						break;
					case '2':
						firstDigitPlace = 2;
						break;
					case '3':
						firstDigitPlace = 3;
						break;
					case '4':
						firstDigitPlace = 4;
						break;
					case '5':
						firstDigitPlace = 5;
						break;
					case '6':
						firstDigitPlace = 6;
						break;
					case '7':
						firstDigitPlace = 7;
						break;
					case '8':
						firstDigitPlace = 8;
						break;
					case '9':
						firstDigitPlace = 9;
						break;
					default:
						throw new InvalidOperationException();
				}

				// If the integer is out of the 32-bit signed integer
				// range[-2^31, 2^31 - 1], then clamp the integer so
				// that it remains in the range.Specifically, integers
				// less than -2^31 should be clamped to -2^31, and integers
				// greater than 2^31 - 1 should be clamped to 2^31 - 1.

				try
				{
					checked
					{
						if (parsed != 0)
							parsed *= 10;

						parsed += firstDigitPlace;
					}
				}
				catch (OverflowException)
				{
					int result = 0;

					if (positive == null || positive.Value == true)
						result = int.MaxValue;
					else
						result = int.MinValue;

					return result;
				}
			}

			if (positive != null && positive.Value == false)
				parsed *= -1;

			

			


			// Return the integer as the final result.


			return parsed;



		}
	}
}
