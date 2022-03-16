using System;
using System.Collections.Generic;
using System.Linq;

namespace _0121.Best_Time_to_Buy_and_Sell_Stock
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var a1 = MaxProfit(new int[] { 3, 3 });
			if (5 != MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }))
				throw new InvalidOperationException();
			if (0 != MaxProfit(new int[] { 7, 6, 4, 3, 1 }))
				throw new InvalidOperationException();
			
		}

		// Runtime: 334 ms, faster than 56.54% of C# online submissions for Best Time to Buy and Sell Stock.
		// Memory Usage: 47.3 MB, less than 32.90% of C# online submissions for Best Time to Buy and Sell Stock.
		public static int MaxProfit(int[] prices)
		{
			int finalLeft = -1;
			int finalRight = -1;
			
			// Work with temp variables so that we can keep less than ideal solutions longer.
			int prospectiveLeft = -1;
			int prospectiveRight = -1;

			for (int i = 0; i < prices.Length; i++)
			{
				// best time to buy
				if (prospectiveLeft == -1)
				{
					prospectiveLeft = i;
					prospectiveRight = -1;
					continue;
				}

				if (prices[i] < prices[prospectiveLeft])
				{
					prospectiveLeft = i;
					prospectiveRight = -1;
					continue;
				}

				// best time to sell
				if (
					prices[i] > prices[prospectiveLeft] &&
					(prospectiveRight == -1 || prices[i] > prices[prospectiveRight])
					)
				{
					prospectiveRight = i;
				}

				if (prospectiveRight == -1)
					continue;

				int bestSoFarProfit = -1;
				if (finalLeft != -1 && finalRight != -1)
					bestSoFarProfit = prices[finalRight] - prices[finalLeft];

				int prospectiveProfit = prices[prospectiveRight] - prices[prospectiveLeft];

				if (prospectiveProfit > bestSoFarProfit)
				{
					finalLeft = prospectiveLeft;
					finalRight = prospectiveRight;
				}

			}

			int finalProfit = -1;
			if (finalLeft != -1 && finalRight != -1)
				finalProfit = prices[finalRight] - prices[finalLeft];

			if (finalProfit == -1)
				return 0;

			return prices[finalRight] - prices[finalLeft];
		}
	}
}
