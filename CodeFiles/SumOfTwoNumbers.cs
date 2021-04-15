using System;
using System.Collections;


namespace DataStructureAndAlgo
{
	public partial class SumOfTwoNumbers
	{
		public  SumOfTwoNumbers()
		{
			int[] arr = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
			int targetSum = 13;
			var result1 = getTwoNumbers(arr, targetSum);
			var result2 = getTwoNumberV2(arr, targetSum);
			var result3 = getTwoNumberV3(arr, targetSum);
			foreach (int i in arr)
			{
				Console.Write("{0} ", i);
			}
			Console.WriteLine("----------------Array Input-----------------");
			Console.WriteLine("Using Hash Table {0} & {1}", result1[0], result1[1]);
			Console.WriteLine("Using Two For loops {0} & {1}", result2[0], result2[1]);
			Console.WriteLine("Using Sort and Pointers {0} & {1}", result3[0], result3[1]);
		}
		
		static int[] getTwoNumbers(int[] array, int targetSum)
		{
			Hashtable hashTbl = new Hashtable();
			foreach (int currentNum in array)
			{
				int secondNum = targetSum - currentNum;

				if (!hashTbl.ContainsKey(secondNum))
				{
					hashTbl.Add(currentNum, true);
				}
				else
				{
					return new int[] { currentNum, secondNum };
				}
			}
			return new int[0];
		}
		static int[] getTwoNumberV2(int[] array, int targetSum)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				var firstNumber = array[i];
				for (int j = i + 1; j < array.Length; j++)
				{
					var secondNumber = array[j];
					var sum = firstNumber + secondNumber;
					if (sum == targetSum) return new int[] { firstNumber, secondNumber };
				}
			}
			return new int[0];
		}
		static int[] getTwoNumberV3(int[] array, int targetSum)
		{
			Array.Sort(array);
			int left = 0;
			int right = array.Length - 1;

			while (left < right)
			{
				var currentSum = array[left] + array[right];
				if (currentSum == targetSum)
				{
					return new int[] { array[left], array[right] };
				}
				else if (currentSum < targetSum) { left += 1; }
				else if (currentSum > targetSum) { right -= 1; }
			}


			return new int[0];
		}
	}
}
