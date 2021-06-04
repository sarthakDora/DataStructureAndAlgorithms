using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class LargestNumInArray
	{
		private long largetstNum(long[] numbers)
		{
			if (numbers.Length <= 0) return 0;
			Array.Sort(numbers);
			var len = numbers.Length;
			var largest = numbers[len - 1];

			return largest;
		}
	}
}
