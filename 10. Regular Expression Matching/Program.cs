using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Regular_Expression_Matching
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (IsMatchBruteForce("a", ".*..a*") != true)
				throw new InvalidOperationException();
			if (IsMatchBruteForce("aaa", "a*a") != true)
				throw new InvalidOperationException();
			if (IsMatchBruteForce("aa", ".*") != true)
				throw new InvalidOperationException();
			if (IsMatchBruteForce("aa", "a*") != true)
				throw new InvalidOperationException();
			if (IsMatchBruteForce("aa", "a") != false)
				throw new InvalidOperationException();
			if (IsMatchBruteForce("aa", "aa") != true)
				throw new InvalidOperationException();
		}

		public static bool IsMatchBruteForce(
			string s, // string
			string p  // pattern
			)
		{

			bool Recursive(int stringPos, int patternPos)
			{
				char? strChar = stringPos >= s.Length ? null : s[stringPos];
				char? patChar = patternPos >= p.Length ? null : p[patternPos];

				// If the pattern is done, but the string has more characters, we don't match.
				if (patChar == null && strChar != null)
					return false;

				// If both characters are null, we've reached the end of the string as well as the pattern.
				if (patChar == null && strChar == null)
					return true;

				bool isWildcard = false;

				if (patternPos + 1 <= p.Length - 1 && p[patternPos + 1] == '*')
					isWildcard = true;

				// If it isn't a wildcard, see if the current character matches,
				// then move the string and pattern pointers over one.
				if (!isWildcard)
				{
					if (patChar != '.' && strChar != patChar)
						return false;

					bool match = Recursive(stringPos + 1, patternPos + 1);

					return match;
				}
				// If it is a wildcard check current character, if it matches then
				// move the string pointer forward, but leave the pattern pointer alone.
				else
				{
					// There are two ways we could go forward, consuming a, or not
					// consuming a. We need to check for both in cases such as a*a .
					
					// Assuming we don't consume a character, we consume the
					// pattern and leave the string alone.
					bool consumeNoStringCharsMatch = Recursive(stringPos, patternPos + 2);

					bool consumeStringCharactersMatch;

					// If the characters match, consume string character and leave the pattern pointer alone.
					if (patChar == '.' || strChar == patChar)
					{
						// Check ahead and see if the next character matches,
						// if it does consume the sting character, if it
						// doesn't consume the string and pattern.
						char? nextCharacter = stringPos + 1 <= s.Length - 1 ? s[stringPos + 1] : null;
						if (
							nextCharacter != null &&
							patChar == '.' || nextCharacter == patChar
							)
						{
							consumeStringCharactersMatch = Recursive(stringPos + 1, patternPos);
						}
						else
						{
							consumeStringCharactersMatch = Recursive(stringPos + 1, patternPos + 2);
						}

						
					}
					// If the characters don't match, wildcards can match zero, so move the pattern forward 2.
					else
					{
						consumeStringCharactersMatch = Recursive(stringPos, patternPos + 2);
					}



					return consumeNoStringCharsMatch || consumeStringCharactersMatch;
				}


				
				


			}


			return Recursive(0, 0);
		}
	}
}
