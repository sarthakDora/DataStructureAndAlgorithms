using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class ValidateBST
    {
        readonly BST _bst;
        public ValidateBST()
        {
            _bst = new BST(10) { left = new BST(5), right = new BST(15) };
            _bst.left.right = new BST(5);
            _bst.left.left = new BST(2);
            _bst.left.left.left = new BST(1);
            _bst.right.left = new BST(13);
            _bst.right.right = new BST(22);
            _bst.right.left.right = new BST(14);
            Console.WriteLine(ValidateBst(_bst)); 
        }
        public bool ValidateBst(BST tree)
        {
            return isValidateHelper(tree, int.MinValue, int.MaxValue);
        }
        private bool isValidateHelper(BST tree, int minVal, int maxVal)
        {
            if(tree == null) return true;
            if(tree.value < minVal || tree.value >=  maxVal) return false;
            var isLeftVaild = isValidateHelper(tree.left, minVal, tree.value);
            if (isLeftVaild && isValidateHelper(tree.right, tree.value, maxVal)) return true;
            return false;
        }
    }
}
