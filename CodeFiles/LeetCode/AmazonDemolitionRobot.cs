using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.LeetCode
{
    public class AmazonDemolitionRobot
    {
        int finalDistance;
        public AmazonDemolitionRobot()
        {

            //int[,] lot = new int[,]
            //{
            //    {1,0,0 },
            //    {1,0,0 },
            //    {1,9,1 }
            //};
            int[,] lot = new int[,]
{
                {1,0,0,0 },
                {1,1,1,0 },
                {1,1,1,9}
};
            int numRows = lot.GetLength(0); int numColumns = lot.GetLength(1);
            var actual = DemolitionRobot(lot, numColumns, numRows);
            var try1 = DemolitionRobot2(lot, numColumns, numRows);
            // Console.WriteLine(DemolitionRobot(lot, numColumns, numRows));
        }
        private int DemolitionRobot2(int[,] lot, int numColumns, int numRows)
        {
            finalDistance = 0;
            List<int> visitedArray = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(lot[0, 0]);
            int rowIdx = 0;
            int colIdx = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == 0) continue;
                visitedArray.Add(current);
                if (current == 9)
                {
                    queue.Clear();
                    break;
                }
                if (numRows > rowIdx + 1 && numColumns > colIdx) queue.Enqueue(lot[rowIdx + 1, colIdx]);
                if (numRows > rowIdx - 1 && rowIdx - 1 > 0 &&  numColumns > colIdx ) queue.Enqueue(lot[rowIdx - 1, colIdx]);
                if (numColumns > colIdx + 1 && numRows > rowIdx) queue.Enqueue(lot[rowIdx, colIdx + 1]);
                if (numColumns > colIdx - 1 && colIdx - 1 > 0 && numRows > rowIdx) queue.Enqueue(lot[rowIdx, colIdx - 1]);
                rowIdx++;
                colIdx++;
            }
           

            return visitedArray.Count;
        }

        private int DemolitionRobot(int[,] lot, int numColumns, int numRows)
        {
            finalDistance = 0;
            bool[,] visited = new bool[numRows, numColumns];
            int distance = 0;
            if (Helper(numRows, numColumns, lot, visited, 0, 0, distance))
            {
                return finalDistance;
            }
            else
            {
                return 0;
            }
        }

        private bool Helper(int numRows, int numColumns, int[,] lot, bool[,] visited, int currentRow, int currentColumn, int distance)
        {

            if (currentRow < 0 || currentColumn < 0 || currentRow >= numRows || currentColumn >= numColumns)
            {
                return false;
            }

            // check if this cell is already visited
            if (visited[currentRow, currentColumn])
            {
                return false;
            }

            // check if the value at cell is 0 i.e. no further path
            if (lot[currentRow, currentColumn] == 0)
            {
                return false;
            }

            // if the value is 9 i.e. the destination.
            // Found the destination, return true 
            if (lot[currentRow, currentColumn] == 9)
            {
                return true;
            }

            // This means, current cell is not visited yet and it has the value 1 i.e. path
            // this is 1 step forward toward the destination.

            // increase the distance by 1.
            distance++;

            // mark current cell as visited so that we dont come on the same cell again.
            visited[currentRow, currentColumn] = true;

            // Go for "Breadth Firth Search" in all four direction. 
            if (Helper(numRows, numColumns, lot, visited, currentRow++, currentColumn, distance) ||
               Helper(numRows, numColumns, lot, visited, currentRow--, currentColumn, distance) ||
               Helper(numRows, numColumns, lot, visited, currentRow, currentColumn++, distance) ||
               Helper(numRows, numColumns, lot, visited, currentRow, currentColumn--, distance)
                )
            {
                // Set the final distance to travel if it is not set yet.
                if (finalDistance == 0)
                {
                    finalDistance = distance;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
