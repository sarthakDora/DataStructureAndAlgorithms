using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    internal class Node
    {
        public string Name { get; set; }
        public List<Node> Children = new List<Node>();
        public Node(string name)
        {
            this.Name = name;
        }
        public Node AddChild(string name)
        {
            Node child = new Node(name);    
            Children.Add(child);
            return this;
        }
        //Time : O(v+e) | space: O(v)
        public List<string> DeapthFirstSearch(List<string> array)
        {
            array.Add(this.Name);
            for (int i = 0; i < this.Children.Count; i++)
            {
                this.Children[i].DeapthFirstSearch(array);
            }
            return array;
        }
    }
}
