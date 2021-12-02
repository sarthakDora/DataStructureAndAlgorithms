using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class DijKstrasAlgo
    {
        public DijKstrasAlgo()
        {
            var start = 0;
            int[][][] edges = {
            new int[][] {new int[] {1, 7}},
            new int[][] {new int[] {2, 6}, new int[] {3, 20}, new int[] {4, 3}},
            new int[][] {new int[] {3, 14}},
            new int[][] {new int[] {4, 2}},
            new int[][] {},
            new int[][] {}
            };
            int[] expected = { 0, 7, 13, 27, 10, -1 };
            var actual = DijkstrasAlgorithm_Unoptimal(start, edges);
            Console.WriteLine(String.Join(",", actual));
            Console.WriteLine((expected.Length == actual.Length));
            for (int i = 0; i < expected.Length; i++)
            {
                Console.WriteLine((expected[i] == actual[i]));
            }
        }
        // Time : O(v^2+e) | Space O(v)
        public int[] DijkstrasAlgorithm_Unoptimal(int start, int[][][] edges)
        {
            var numberOfVertices = edges.Length;

            var minDistances = new int[numberOfVertices];
            Array.Fill(minDistances, Int32.MaxValue);
            minDistances[start] = 0;

            var visited = new HashSet<int>();

            while (visited.Count != numberOfVertices)
            {
                int[] getVertexData = getVertexWithMinDistances(minDistances, visited);
                var vertex = getVertexData[0];
                var currentMinDist = getVertexData[1];

                if (currentMinDist == Int32.MaxValue) { break; }

                visited.Add(vertex);

                foreach (var edge in edges[vertex])
                {
                    var destination = edge[0];
                    var distanceToDestination = edge[1];

                    if (visited.Contains(destination)) { continue; }

                    var newPathDist = currentMinDist + distanceToDestination;
                    var currentDestDist = minDistances[destination];

                    if (newPathDist < currentDestDist)
                    {
                        minDistances[destination] = newPathDist;
                    }
                }
            }
            var finalDistances = new int[minDistances.Length];

            for (int i = 0; i < minDistances.Length; i++)
            {
                var distance = minDistances[i];
                if (distance == Int32.MaxValue) finalDistances[i] = -1;
                else finalDistances[i] = distance;
            }


            return finalDistances;
        }
        private int[] getVertexWithMinDistances(int[] distances, HashSet<int> visited)
        {
            int currentMinDistance = Int32.MaxValue;
            var vertex = -1;

            for (int vertexIdx = 0; vertexIdx < distances.Length; vertexIdx++)
            {
                var distance = distances[vertexIdx];
                if (visited.Contains(vertexIdx)) continue;

                if (distance <= currentMinDistance)
                {
                    vertex = vertexIdx;
                    currentMinDistance = distance;
                }
            }
            return new int[] { vertex, currentMinDistance };
        }
        //public int[] DijKstrasAlgorithm_OptimalSol(int start, int[][][] edges)
        //{

        //}
    }
    public class Item
    {
        public int vertex;
        public int distance;
        public Item(int vertex, int distance)
        {
            this.vertex = vertex;
            this.distance = distance;
        }
    }
    public class MinHeap
    {
        Dictionary<int, int> vertexDictionary = new Dictionary<int, int>();
        List<Item> heap = new List<Item> ();

        public MinHeap(List<Item> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                var item = array[i];
                vertexDictionary[item.vertex] = item.vertex;
            }
            heap = buildHeap(array);
        }

        private List<Item> buildHeap(List<Item> array)
        {
            int firstParentIdx = (array.Count - 2) / 2;
            for (int currentIdx = firstParentIdx+1; currentIdx >=0; currentIdx--)
            {
                siftDown(currentIdx, array.Count - 1, array);
            }
            return array;
        }
        public bool IsEmpty()
        {
            return heap.Count == 0; 
        }
        private void siftDown(int currentIdx, int endIdx, List<Item> heap)
        {
            
        }
    }
}
