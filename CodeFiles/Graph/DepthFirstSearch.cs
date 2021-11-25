using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    internal class DepthFirstSearch
    {
        public DepthFirstSearch()
        {
            Node node = new Node("A");
            node.AddChild("B").AddChild("E");
            node.AddChild("C");
            node.AddChild("D").AddChild("G").AddChild("K");
            var final = DeapthFirstSearch(node, new List<string>() { });
            Console.WriteLine(String.Join(",", final));
        }
        //Time : O(v+e) | space: O(v)
        public List<string> DeapthFirstSearch(Node node, List<string> array)
        {
            array.Add(node.Name);
            for (int i = 0; i < node.Children.Count; i++)
            {
                DeapthFirstSearch(node.Children[i], array);
            }
            return array;
        }
    }
}
