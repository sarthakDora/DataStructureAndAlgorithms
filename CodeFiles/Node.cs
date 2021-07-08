using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class Node
	{
		public int value;
		public Node left;
		public Node right;
		public Node(int val)
		{
			this.value = val;
			this.left = this.right = null;
		}
	}
	public class BinaryTree
	{
		public Node root;
		public BinaryTree(int key)
		{
			this.root = new Node(key);
		}
		public BinaryTree()
		{
			root = null;
		}
	}
}
