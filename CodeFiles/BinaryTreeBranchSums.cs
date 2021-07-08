using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class BinaryTreeBranchSums
	{
		public BinaryTreeBranchSums left;
		public BinaryTreeBranchSums right;
		public int value;
		public BinaryTreeBranchSums()
		{
			loadData();
		}
		public BinaryTreeBranchSums(int val)
		{
			this.value = val;
			this.left = null;
			this.right = null;
		}
		public void loadData()
		{
			var left = new BinaryTreeBranchSums(5) { left = new BinaryTreeBranchSums(2), right = new BinaryTreeBranchSums(6), value = 5 };
			var right = new BinaryTreeBranchSums(15) { left = new BinaryTreeBranchSums(13), right = new BinaryTreeBranchSums(22), value = 15 };
			var tree = new BinaryTreeBranchSums(10) { left = left, right = right, value = 10 };
			var rslt = branchSum(tree);
		}
		//Time O(n) and Space O(n) | If we include call stack then space would be log(n)
		public List<int> branchSum(BinaryTreeBranchSums root)
		{
			List<int> sums = new List<int>();
			calculateBranchSum(root, 0, sums);
			return sums;
		}
		private void calculateBranchSum(BinaryTreeBranchSums node, int runningTotal, List<int> sums)
		{
			if (node == null) return;
			int newRunningSum = runningTotal + node.value;
			//Check if the node is leaf
			if(node.left == null && node.right == null)
			{
				sums.Add(newRunningSum);
				return;
			}
			calculateBranchSum(node.left, newRunningSum, sums);
			calculateBranchSum(node.right, newRunningSum, sums);
		}
	}
}
