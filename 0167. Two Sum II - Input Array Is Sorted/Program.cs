using System;
using System.Collections.Generic;
using System.Linq;

namespace _0167.Two_Sum_II___Input_Array_Is_Sorted
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var a4 = TwoSum(new int[] { 12, 13, 23, 28, 43, 44, 59, 60, 61, 68, 70, 86, 88, 92, 124, 125, 136, 168, 173, 173, 180, 199, 212, 221, 227, 230, 277, 282, 306, 314, 316, 321, 325, 328, 336, 337, 363, 365, 368, 370, 370, 371, 375, 384, 387, 394, 400, 404, 414, 422, 422, 427, 430, 435, 457, 493, 506, 527, 531, 538, 541, 546, 568, 583, 585, 587, 650, 652, 677, 691, 730, 737, 740, 751, 755, 764, 778, 783, 785, 789, 794, 803, 809, 815, 847, 858, 863, 863, 874, 887, 896, 916, 920, 926, 927, 930, 933, 957, 981, 997 }, 542);
			var a1 = TwoSum(new int[] { -3, 3, 4, 90 }, 0);
			var a2 = TwoSum(new int[] { -1, 0 }, -1);
			var a3 = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
		}

		// Runtime: 288 ms, faster than 17.65% of C# online submissions for Two Sum II - Input Array Is Sorted.
		// Memory Usage: 45.6 MB, less than 15.13% of C# online submissions for Two Sum II - Input Array Is Sorted.
		public static int[] TwoSum(int[] numbers, int target)
		{
			// Key is number, value is index
			Dictionary<int, List<int>> compliments = new Dictionary<int, List<int>>();
			
			int[]? ret = null;

			for (int i=0; i<numbers.Length; i++)
			{
				int possibleNumber = numbers[i];

				int possibleComplement = target - possibleNumber;

				if (compliments.ContainsKey(possibleComplement))
				{
					ret = new int[2] { compliments[possibleComplement].First() + 1, i +1 };
				}

				if (!compliments.ContainsKey(possibleNumber))
					compliments[possibleNumber] = new List<int>();
				compliments[possibleNumber].Add(i);

				if (ret != null)
					break;
			}

			if (ret == null)
				return new int[] { -1, -1 };
			return ret; 
		}
	}
}
