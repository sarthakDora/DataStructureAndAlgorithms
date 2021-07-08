using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class SumOFLEftRightTree
	{
		public string Solution(long[] arr)
		{
			if (arr.Length <= 0) return "";
			long leftSum = 0;
			long rightSum = 0;

			long left = 1;
			long right = 2;

			leftSum = getTreeSum(arr, left);
			rightSum = getTreeSum(arr, right);
			if (leftSum > rightSum) return "Left";
			else if (leftSum < rightSum) return "Right";

			return "";


		}
		public long getTreeSum(long[] arr, long i)
		{
			if (i > arr.Length - 1 || arr[i] == -1) return 0;
			long leftChild = 2 * i + 1;
			long rightChild = 2 * i + 2;
			long sum = 0;
			if (i < arr.Length)
			{
				sum = arr[i] + getTreeSum(arr, leftChild) + getTreeSum(arr, rightChild);
			}
			return sum;
		}
	}
}
