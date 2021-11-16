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
		public virtual BST Insert(int[] values)
        {
            foreach (var value in values)
            {
				Insert(value);
			}
			return this;
        }
		//Average: O(log(n)) time | O(log(n)) space
		public virtual BST Insert(int value)
        {
			if (value < this.value)
			{
				if(this.left == null)
                {
					this.left = new BST(value);
                }
				else this.left.Insert(value);
			}
            else
            {
				if (this.right == null)
                {
					this.right = new BST(value);
                }
				else { this.right.Insert(value); }
            }
			return this;
        }
		//Average: O(log(n)) time | O(log(n)) space
		public virtual bool Contains(int value)
        {
			if (value < this.value)
			{
				if (left == null)
				{
					return false;
				}
				else return left.Contains(value);
			}
			else if (value > this.value)
			{
				if (right == null)
				{
					return false;
				}
				else
				{
					return right.Contains(value);
				}
			}
			else return true;
        }

		public virtual void Remove(int value, BST parent)
        {
			if(value < this.value)
            {
				if(left != null)
                {
					left.Remove(value, this);
                }
            }
			else if(value > this.value)
            {
				if(right != null)
                {
					right.Remove(value, this);
                }
            }
			else
            {
				if(left != null && right != null)
                {
					this.value = right.getMinValue();
					right.Remove(this.value, this);
				}
				else if(parent == null)
                {
					if(left != null)
                    {
						this.value = left.value;
						right = left.right;
						left = left.left;
                    }
					if (right != null)
					{
						this.value = right.value;
						left = right.left;
						right = right.right;
					}
					else { }
				}
				else if(parent.left == this)
                {
					parent.left = left != null ? left : right;
				}
				else if(parent.right == this)
                {
					parent.right = left != null ? left : right;
				}
            }
        }
		private int getMinValue()
		{
			if (left == null)
			{
				return this.value;
			}
			else
			{
				return left.getMinValue();
			}
		}
	}

}
