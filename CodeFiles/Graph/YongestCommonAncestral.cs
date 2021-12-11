using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    public class YongestCommonAncestral
    {
        public YongestCommonAncestral()
        {
			var trees = getNewTrees();
			trees['A'].AddAsAncestor(new AncestralTree[] { trees['B'], trees['C'] });
			trees['B'].AddAsAncestor(new AncestralTree[] { trees['D'], trees['E'] });
			trees['D'].AddAsAncestor(new AncestralTree[] { trees['H'], trees['I'] });
			trees['C'].AddAsAncestor(new AncestralTree[] { trees['F'], trees['G'] });
			var ygCommnAncestor = GetYoungestCommonAncestor(trees['A'],	trees['E'],	trees['I']);


		}
		public AncestralTree GetYoungestCommonAncestor(AncestralTree topAncestor, AncestralTree descendantOne, AncestralTree descendantTwo)
		{
			var firstDescDepth = getDepth(topAncestor, descendantOne);
			var secondDescDepth = getDepth(topAncestor, descendantTwo);
			if(firstDescDepth > secondDescDepth)
            {
				return backtrackingToAncestral(descendantOne, descendantTwo, firstDescDepth - secondDescDepth);

			}
			else
            {
				return backtrackingToAncestral(descendantTwo, descendantOne, secondDescDepth - firstDescDepth);
			}
		
		}
		private AncestralTree backtrackingToAncestral(AncestralTree lowestDescendant, AncestralTree topDescendant, int depthDiff)
        {
			//Get the lowestDescendant to the same leve as topDescendant
			while (depthDiff != 0)
            {
				depthDiff--;
				lowestDescendant = lowestDescendant.ancestor;
            }
			while(lowestDescendant != topDescendant)
            {
				lowestDescendant = lowestDescendant.ancestor;
				topDescendant = topDescendant.ancestor;
            }
			return lowestDescendant; 
        }
		private int getDepth(AncestralTree topAncestor, AncestralTree descendant)
        {
			var depth = 0;
			while (descendant != topAncestor)
            {
				depth++;
				descendant = descendant.ancestor;
            }
			return depth;
        }
		public Dictionary<char, AncestralTree> getNewTrees()
		{
			var trees = new Dictionary<char, AncestralTree>();
			var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			foreach (char a in alphabet)
			{
				trees.Add(a, new AncestralTree(a));
			}

			trees['A'].AddAsAncestor(new AncestralTree[] {
			trees['B'],
			trees['C'],
			trees['D'],
			trees['E'],
			trees['F']
		});
			return trees;
		}
	}
	public class AncestralTree
	{
		public char name;
		public AncestralTree ancestor;

		public AncestralTree(char name)
		{
			this.name = name;
			this.ancestor = null;
		}

		// This method is for testing only.
		public void AddAsAncestor(AncestralTree[] descendants)
		{
			foreach (AncestralTree descendant in descendants)
			{
                descendant.ancestor = this;
			}
		}
	}
}
