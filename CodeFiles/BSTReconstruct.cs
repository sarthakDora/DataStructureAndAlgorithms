using System;
namespace DataStructureAndAlgo
{
    public class TreeInfoForRConstruct
    {
        public int RootIdx { get; set; }
        public TreeInfoForRConstruct(int idx)
        {
            RootIdx = idx;
        }
    }
    public class BSTReconstruct
    {
        public BSTReconstruct()
        {
            var preOrderTraversalValues = new int[] { 10,4,2,1,5,17,19,18};
            var treeInfo = new TreeInfoForRConstruct(0);
            var lowerIdx = int.MinValue;
            var upperIdx = int.MaxValue;
            reconstructBSTFromRange(lowerIdx, upperIdx, preOrderTraversalValues, treeInfo);

        }
        private BST reconstructBSTFromRange(int lowerIdx, int upperIdx, int[] preOrderTraversalValues, TreeInfoForRConstruct currentSubTreeInfo)
        {
            if (currentSubTreeInfo.RootIdx == preOrderTraversalValues.Length) return null; //This means we have finished all of the nodes

            var rootValue = preOrderTraversalValues[currentSubTreeInfo.RootIdx];
            if (rootValue < lowerIdx || rootValue >= upperIdx) return null; // This node is not valid to be added. Also take care of duplicates


            currentSubTreeInfo.RootIdx += 1;
            var leftSubtree = reconstructBSTFromRange(lowerIdx, rootValue, preOrderTraversalValues, currentSubTreeInfo);
            var rightSubtree = reconstructBSTFromRange(rootValue, upperIdx, preOrderTraversalValues, currentSubTreeInfo);

            var newBST = new BST(rootValue);
            newBST.left = leftSubtree;
            newBST.right = rightSubtree;
            
            return newBST;
        }
        
    }
}
