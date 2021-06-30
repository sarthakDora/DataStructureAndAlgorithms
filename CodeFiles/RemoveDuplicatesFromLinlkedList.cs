using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class RemoveDuplicatesFromLinlkedList
	{
		public class LinkedList
		{
			public int value;
			public LinkedList next;

			public LinkedList(int value)
			{
				this.value = value;
				this.next = null;
			}
		}
		//1->3->4->4->5->6->6->6->7
		//O(n) time complexity as it si in place replace and O(1) space -- Where n is the number of nodes
		public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
		{
			var currentNode = linkedList;
			while(currentNode != null)
			{
				var nextDistinctNode = currentNode.next;
				while(nextDistinctNode != null && nextDistinctNode.value == currentNode.value)
				{
					nextDistinctNode = nextDistinctNode.next;
				}
				currentNode.next = nextDistinctNode;
				currentNode = nextDistinctNode;
			}
			return linkedList;
		}
	}
}
