using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    internal class BreadthFirstSearch
    {
        public BreadthFirstSearch()
        {
            var node = new Node("A");
            node.AddChild("B").AddChild("C").AddChild("D");
            node.Children[0].AddChild("E").AddChild("F");
            node.Children[2].AddChild("G").AddChild("H");
            var final = BFS(node, new List<string> { });
            Console.WriteLine(String.Join(",", final));
        }
        //Time : O(v+e) | space: O(v) | v --> vertices & e --> edges
        public List<string> BFS(Node node, List<string> array)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                array.Add(current.Name);
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return array;
        }
    }
}
