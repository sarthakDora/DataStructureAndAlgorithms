using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DataStructureAndAlgo
{
	class FourNumberSum
	{
		public FourNumberSum()
		{
			int[] array = new int[] { 7, 6, 4, -1, 1, 2 }; //Target = 16
			int[] array2 = new int[] { 5, -5, -2, 2, 3, -3 }; //Target = 0
		
			int targetSum = 0;
			var rslt = Sum(array2, targetSum);
		}

		public List<int[]> Sum(int[] array, int targetSum)
		{
			List<int[]> quads = new List<int[]>();
			Hashtable hashTbl = new Hashtable(); //Can be implemented using Dictionary as it is Generic collection type

			for (int i = 0; i < array.Length; i++)
			{
				var curr = array[i];
				for (int j = i+1; j < array.Length; j++)
				{
					var nxt = array[j];
					var sum = curr + nxt;
					var diff = targetSum - sum;
					if(hashTbl.ContainsKey(diff))
					{
						var exisitngList = (List<int[]>)hashTbl[diff];
						foreach (var item in exisitngList)
						{
							quads.Add(new int[] { item[0], item[1], curr, nxt });
						}
						//Take the pairs of that key and add it into the final result
					}
				}
				for (int k = 0; k < i; k++)
				{
					var prev = array[k];
					var prevSum = curr + prev;
					if(!hashTbl.ContainsKey(prevSum))
					{
						var pair = new int[] { curr, prev };
						hashTbl.Add(prevSum, new List<int[]>() { pair });
					}
					else
					{
						var existingPair = (List<int[]>)hashTbl[prevSum];
						existingPair.Add(new int[] { curr, prev });
						hashTbl[prevSum] = existingPair;
					}
				}
			}


			return quads;
		}
	}

}
