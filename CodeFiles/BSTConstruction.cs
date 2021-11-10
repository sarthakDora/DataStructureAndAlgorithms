using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	public class BSTConstruction
	{
		int val;
		BSTConstruction left;
		BSTConstruction right;
		public BSTConstruction(int value)
		{
			this.val = value;
		}
		//Average: O(log(n)) time | O(log(n)) space
		public BSTConstruction Insert(int value)
		{
			if(value < this.val)
            {
				if(this.left == null)
                {
					var newBST = new BSTConstruction(value);
					this.left = newBST;
                }
				else
                {
					left.Insert(value);
                }
            }
            else
            {
				if(this.right == null)
                {
					var newBST = new BSTConstruction(value);
					right = newBST;
                }
                else
                {
					right.Insert(value);
                }
            }
			return this;
		}
		//Average: O(log(n)) time | O(log(n)) space
		public bool Contains(int value)
        {
			if(value < this.val)
            {
				if(left == null)
                {
					return false;
                }
				else
                {
					return left.Contains(value);
                }
            }
			else if(value > this.val)
            {
				if(right == null)
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
		public BSTConstruction Remove(int value)
        {
			Remove(value, null);
			return this;
        }
		public void Remove(int value, BSTConstruction parent)
        {
			if(value < this.val)
            {
				if(left != null)
                {
					left.Remove(value, this);
                }
            }
			else if(value > this.val)
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
					this.val = right.getMinValue();
					right.Remove(this.val, this);
				}
				else if(parent == null)
                {
					if(left != null)
                    {
						this.val = left.val;
						right = left.right;
						left = left.left;
                    }
					else if(right != null)
                    {
						this.val = right.val;
						left = right.left;
						right = right.right;

                    }
                    else
                    {
						//For single node tree do nothing
                    }
                }
                else if(parent.left == this)
                {
					parent.left = left != null ? left : right;
                }
				else if (parent.right == this)
				{
					parent.right = left != null ? left : right;
				}
			}
        }
		public int getMinValue()
        {
			if(left == null)
            {
				return this.val;
            }
            else
            {
				return left.getMinValue();
            }
        }
	}
}
