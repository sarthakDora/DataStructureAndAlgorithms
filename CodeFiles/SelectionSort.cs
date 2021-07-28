using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class SelectionSort
	{
		public SelectionSort()
		{
			var array = new int[] { 8, 5, 6, 9, 1, 2, 5 };
			var rslt = sortIt(array);
		}
		private int[] sortIt(int[] array)
		{
			int currIndex = 0;
			while(currIndex < array.Length -1)
			{
				var smallestIndx = currIndex;
				for (int i = currIndex + 1; i < array.Length; i++)
				{
					if(array[smallestIndx] > array[i])
					{
						smallestIndx = i; 
					}
				}

				swap(currIndex, smallestIndx, array);
				currIndex += 1;
				

			}
			return array;

		}
		private int[] swap(int i, int j, int[] array)
		{
			var tmp = array[i];
			array[i] = array[j];
			array[j] = tmp;
			return array;
		}
	}
}
