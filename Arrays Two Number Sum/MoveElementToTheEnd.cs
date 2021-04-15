using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public partial class MoveElementToTheEnd
	{
		public MoveElementToTheEnd()
		{
			int[] array = new int[] { 2, 1, 2, 2, 2, 3, 4, 2 };
			List<int> lst = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
			int toMove = 2;
			moveIt(array, toMove);
			moveItList(lst, toMove);
		}
		private int[] moveIt(int[] array, int ToMove)
		{
			int leftPtr = 0;
			int rightPtr = array.Length - 1;
			while(leftPtr < rightPtr)
			{
				while (leftPtr < rightPtr && array[rightPtr] == ToMove)
				{
					rightPtr --;
				}
				if (array[leftPtr] == ToMove)
				{
					var temp = array[rightPtr];
					array[rightPtr] = array[leftPtr];
					array[leftPtr] = temp;
				}
				leftPtr += 1;
			}
			return array;
		}
		private List<int> moveItList(List<int> array, int ToMove)
		{
			int leftPtr = 0;
			int rightPtr = array.Count-1;
			while (leftPtr < rightPtr)
			{
				var firstNumber = array[leftPtr];
				var secondNumber = array[rightPtr];
				if (secondNumber == ToMove)
				{
					rightPtr -= 1;
					secondNumber = array[rightPtr];
				}
				else if (firstNumber == ToMove)
				{
					array[rightPtr] = firstNumber;
					array[leftPtr] = secondNumber;
					leftPtr += 1;
					rightPtr -= 1;
				}
				else
				{
					leftPtr += 1;
				}
			}
			return array;
		}

	}
}
