using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class BSTTraversal
	{
		public Node BST { get; private set; }
		public BSTTraversal()
		{
			loadData();
			var finalOrder = inOrder(BST, new List<int>());
		}
		public void loadData()
		{
			Node tree = new Node(10);
			tree.left = new Node(5);
			tree.left.right = new Node(5);
			tree.right = new Node(15);
			tree.right.right = new Node(22);
			tree.left.left = new Node(2);
			tree.left.left.left = new Node(1);
			BST = tree;
		}
		private List<int> inOrder(Node tree, List<int> array)
		{
			if(tree != null)
			{
				inOrder(tree.left, array);
				array.Add(tree.value);
				inOrder(tree.right, array);
			}
			return array;
		}
		private void preOrder(BinaryTree tree, int[] array)
		{

		}
		private void postOrder(BinaryTree tree, int[] array)
		{

		}

	}
}
