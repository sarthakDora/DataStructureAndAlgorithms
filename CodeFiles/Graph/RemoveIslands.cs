using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    public class RemoveIslands
    {
        public RemoveIslands()
        {
            int[][] input = new int[][] {
            new int[] {1, 0, 0, 0, 0, 0},
            new int[] {0, 1, 0, 1, 1, 1},
            new int[] {0, 0, 1, 0, 1, 0},
            new int[] {1, 1, 0, 0, 1, 0},
            new int[] {1, 0, 1, 1, 0, 0},
            new int[] {1, 0, 0, 0, 0, 1},
            };
            RemoveIslandsMethod(input);
        }
        //O(wh) time | O(wh) space - where w and h are the width and height of the input matrix
        public int[][] RemoveIslandsMethod(int[][] matrix)
        {
            bool[,] onesConnectedToBorder = new bool[matrix.Length, matrix[0].Length];
  
            /* THis is just to make all connected to border false but by default they are false in c#
            for (int i = 0; i < matrix.Length; i++)
                onesConnectedToBorder[i, matrix[0].Length - 1] = false;
            */

            //FInd all the 1s that are not islands
            for (int row = 0;row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.Length - 1;
                    bool colIsBorder = col == 0 || col == matrix[row].Length - 1;
                    bool isBorder = rowIsBorder || colIsBorder;

                    if (!isBorder) { continue; }
                    if(matrix[row][col] != 1) { continue; }

                    findOnesConnectedToBorder(matrix, row, col, onesConnectedToBorder);
                }
            }
            for (int row = 1; row < matrix.Length - 1; row++)
            {
                for (int col = 1; col < matrix[row].Length -1; col++)
                {
                    if (onesConnectedToBorder[row, col])
                    {
                        continue;
                    }
                    matrix[row][col] = 0;
                }
            }

            return matrix;
        }
        public void findOnesConnectedToBorder(int[][] matrix, int startRow, int startCol, bool[,] onesConnectedToBorder)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(startRow, startCol));

            while (stack.Count > 0)
            {
                var currentPosition = stack.Pop();
                int currentRow = currentPosition.Item1;
                int currentCol = currentPosition.Item2;

                bool alreadyVisited = onesConnectedToBorder[currentRow, currentCol];
                if (alreadyVisited) { continue; }

                onesConnectedToBorder[currentRow, currentCol] = true;

                var neigbhors = getNeigbhors(matrix, currentRow, currentCol);
                foreach (var neighbhor in neigbhors)
                {
                    int row = neighbhor.Item1;
                    int col = neighbhor.Item2;

                    if(matrix[row][col] != 1) { continue; }
                    stack.Push(neighbhor);
                }
            }
        }

            public List<Tuple<int, int>> getNeigbhors(int[][] matrix, int row, int col)
            {
                int numRows = matrix.Length;
                int numCols = matrix[row].Length;
                List<Tuple<int,int>> neighbors = new List<Tuple<int,int>>();   

                if(row -1 >= 0)
                {
                    neighbors.Add(new Tuple<int, int>(row - 1, col)); //UP
                }
                if(row + 1 < numRows)
                {
                    neighbors.Add(new Tuple<int,int>(row + 1, col)); //Down
                }
                if(col -1 >= 0)
                {
                    neighbors.Add(new Tuple<int, int>(row, col - 1)); //LEFT
                }
                if(col +1 < numCols)
                {
                    neighbors.Add(new Tuple<int, int>(row, col + 1)); //RIGHT
                }
                return neighbors;




            }
        

    }   
}
