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
            var qApproach = DemolitionRobot3(lot, numColumns, numRows);
            // Console.WriteLine(DemolitionRobot(lot, numColumns, numRows));
        }
        private int DemolitionRobot3(int[,] lot, int numColumns, int numRows)
        {
            int[] dRow = { -1, 0, 1, 0 }; //Direction vector
            int[] dCol = { 0, 1, 0, -1 }; //Direction vector
            var visited = new bool[numRows, numColumns];
            var queue = new Queue<NodePair>();
            queue.Enqueue(new NodePair(0, 0));
            visited[0, 0] = true;
            var minDist = int.MaxValue;
            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                var row = currNode.x;
                var col = currNode.y;
                for (int i = 0; i < 4; i++)
                {
                    var adjX = row + dRow[i];
                    var adjY = col + dCol[i];

                    if (adjX < 0 || adjY < 0 || adjX >= numRows || adjY >= numColumns || lot[adjX, adjY] == 0) continue;

                    if (lot[adjX, adjY] == 9)
                    {
                        minDist = Math.Min(minDist, lot[row, col]);
                    }
                    if (lot[adjX, adjY] == 1 && !visited[adjX, adjY])
                    {
                        lot[adjX, adjY] = lot[row, col] + 1;
                        visited[adjX, adjY] = true;
                        queue.Enqueue(new NodePair(adjX, adjY));
                    }
                }
            }
            return minDist;

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

    public class NodePair
    {
        public int x, y;
        public NodePair(int first, int second)
        {
            x = first;
            y = second;
        }
    }

}
