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
            Children.Add(new Node(name));
            return this;
        }
    }
}
