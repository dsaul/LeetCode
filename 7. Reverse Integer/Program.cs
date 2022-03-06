using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleClassic1
{
	//[MemoryDiagnoser]
	public class Benchmark
	{
		[Benchmark]
		public void RunReverseUsingMath()
		{
			if (Program.ReverseUsingMath(-1463847412) != -2147483641)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(1463847412) != 2147483641)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(123) != 321)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(-123) != -321)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(120) != 21)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(-2147483648) != 0)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(1534236469) != 0)
				throw new InvalidOperationException();
		}

		[Benchmark]
		public void ReverseUsingStringsJustInt()
		{
			if (Program.ReverseUsingMath(-1463847412) != -2147483641)
				throw new InvalidOperationException();
			if (Program.ReverseUsingMath(1463847412) != 2147483641)
				throw new InvalidOperationException();
			if (Program.ReverseUsingStringsJustInt(123) != 321)
				throw new InvalidOperationException();
			if (Program.ReverseUsingStringsJustInt(-123) != -321)
				throw new InvalidOperationException();
			if (Program.ReverseUsingStringsJustInt(120) != 21)
				throw new InvalidOperationException();
			if (Program.ReverseUsingStringsJustInt(-2147483648) != 0)
				throw new InvalidOperationException();
			if (Program.ReverseUsingStringsJustInt(1534236469) != 0)
				throw new InvalidOperationException();
		}
	}

	public class Program
	{
		public static async Task Main(string[] args)
		{

			await Task.Delay(1000);

			var results = BenchmarkRunner.Run<Benchmark>();
			
			//Console.WriteLine("ReverseUsingMath");

			//Benchmark(() =>
			//{
			//	if (ReverseUsingMath(-1463847412) != -2147483641)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(1463847412) != 2147483641)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(123) != 321)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(-123) != -321)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(120) != 21)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(-2147483648) != 0)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(1534236469) != 0)
			//		throw new InvalidOperationException();

			//}, 1000);


			//Console.WriteLine("ReverseUsingStringsJustInt");

			//Benchmark(() =>
			//{
			//	if (ReverseUsingMath(-1463847412) != -2147483641)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingMath(1463847412) != 2147483641)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingStringsJustInt(123) != 321)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingStringsJustInt(-123) != -321)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingStringsJustInt(120) != 21)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingStringsJustInt(-2147483648) != 0)
			//		throw new InvalidOperationException();
			//	if (ReverseUsingStringsJustInt(1534236469) != 0)
			//		throw new InvalidOperationException();
			//}, 1000);
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

		// Runtime: 34 ms, faster than 67.52% of C# online submissions for Reverse Integer.
		// Memory Usage: 25.1 MB, less than 96.79% of C# online submissions for Reverse Integer.
		public static int ReverseUsingMath(int x)
		{
			//if (x == 1463847412)
			//	Console.WriteLine();


			bool negative = x < 0;
			int orig = x;
			int reversed = 0;


			while (orig != 0)
			{
				bool willUnderflow = false;
				bool willOverflow = false;

				if (negative)
				{
					int wuL = reversed;
					int wuR = int.MinValue / 10;
					willUnderflow = wuL < wuR;
				}
				else
				{
					int woL = reversed;
					int woR = int.MaxValue / 10;
					willOverflow = woL > woR;
				}

				if (
					(negative && willUnderflow) ||
					(!negative && willOverflow)
					)
				{
					return 0;
				}


				// Take off a digit from the 1s place.
				int dig1 = orig % 10;

				// Shift if not the first.
				if (reversed != 0)
					reversed *= 10;



				reversed += dig1;

				orig = orig / 10;

			}

			return reversed;


		}


		// Runtime: 29 ms, faster than 78.28% of C# online submissions for Reverse Integer.
		// Memory Usage: 27.8 MB, less than 6.91% of C# online submissions for Reverse Integer.
		public static int ReverseUsingStringsJustInt(int x)
		{
			bool isNegative = x < 0;

			try
			{
				int xAbs = Math.Abs(x);

				string xs = xAbs.ToString();
				string xsr = new string(xs.Reverse().ToArray());

				int res = int.Parse(xsr);
				if (isNegative)
					res *= -1;
				return res;

			} 
			catch (OverflowException) {
				return 0;
			}
			

			
		}


		// Runtime: 45 ms, faster than 37.81% of C# online submissions for Reverse Integer.
		// Memory Usage: 26.4 MB, less than 41.69% of C# online submissions for Reverse Integer.
		public static int ReverseUsingStringsLong(int x)
		{
			bool isNegative = x < 0;

			long xAbs = Math.Abs((long)x);

			string xs = xAbs.ToString();
			string xsr = new string(xs.ToString().Reverse().ToArray());

			long res = long.Parse(xsr);
			if (res > int.MaxValue)
				return 0;
			if (isNegative)
				res *= -1;
			return (int)res;


		}

		private static void Benchmark(Action act, int iterations)
		{
			for (int j=0; j<2; j++)
			{
				GC.Collect();
				act.Invoke(); // run once outside of loop to avoid initialization costs
				Stopwatch sw = Stopwatch.StartNew();
				for (int i = 0; i < iterations; i++)
				{
					act.Invoke();
				}
				sw.Stop();
				if (j == 1)
					Console.WriteLine((sw.ElapsedMilliseconds / iterations).ToString());
			}
			
			
		}


	}
}
