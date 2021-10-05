using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAndAlgo
{
	public class ClimbStairs
	{
		public ClimbStairs()
		{
			Console.WriteLine(GetClimbStairs(5));
		}
		public int GetClimbStairs(int n)
		{

			List<int> finalWays = new List<int>();

			for (int i = 0; i <= n; i++)
			{
				if (i == 0)
				{
					finalWays.Add(1);
				}
				else if (i == 1)
				{
					finalWays.Add(1);
				}
				else
				{
					finalWays.Add(finalWays[i - 2] + finalWays[i - 1]);
				}
			}
			
			return finalWays[finalWays.Count - 1];
		}
	}
}
