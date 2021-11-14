using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class ValidateBST
    {
        BST _bst;
        public ValidateBST()
        {
            constructBST();
            Console.WriteLine(ValidateBst(_bst)); 
        }
        private void constructBST()
        {
            _bst = new BST(10);
            _bst.Insert(5);
            _bst.Insert(15);
            _bst.Insert(5);
            _bst.Insert(2);
            _bst.Insert(1);
            _bst.Insert(13);
            _bst.Insert(22);
            _bst.Insert(14);
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
