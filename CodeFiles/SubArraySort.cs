using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	class SubArraySort
	{
		public SubArraySort()
		{
			var array = new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
			var rslt = SubbarraySort(array);
		 }
		// Time O(n) and Space O(1)
		public int[] SubbarraySort(int[] array)
		{
			var minOutOfOrder = decimal.MaxValue;
			var maxOutOfOrder = decimal.MinValue;

			for (int i = 0; i < array.Length; i++)
			{
				var currNum = array[i];
				if(isOutofOrder(i, currNum, array))
				{
					minOutOfOrder = Math.Min(minOutOfOrder, currNum);
					maxOutOfOrder = Math.Max(maxOutOfOrder, currNum);
				}
			}
			if (minOutOfOrder == decimal.MaxValue)
				return new int[] { -1, -1 };

			var subArrayLeftIndex = 0;
			while(minOutOfOrder >= array[subArrayLeftIndex])
			{
				subArrayLeftIndex+=1;
			}
			var subArrayRightIndex = array.Length-1;
			while (maxOutOfOrder <= array[subArrayRightIndex])
			{
				subArrayRightIndex-=1;
			}

			return new int[] { subArrayLeftIndex, subArrayRightIndex };
		}
		private bool isOutofOrder(int i, int num, int[] array)
		{
			if (i == 0)
			{
				return num > array[i + 1];
			}
			else if (i == array.Length - 1)
			{
				return num < array[i - 1];
			}
			else return num > array[i + 1] || num < array[i - 1]; 
		}

	}
}
