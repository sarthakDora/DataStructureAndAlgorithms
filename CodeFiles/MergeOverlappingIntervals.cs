using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class MergeOverlappingIntervals
	{
		public MergeOverlappingIntervals()
		{
			var intervals = new int[][] { new int[] {1,2}, new int[] { 3,8}, new int[] { 9,10} };
			var intervals2 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 4,7 }, new int[] { 6,8 }, new int[] { 9, 10 } };
			var intervals3 = new int[][] { new int[] { 1, 22 }, new int[] { -20, 30 }};
			var rslt = MergeIntervals(intervals3);

		}
		public int[][] MergeIntervals(int[][] intervals)
		{
			var cloned = intervals.Clone() as int[][];
			Array.Sort(cloned, (a,b) => a[0].CompareTo(b[0]));

			List<int[]> mergedIntervals = new List<int[]>();
			int[] currentIntervals = cloned[0];
			mergedIntervals.Add(currentIntervals);

			foreach (var nextInterval in cloned)
			{
				int currentIntervalEnd = currentIntervals[1];
				int nextIntervalStart = nextInterval[0];
				int nextIntervalEnd = nextInterval[1];

				if(currentIntervalEnd >= nextIntervalStart)
				{
					currentIntervals[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
				}
				else
				{
					currentIntervals = nextInterval;
					mergedIntervals.Add(currentIntervals);
				}
			}
			return mergedIntervals.ToArray();
		}
	}
}
