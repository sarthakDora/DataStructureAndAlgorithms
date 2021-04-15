using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	public partial class SmallestDifference
	{
		public SmallestDifference()
		{
			var array1 = new int[] { -1, 5, 10, 20, 28, 3 };
			var array2 = new int[] { 26, 134, 135, 15,17};
			getSmallestDifference(array1, array2);
		}
		public int[] getSmallestDifference(int[] arrayOne, int[] arrayTwo)
		{
			Array.Sort(arrayOne);
			Array.Sort(arrayTwo);

			var leftPtr = 0;
			var rightPtr = 0;

			int[] finalArr = new int[2];
			int smallestValue = Int32.MaxValue;

			while (leftPtr < arrayOne.Length && rightPtr < arrayTwo.Length)
			{
				int currentDiff = Int32.MaxValue;
				var firstNum = arrayOne[leftPtr];
				var secondNum = arrayTwo[rightPtr];

				if (firstNum < secondNum)
				{
					currentDiff = secondNum - firstNum;
					leftPtr += 1;

				}
				else if(secondNum < firstNum)
				{
					currentDiff = firstNum - secondNum;
					rightPtr += 1;
				}
				else
				{
					return new int[] { firstNum, secondNum };
				}

				if(smallestValue > currentDiff)
				{
					smallestValue = currentDiff;
					finalArr = new int[] { firstNum, secondNum };
				}

			}
			return finalArr;

		}

	}
}
