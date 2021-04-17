using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class SpiralTraverse
	{
		public SpiralTraverse()
		{
			var array = new int[,] { { 1, 2, 3, 4 }, { 12, 13, 14, 5 }, { 11, 16, 15, 6 }, { 10, 9, 8, 7 } };
			var array2 = new int[,] { { 1, 2, 3, 4 }, { 10, 11, 12, 5 }, { 9, 8, 7, 6 } };
			getSpiralTraverese(array2);
		}
		private List<int> getSpiralTraverese(int[,] array)
		{
			List<int> final = new List<int>();
			var startRow = 0;
			var endRow = array.GetLength(0) - 1; 

			var startColumn = 0;
			var endColumn = array.GetLength(1)-1;

			while(startRow <= endRow && startColumn <= endColumn)
			{
				for (int i = startColumn; i < endColumn + 1; i++)
				{
					final.Add(array[startRow,i]);
				}
				for (int j = startRow+1; j < endRow + 1; j++)
				{
					final.Add(array[j, endColumn]);
				}
				for (int x = endColumn-1; x >= startColumn; x--)
				{
					if (startRow == endRow) break;
					final.Add(array[endRow, x]);
				}
				for (int y = endRow-1; y > startRow; y--)
				{
					if (startColumn == endColumn) break;
					final.Add(array[y, startColumn]);
				}
				startRow++;
				endRow--;
				startColumn++;
				endColumn--;
			}

			 return final;
		}
	}
}
