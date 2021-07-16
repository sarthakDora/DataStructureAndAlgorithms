using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class RunLengthEncoding
	{
		public RunLengthEncoding()
		{
			Console.WriteLine(RunLength("AAAAAAAAAAAAAABBBCCCCDDD"));
		}
		public string RunLength(string str)
		{
			StringBuilder charsCollection = new StringBuilder();
			int currLength = 1;
			for (int i = 1; i < str.Length; i++)
			{
				var currChar = str[i];
				var prevChar = str[i - 1];
				if (currChar != prevChar || currLength == 9)
				{
					charsCollection.Append(currLength.ToString());
					charsCollection.Append(prevChar);
					currLength = 0;
				}
				currLength += 1;
			}
			//Handle the last run
			charsCollection.Append(currLength.ToString());
			charsCollection.Append(str[str.Length - 1]);


			return charsCollection.ToString();
		}
	}
}
