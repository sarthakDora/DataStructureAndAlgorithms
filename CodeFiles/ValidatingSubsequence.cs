using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DataStructureAndAlgo
{
	public partial class ValidatingSubsequence
	{
		public ValidatingSubsequence()
		{
			List<int> array = new List<int>() { 5, 1, 22, 25, 6, -1, 8, 10 };
			List<int> array2 = new List<int>() { 5, 1, 22, 25, 6, -1, 8, 10 };
			var array3 = new List<int>() { 5, 1, 22, 25, 6, -1, 8, 10 };
			var array4 = new List<int>() { 1,1,1,1,1 };
			List<int> sequence2 = new List<int>() { 1, 6, -1, 10 };
			List<int> sequence = new List<int>() { 100,45,89 };
			List<int> sequence3 = new List<int>() { 22, 25, 6 };
			List<int> sequence4 = new List<int>() { 1,1,1};
			//var result1 = isValidSequenceV1(array4, sequence4);
			var result2 = isValidSequenceV2(array2, sequence2);
			//var result3 = isValidSequenceV3(array3, sequence3);

			Console.WriteLine(result2);
		}
		//Hashtable is not a good solution as array or list can have duplicate items. Hastable will fail as key needs to be unique
		private bool isValidSequenceV1(List<int> array, List<int> sequence)
		{
			array.Sort(); sequence.Sort();

			Hashtable hashTbl = new Hashtable() { };
			foreach (var item in array)
			{
				hashTbl.Add(item, true);
			}
			List<int> finalList = new List<int>();
			foreach (var item in sequence)
			{
				if(hashTbl.ContainsKey(item))
				{
					finalList.Add(item);
				}
			}
			if (finalList.Count == sequence.Count) return true;

			return false;
		}
		private bool isValidSequenceV2(List<int> array, List<int> sequence)
		{
			int arrayIndex = 0;
			int seqIndex = 0;

			while(arrayIndex < array.Count && seqIndex < sequence.Count)
			{
				if(array[arrayIndex] == sequence[seqIndex])
				{
					seqIndex += 1;
				}
				arrayIndex += 1;
			}
			return seqIndex == sequence.Count; 
		}
		private bool isValidSequenceV3(List<int> array, List<int> sequence)
		{
			int arrayIndex = 0;
			int seqIndex = 0;
			for (int i = arrayIndex; i < array.Count; i++)
			{
				if (seqIndex >= sequence.Count) break;
				if(array[i] == sequence[seqIndex])
				{
					seqIndex += 1;
				}
			}
			return seqIndex == sequence.Count;
		}

	}
}
