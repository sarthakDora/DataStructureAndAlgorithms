using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class ClosestValueInBST
	{
		public ClosestValueInBST()
		{
			int target = 12;
			//BST l = new BST(34);
			//l.left = new BST(21);
			//l.left.left = new BST(19);
			BST left = new BST(5) { left = new BST(2), right = new BST(6), value = 5 };			 
			BST right = new BST(15) { left = new BST(13), right = new BST(22), value = 15};
			BST tree = new BST(10) {  left = left, right = right, value = 10};

			var closest = FindClosestValueInBst(tree, target, tree.value);
			Console.WriteLine($"Closest number to {target} in tree is {closest}");

		}
		public int FindClosestValueInBst(BST tree, int target)
		{
			return FindClosestValueInBst(tree, target, tree.value);
		}
		public int FindClosestValueInBst(BST tree, int target, int closest)
		{
			if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
			{
				closest = tree.value;
			}
			if (target < tree.value && tree.left != null)
			{
				return FindClosestValueInBst(tree.left, target, closest);
			}
			else if (target > tree.value && tree.right != null)
			{
				return FindClosestValueInBst(tree.right, target, closest);
			}
			else
			{
				return closest;
			}
		}
	}

	public class BST
	{
		public int value;
		public BST left;
		public BST right;

		public BST(int value)
		{
			this.value = value;
		}
	}

}
