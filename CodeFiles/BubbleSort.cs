using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class BubbleSort
	{
		public BubbleSort()
		{
			var array = new int[] { 8, 5, 2, 9, 5, 6, 3 };
			var rslt = getSortedArray(array);
		}
		//Time --> O(N(sqr)) || Space --> O(1)
		private int[] getSortedArray(int[] array)
		{
			var counter = 0;
			bool isSorted = false;

			while(!isSorted)
			{
				isSorted = true;
				for (int i = 0; i < array.Length-1-counter; i++) //We dont want to go over the sorted item which will be at the end index.
				{
					if(array[i] > array[i+1])
					{
						swap(i, i + 1, array);
						isSorted = false;
					}
				}
				counter += 1;
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
