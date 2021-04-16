using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class SortedSquaredArray
	{
		public SortedSquaredArray()
		{
			var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var array2 = new int[] { -2, -1};
			//var final = getSortedSqrdArray(array2);
			var final2 = getSortedSqrdArrayV2(array2);
		}
		private int[] getSortedSqrdArray(int[] array)
		{
			if (array.Length > 0)
			{
				int i = 0;
				while (i < array.Length)
				{
					array[i] = array[i] * array[i];
					i++;
				}
				Array.Sort(array);
				return array;
			}
			return new int[] { };
		}
		private int[] getSortedSqrdArrayV2(int[] array)
		{
			if (array.Length > 0)
			{
				var sortedSqrs = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					var value = array[i];
					sortedSqrs[i] = value * value;
				}
				Array.Sort(sortedSqrs);
				return sortedSqrs;
			}
			return new int[] { };
		}
	}
}
