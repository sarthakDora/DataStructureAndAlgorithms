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
                {1,0,0 },
                {1,1,9 },
                {1,0,1 }
};
            int numRows = lot.GetLength(0); int numColumns = lot.GetLength(1);

            Console.WriteLine(demolition2(lot, numColumns, numRows));
            Console.WriteLine(DemolitionRobot(lot, numColumns, numRows));


        }
        private int demolition2(int[,] lot, int numColumns, int numRows)
        {
            int visited = 0;
            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    var currentNode = lot[j, i];
                    if (currentNode == 1) visited += 1;
                    else if (currentNode == 9)
                    {
                        return visited;
                    }
                }
            }
            return -1;
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

        private  bool Helper(int numRows, int numColumns, int[,] lot, bool[,] visited, int currentRow, int currentColumn, int distance)
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
