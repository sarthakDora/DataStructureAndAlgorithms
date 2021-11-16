using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class BSTFindKLargestValue
    {
        public BSTFindKLargestValue()
        {
            var array = new int[] { 1, 2, 3, 5, 5, 15, 20, 17, 22 };
            var bst = new BSTMinHeight().constructMinHeightBSTV3(array, 0, array.Length - 1);

        }
    }
}
