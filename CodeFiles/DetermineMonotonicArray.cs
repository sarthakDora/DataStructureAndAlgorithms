using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public partial class DetermineMonotonicArray
	{
		public DetermineMonotonicArray()
		{
			int[] array = new int[] { -1, -5,2, -10, -1100, -1100, -1101, -1102, -9001 };
			int[] falseArray = new int[] { 2, 2, 2, 1, 4, 5 };
			var result = isMonotonic(array);
			Console.WriteLine(result);
		}
		private bool isMonotonic(int[] array)
		{
			if (array.Length <= 2) return true;
			var direction = array[1] - array[0];
			for (int i = 2; i < array.Length; i++)
			{
				if (direction == 0)
				{
					direction = array[i] - array[i - 1]; // current  - previous for new direction				
				}
				if (breakDirection(direction, array[i - 1], array[i]))
				{
					return false;
				}
			}

			return true;
		}
		public  bool breakDirection(int direction, int prev, int curr)
		{
			var diff = curr - prev;
			if (direction > 0) return diff < 0; //Here we check if new difference is respecting the existing direction or not?
			return diff > 0;
		}
	}
}
