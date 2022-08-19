using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    public class CycleInGraph
    {
        //First vertex is last vertex is a cycle
        //Time O(v + e) | Space O(v)
        public CycleInGraph()
        {
            int[][] input = new int[][] {
            new int[] {1, 3},
            new int[] {2, 3, 4},
            new int[] {0},
            new int[] {},
            new int[] {2, 5},
            new int[] {}
            };
            Console.WriteLine(IsCycleInGraph(input));
        }

        private bool IsCycleInGraph(int[][] edges)
        {
            var numOfNodes = edges.Length;
            var visited = new bool[numOfNodes];
            var currentlyInStack = new bool[numOfNodes]; //currentlyInStack will tell that if node is already there then it means cycle exists
            for (int node = 0; node < numOfNodes; node++)
            {
                if (visited[node] == true) continue;
                bool containsCycle = isNodeInCycle(edges, node, visited, currentlyInStack);
                if (containsCycle) return true;
            }
            return false;
        }

        private bool isNodeInCycle(int[][] edges, int node, bool[] visited, bool[] currentlyInStack)
        {
            visited[node] = true;
            currentlyInStack[node] = true;  

            var neighbors = edges[node];
            foreach (var neigbhor in neighbors)
            {
                if (visited[neigbhor] == false)
                {
                    var containsCycle = isNodeInCycle(edges, neigbhor, visited, currentlyInStack);
                    if (containsCycle == true) return true;
                }
                else if(currentlyInStack[neigbhor] == true)
                {
                    return true;
                }
            }
            currentlyInStack[node] = false;
            return false;
        }
    }
}
