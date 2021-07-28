using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class InsertionSort
	{
		public InsertionSort()
		{
			var array = new int[] { 8, 6, 5, 3, 5, 9, 10 };
			var rslt = getSortedArray(array);
		}
		//Time --> O(n(sqr)) || Space --> O(1)
		private int[] getSortedArray(int[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				int j = i;
				while (j > 0 && array[j] < array[j-1])
				{
					swap(j - 1,j,  array);
					j -= 1;
				}
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
