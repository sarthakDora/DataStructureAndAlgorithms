using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class FirstDuplicateValueInArray
	{
		public FirstDuplicateValueInArray()
		{
			var array = new int[] { 2, 1, 5, 3, 3, 2, 4 };
			Console.WriteLine(FirstDuplicateValue(array));
			Console.WriteLine(FirstDuplicateValueV2(array));
			Console.WriteLine(FirstDuplicateValueV3(array));
			Console.WriteLine(FirstDuplicateValueV4(array));

		}

		//Time: O(n2) | Space : O(1)
		private int FirstDuplicateValue(int[] array)
		{
			if (array.Length < 0) return -1;
			var leftPointer = 0;
			var secondPointer = 1;
			var lowestIndex = array.Length;
			while (secondPointer < array.Length)
			{
				if (array[leftPointer] == array[secondPointer])
				{
					if (secondPointer < lowestIndex)
					{
						lowestIndex = secondPointer;
					}
					leftPointer++;
					secondPointer = leftPointer;
				}

				if (secondPointer == array.Length - 1)
				{
					leftPointer++;
					secondPointer = leftPointer;
				}
				secondPointer++;
			}

			return lowestIndex == array.Length ? -1 : array[lowestIndex];
		}
		//Using Hashset
		//Time : O(n) | space : O(n)
		private int FirstDuplicateValueV2(int[] array)
		{
			if (array.Length < 0) return -1;

			var lowestIndex = array.Length;
			HashSet<int> set = new HashSet<int>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!set.Contains(array[i])) set.Add(array[i]);
				else if(i < lowestIndex)lowestIndex = i;
			}
			return lowestIndex == array.Length ? -1 : array[lowestIndex];
		}
		//Time : O(n) | space : O(n)
		private int FirstDuplicateValueV3(int[] array)
		{
			if (array.Length < 0) return -1;
			HashSet<int> set = new HashSet<int>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!set.Contains(array[i])) set.Add(array[i]);
				else return array[i];
			}
			return -1;
		}
		//Time : O(n) | space : O(1)
		private int FirstDuplicateValueV4(int[] array)
		{
			if (array.Length < 0) return -1;

			for (int i = 0; i < array.Length; i++)
			{
				var idx = Math.Abs(array[i]);
				if (array[idx - 1] < 0)
				{
					return idx;
				}
				array[idx - 1] *= -1;
			}
			return -1;
		}
	}
}
