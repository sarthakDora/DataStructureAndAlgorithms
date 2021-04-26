using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace DataStructureAndAlgo
{
	public class FindFirstNonRepeatingChar
	{
		public FindFirstNonRepeatingChar()
		{
			Console.WriteLine(FirstNonRepeatingCharacterV2("faadabcbbebdf")); 
		}
		//private int FirstNonRepeatingCharacter(string str)
		//{
		//	var hashTbl = new Hashtable();
		//	foreach (var item in str)
		//	{
		//		if(!hashTbl.ContainsKey(item))
		//		{
		//			hashTbl.Add(item, 1);
		//		}
		//		else
		//		{
		//			var val =(int)hashTbl[item];
		//			hashTbl[item] = val +  1;
		//		}
		//	}
		//	var key = hashTbl.Keys.OfType<int>().FirstOrDefault(s => (int)hashTbl[s] == 1);
		//	return -1;
		//}
		private int FirstNonRepeatingCharacterV2(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				var foundDuplicate = false;
				for (int j = 0; j < str.Length; j++)
				{
					if(str[i]==str[j] && i != j)
					{
						foundDuplicate = true;
					}
				}
				if (!foundDuplicate) return i;
			}
			return -1;
		}
	}
}
