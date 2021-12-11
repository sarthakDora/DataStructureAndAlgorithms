using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    public class RiverSizes
    {
        public RiverSizes()
        {
            int[,] input = {
                        {1, 0, 0, 1, 0},
                        {1, 0, 1, 0, 0},
                        {0, 0, 1, 0, 1},
                        {1, 0, 1, 0, 1},
                        {1, 0, 1, 1, 0},
                    };
            GetRiverSizes(input);
        }
        public List<int> GetRiverSizes(int[,] matrix)
        {
            var totRow = matrix.GetLength(0);
            var totCol = matrix.GetLength(1);
            var rowDir = new int[] { -1, 0, 1, 0 };
            var colDir = new int[] { 0, 1, 0, -1 };
            bool[,] visited = new bool[totRow,totCol];
            List<int> finalRivers = new List<int>();


            for (int i = 0; i < totRow; i++)
            {
                for (int j = 0; j < totCol; j++)
                {
                    var riverSize = 0;
                     if (visited[i,j])
                    {
                        continue;
                    }
                    else if (matrix[i, j] == 0)
                    {
                        visited[i,j] = true;
                        continue;
                    }
                    else
                    {
                        visited[i, j] = true;
                        riverSize++;
                        var queue = new Queue<int[,]>();
                        queue.Enqueue(new int[i, j]);
                        while(queue.Count > 0)
                        {
                            var current = queue.Dequeue();
                            var rowIdx = current.GetLength(0);
                            var colIdx = current.GetLength(1);

                            for (int dir = 0; dir < 4; dir++)
                            {
                                var rowDirIdx = rowIdx + rowDir[dir];
                                var colDirIdx = colIdx + colDir[dir];

                                if(rowDirIdx < 0 || colDirIdx < 0 || rowDirIdx >= totRow || colDirIdx >= totCol || visited[rowDirIdx, colDirIdx]) continue;
                                if(matrix[rowDirIdx, colDirIdx] == 0)
                                {
                                    visited[rowDirIdx, colDirIdx] = true;
                                    continue;
                                }
                                if (matrix[rowDirIdx, colDirIdx] == 1 && !visited[rowDirIdx, colDirIdx])
                                {
                                    riverSize++;

                                    visited[rowDirIdx, colDirIdx] = true;
                                    queue.Enqueue(new int[rowDirIdx, colDirIdx]);
                                }
                            }

                        }
                        finalRivers.Add(riverSize);

                    }
                }
            }



            return finalRivers;
        }
    }
}
