using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class LongestPeak
	{
		public LongestPeak()
		{
			int[] array = new int[] { 1, 4,0, 10, 2 };
			Console.WriteLine(inspectLongestPeak(array));
		}
		private int inspectLongestPeak(int[] array)
		{
			int longestPeakLength = 0;
			var i = 1; //This start with second value
			while(i < array.Length - 1)
			{
				//Peak will only arrive when prev num is smaller than i and i is greater than next value
				var isPeak = array[i - 1] < array[i] && array[i] > array[i+1]; 
				if(!isPeak)
				{
					i += 1;
					continue;
				}
				var leftIdx = i - 2;
				while(leftIdx >= 0 && array[leftIdx] < array[leftIdx + 1])
				{
					leftIdx -= 1;
 				}
				var rightIdx = i + 2;
				while(rightIdx < array.Length && array[rightIdx] < array[rightIdx -1])
				{
					rightIdx += 1;
				}
				var currentPeakLength = rightIdx - leftIdx - 1;
				longestPeakLength = Math.Max(longestPeakLength, currentPeakLength);
				i = rightIdx;
			}
 			return longestPeakLength;

		}
	}
}
