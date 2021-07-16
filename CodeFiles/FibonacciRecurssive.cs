using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class FibonacciRecurssive
	{
		public FibonacciRecurssive()
		{
			Console.WriteLine(fib(6));
		}
		private int fib(int n)
		{
			if (n == 0 || n == 1) return 1;
			else
			{
				return fib(n - 1) + fib(n - 2);
			}
		}
	}
}
