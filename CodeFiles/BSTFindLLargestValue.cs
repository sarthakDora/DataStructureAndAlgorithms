using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    public class TreeInfo
    {
        public int NumberOfNodesVisited { get; set; }
        public int NodeLatestValue { get; set; }
        public TreeInfo(int nodesVisited, int latestVal)
        {
            NumberOfNodesVisited = nodesVisited;
            NodeLatestValue = latestVal;    
        }
    }
    internal class BSTFindKLargestValue
    {
        public BSTFindKLargestValue()
        {
            var array = new int[] { 1, 2, 3, 5, 5, 15, 20, 17, 22 };
            var bst = new BSTMinHeight().constructMinHeightBSTV3(array, 0, array.Length - 1);
            Console.WriteLine(FindKthLargestValueInBst_ViaInOrder(bst, 3));
            Console.WriteLine(FindKthLargestValueInBst_ViaReverseInOrder(bst,3));
        }
        public int FindKthLargestValueInBst_ViaInOrder(BST tree, int k)
        {
            List<int> sortedValues = new List<int>();
            inOrder(tree, sortedValues);
            var final = sortedValues[sortedValues.Count - k];
            return final;

        }
        private void inOrder(BST tree, List<int> array)
        {
            if (tree != null)
            {
                inOrder(tree.left, array);
                array.Add(tree.value);
                inOrder(tree.right, array);
            }
        }

        public int FindKthLargestValueInBst_ViaReverseInOrder(BST tree, int k)
        {
            TreeInfo treeInfo = new TreeInfo(0, -1);

            reverseInOrder(tree, k, treeInfo);
 
            return treeInfo.NodeLatestValue;

        }
        private void reverseInOrder(BST tree, int k, TreeInfo treeInfo)
        {
            if (tree == null || treeInfo.NumberOfNodesVisited >= k) return;

            reverseInOrder(tree.right, k, treeInfo);
            if(treeInfo.NumberOfNodesVisited < k)
            {
                treeInfo.NumberOfNodesVisited += 1;
                treeInfo.NodeLatestValue = tree.value;
                reverseInOrder(tree.left, k,treeInfo);
            }
        }
    }
}
