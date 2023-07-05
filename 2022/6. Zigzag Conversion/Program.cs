using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.Zigzag_Conversion
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine(Convert("AB", 1));
			Console.WriteLine(Convert("PAYPALISHIRING", 3));
			Console.WriteLine(Convert("PAYPALISHIRING", 4));
		}


		/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number 
of rows like this: (you may want to display this pattern in a fixed font 
for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
		 */

		enum Heading
		{
			Unknown = 0,
			South,
			NorthEast,
			East
		};

		public static string Convert(string s, int numRows, bool display = false)
		{
			StringBuilder[] rows = new StringBuilder[numRows];

			for (int i = 0; i < numRows; i++)
				rows[i] = new StringBuilder();


			Heading heading = numRows == 1 ? Heading.East : Heading.South;
			int curRow = 0;

			foreach (char c in s)
			{
				rows[curRow].Append(c);

				// Update future coordinates
				switch (heading)
				{
					case Heading.East:
						// Do nothing we'll just keep appending to the same line.
						break;	
					case Heading.South:

						// Change heading if we're at the end.
						if (curRow == numRows - 1)
						{
							// Since we are currently on the last line, append
							// a space to the current line and set the cursor above.
							curRow--;
							heading = Heading.NorthEast;
						}
						else // go one to the south
						{
							curRow++;
						}

						break;
					case Heading.NorthEast:

						
						// Change heading if we're at the start.
						if (curRow == 0)
						{
							curRow++;
							heading = Heading.South;
						}
						else
						{
							// Go through the rest of the columns, put
							// spaces in if they aren't the current one.
							if (display)
								for (int i = 0; i < numRows; i++)
								{
									if (i == curRow)
										continue;

									rows[i].Append(' ');
								}

							curRow--;

							
						}


						break;
					default:
						throw new InvalidOperationException();
				}
				
			}

			StringBuilder combined = new();
			if (display)
			{
				foreach (StringBuilder row in rows)
					combined.AppendLine(row.ToString());
			}
			else
			{
				foreach (StringBuilder row in rows)
					combined.Append(row.ToString());
			}

			string result = combined.ToString();

			return result;
		}



	}
}
