using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class NonConstructibleCHange
	{
		public NonConstructibleCHange()
		{
			var array = new int[] { 5, 7, 1, 1, 2, 3, 22 };
			var final = getNonConstructibleCHange(array);
			Console.WriteLine($"Change which is not accepted is : {final}");
		}
		private int getNonConstructibleCHange(int[] coins)
		{
			int change = 0;
			Array.Sort(coins);

			for (int i = 0; i < coins.Length; i++)
			{
				var val = coins[i];
				if (val > change + 1)
				{
					return change + 1;
				}
				else if (val <= change + 1)
				{
					change += val;
				}
			}
			return change + 1;
		}
	}
}
