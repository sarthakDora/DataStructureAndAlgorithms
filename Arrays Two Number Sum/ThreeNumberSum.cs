using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace DataStructureAndAlgo
{
	public partial class ThreeNumberSum
	{
		public ThreeNumberSum()
		{
			var array1 = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
			var targetSum1 = 0;
			var output1 = threeNumberSumV2(array1, targetSum1);
		}
		private List<int[]> threeNumberSumV1(int[] array, int targetSum)
		{
			Array.Sort(array);
			List<int[]> finalList = new List<int[]>();

			for (int i = 0; i < array.Length; i++)
			{
				var firstNum = array[i];
				for (int j = i+1; j < array.Length; j++)
				{
					var secondNum = array[j];
					for (int x = j+1; x < array.Length; x++)
					{
						var thirdNum = array[x];
						var newSum = firstNum + secondNum + thirdNum;
						if (newSum == targetSum)
						{
							finalList.Add(new int[] { firstNum, secondNum, thirdNum });
						}
					}
				}
			}
			return finalList;
		}
		private List<int[]> threeNumberSumV2(int[] array, int targetSum)
		{
			//[-8,-6,1,2,3,5,6,12]
			Array.Sort(array);
			List<int[]> finalList = new List<int[]>();


			for (int i = 0; i < array.Length-2; i++)
			{
				int firstPointerIndex = i+1;
				int lastPointerIndex = array.Length - 1;
				var currentNum = array[i];
				while(firstPointerIndex < lastPointerIndex)
				{
					var secondNum = array[firstPointerIndex];
					var thirdNum = array[lastPointerIndex];
					var sum = currentNum + secondNum + thirdNum;

					if (sum == targetSum)
					{
						finalList.Add(new int[] { currentNum, secondNum, thirdNum });
						lastPointerIndex--;
					}
					else if (sum < targetSum) firstPointerIndex++;
					else if (sum > targetSum) lastPointerIndex--; 
					
					
				}

			}
			

			
			return finalList;
		}
	}
}
