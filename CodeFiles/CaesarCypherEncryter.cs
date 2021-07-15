using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class CaesarCypherEncryter
	{
		public CaesarCypherEncryter()
		{
			var str = "xyz";
			int key = 2;
			var rslt = CaesarCypherEncryptor(str, key);
			Console.WriteLine(rslt);
		}
		//Time O(n) and Space o(n)
		public string CaesarCypherEncryptor(string str, int key)
		{
			key = key % 26;
			var edgeCode = char.ConvertToUtf32("z", 0); //122
			var beginCode = char.ConvertToUtf32("a", 0) - 1; //91
			StringBuilder final = new StringBuilder();
			for (int i = 0; i < str.Length; i++)
			{
				var letterValue = char.ConvertToUtf32(str, i) + key;
			
				if(letterValue <= edgeCode)
				{
					final.Append(char.ConvertFromUtf32(letterValue));
				}
				else
				{
					final.Append(char.ConvertFromUtf32(beginCode + letterValue % edgeCode));
				}
			}
			return final.ToString();
		}

	}
}
