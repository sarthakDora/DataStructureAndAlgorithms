using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	class LargestRange
	{
		public LargestRange()
		{
			var array = new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 };
			var array2 = new int[] { 19, -1, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, 8, 7, 6, 15, 12, 12, 2, 1, 6, 13, 14 };
			var array3 = new int[] { 1, 1, 1, 3, 4 };
			var array4 = new int[] { 1, 1 };
			var rslt = GetLargestRange(array4);
			var rslt2 = GetLargestRangeV2(array3);
		}
		public int[] GetLargestRange(int[] array)
		{
			Array.Sort(array);
			var minRangeNum = decimal.MaxValue;
			int rngCounter = 1;
			Dictionary<int, int[]> ranges = new Dictionary<int, int[]>();
			for (int i = 0; i < array.Length; i++)
			{
				var currNum = array[i];
				minRangeNum = Math.Min(minRangeNum, currNum);
				if (isOutofOrderRange(i, currNum, array))
				{
					if (Convert.ToInt32(minRangeNum) == currNum)
					{
						rngCounter = 1;
					}
					ranges.Add(rngCounter, new int[] { Convert.ToInt32(minRangeNum), currNum });
					if (i < array.Length - 1) minRangeNum = array[i + 1];
					rngCounter = 1;
				}
				else rngCounter += 1;
			}
			var maxRangeVals = ranges.OrderByDescending(x => x.Key).FirstOrDefault().Value;
			return maxRangeVals;
		}
		private bool isOutofOrderRange(int i, int num, int[] array)
		{
			if (i == array.Length - 1)
			{
				return true;
			}
			else if (num == array[i + 1]) return false;
			return num + 1 != array[i + 1];
		}

		//Space O(n) and Time O(n)
		public int[] GetLargestRangeV2(int[] array)
		{
			int[] largestRange = new int[2];
			int longestLength = 0;
			HashSet<int> nums = new HashSet<int>();
			foreach (var num in array)
			{
				nums.Add(num);
			}
			foreach (var num in array)
			{
				if (!nums.Contains(num))
				{
					continue;
				}
				nums.Remove(num);

				int currentRangeLength = 1;
				var left = num-1;
				var right = num + 1;
				while(nums.Contains(left))
				{
					nums.Remove(left);
					currentRangeLength += 1;
					left--;
				}
				while(nums.Contains(right))
				{
					nums.Remove(right);
					currentRangeLength += 1;
					right++;
				}
				if(currentRangeLength > longestLength)
				{
					longestLength = currentRangeLength;
					largestRange = new int[] { left + 1, right - 1 };
				}
			}
			return largestRange;
		}
	}
}
