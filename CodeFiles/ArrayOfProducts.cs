using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	public class ArrayOfProducts
	{
		public ArrayOfProducts()
		{
			var array = new int[] { 5, 1, 4, 2 };
			getArrayOfProducts(array);
			var v2 = getArrayOfProductsV2(array);
			var v3 = getArrayOfProductsV3(array);
		}
		//O(n2) time complexity | O(n) space complexity
		private int[] getArrayOfProducts(int[] array)
		{
			int[] finalproduct = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				int product = 1;
				for (int j = 0; j < array.Length; j++)
				{
					if (i != j)
					{
						product *= array[j];
					}
				}
				finalproduct[i] = product;
			}
			return finalproduct;
		}

		//O(n) space | O(n) time
		private int[] getArrayOfProductsV2(int[] array)
		{
			int[] finalproduct = new int[array.Length];
			var product = 1;

			var left = new int[array.Length];
			var leftIndex = 0;
			var rightIndex = array.Length;

			while(leftIndex < rightIndex)
			{
				left[leftIndex] = product;
				product *= array[leftIndex];
				leftIndex++;
			}
			product = 1;
			leftIndex = 0;
			rightIndex = array.Length-1;
			while (leftIndex <= rightIndex)
			{
				finalproduct[rightIndex] = product*left[rightIndex];
				product *= array[rightIndex];
				rightIndex--;
			}
			
			return finalproduct;
		}
		private int[] getArrayOfProductsV3(int[] array)
		{
			int[] finalproduct = new int[array.Length];
			var product = 1;

			for (int i = 0; i < array.Length; i++)
			{
				finalproduct[i] = product;
				product *= array[i];
			}
			product = 1;
			for (int j = array.Length-1; j >= 0 ; j--)
			{
				finalproduct[j] *= product;
				product *= array[j];
			}

			return finalproduct;
		}

	}
}
