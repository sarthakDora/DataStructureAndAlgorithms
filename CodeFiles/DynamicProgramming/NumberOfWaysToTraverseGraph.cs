using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class NumberOfWaysToTraverseGraph
    {
        //O(n*m)
        public NumberOfWaysToTraverseGraph()
        {
            Console.WriteLine(NumberOfWays(4,3));
        }
        public int NumberOfWays(int width, int column)
        {
            var numOfWays = new int[column + 1, width + 1];

            for (int widthIdx = 1; widthIdx < width+1; widthIdx++)
            {
                for (int colIdx = 1; colIdx < column+1; colIdx++)
                {
                    if(widthIdx == 1 || colIdx == 1)
                    {
                        numOfWays[colIdx,widthIdx] = 1;
                    }
                    else
                    {
                        var waysLeft = numOfWays[colIdx, widthIdx - 1];
                        var waysUp = numOfWays[colIdx-1, widthIdx];
                        numOfWays[colIdx, widthIdx] = waysLeft + waysUp;
                    }
                }
            }
            return numOfWays[column, width];
        }
    }
}
