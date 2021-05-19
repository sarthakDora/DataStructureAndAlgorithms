using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class AmazonDemolitionRobot
	{
		public AmazonDemolitionRobot()
		{
			List<int> row1 = new List<int>();
			row1.Add(1);
			row1.Add(0);
			row1.Add(0);

			List<int> row2 = new List<int>();
			row2.Add(1);
			row2.Add(0);
			row2.Add(0);


			List<int> row3= new List<int>();
			row3.Add(1);
			row3.Add(9);
			row3.Add(0);


			List<List<int>> lot = new List<List<int>>() { row1, row2, row3};

			totalDistanceTraversed(lot);
		}
		private int totalDistanceTraversed(List<List<int>> lot)
		{
			if (lot.Count <= 0) return -1;
			

			Queue<int[]> q = new Queue<int[]>();
			

			for (int i = 0; i < lot.Count; i++)
			{

			}

			return -1;
		}
	}
}
