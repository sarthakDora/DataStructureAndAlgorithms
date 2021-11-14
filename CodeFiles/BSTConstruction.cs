using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class BSTConstruction
	{
		public BSTConstruction(int value)
		{
			var bst = new BST(value);
			bst.Insert(5);
			bst.Insert(5);
			bst.Insert(13);
			bst.Insert(2);

            Console.WriteLine(bst.Contains(5));
			bst.Remove(2, null);
		}
	}
}
