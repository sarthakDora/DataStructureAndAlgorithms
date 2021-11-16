using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class BSTMinHeight
    {
        public BSTMinHeight()
        {
            var solution1 = minHeightBST(new int[] {1,2,5,7,10,13,14,15,22 });
            var solution2 = minHeightBST(new int[] { 1, 2, 5, 7, 10, 13, 14, 15, 22 }, true);
            var solution3 = minHeightBST(new int[] { 1, 2, 5, 7, 10, 13, 14, 15, 22 }, false, true);
        }
        private BST minHeightBST(int[] array, bool runV2 = false, bool runV3 = false)
        {
            if (runV3) return constructMinHeightBSTV3(array, 0, array.Length - 1);
            if (runV2) return constructMinHeightBSTV2(array, null, 0, array.Length - 1);
            return constructMinHeightBST(array, null, 0, array.Length-1);
        }
        //Time = O(Nlog(N)) | Space = O(N)
        private BST constructMinHeightBST(int[] array, BST bst, int startIdx, int endIdx)
        {
            if (endIdx < startIdx) return bst;
            var midIdx = Convert.ToInt32(Math.Floor(Convert.ToDecimal((startIdx + endIdx) / 2)));
            var valueToAdd = array[midIdx];
            if (bst == null) bst = new BST(valueToAdd);
            else bst.Insert(valueToAdd);
            constructMinHeightBST(array, bst, startIdx, midIdx-1);
            constructMinHeightBST(array, bst, midIdx+1, endIdx);
            return bst;
        }
        //Time = O(N) | Space = O(N)
        private BST constructMinHeightBSTV2(int[] array, BST bst, int startIdx, int endIdx)
        {
            if (endIdx < startIdx) return bst;
            var midIdx = Convert.ToInt32(Math.Floor(Convert.ToDecimal((startIdx + endIdx) / 2)));
            var newBSTNode = new BST(array[midIdx]);
            if (bst == null) bst = newBSTNode;
            else if(array[midIdx] < bst.value)
            {
                bst.left = newBSTNode;
                bst = bst.left;
            }
            else if(array[midIdx] > bst.value)
            {
                bst.right = newBSTNode;
                bst = bst.right;
            }
            constructMinHeightBSTV2(array, bst, startIdx, midIdx - 1);
            constructMinHeightBSTV2(array, bst, midIdx + 1, endIdx);
            return bst;
        }
        //Time = O(N) | Space = O(N) ----------> This one is most elegant method
        internal BST constructMinHeightBSTV3(int[] array, int startIdx, int endIdx)
        {
            if (endIdx < startIdx) return null;
            var midIdx = Convert.ToInt32(Math.Floor(Convert.ToDecimal((startIdx + endIdx) / 2)));
            var bst = new BST(array[midIdx]);
            bst.left = constructMinHeightBSTV3(array, startIdx, midIdx - 1);
            bst.right =  constructMinHeightBSTV3(array, midIdx + 1, endIdx);
            return bst;
        }
    }
}
