using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class CharacterDocumentMatch
	{
		public CharacterDocumentMatch()
		{
			var characters = "pathakweriuv sarthakoiweridjf";
			var document = "sartha pathak";
			Console.WriteLine(GenerateDocument(characters, document));
		}
		//Time O(n+m)	| Space O(c)
		public bool GenerateDocument(string characters, string document)
		{
			Dictionary<char, int> characterCout = new Dictionary<char, int>();

			foreach (var character in characters)
			{
				if(!characterCout.ContainsKey(character))
				{
					characterCout.Add(character, 1);
				}
				else
				{
					characterCout[character] += 1; 
				}
			}

			foreach (var character in document)
			{
				if(characterCout.ContainsKey(character) && characterCout[character] >0)
				{
					characterCout[character] -= 1;
				}
				else
				{
					return false;
				}

			}

			return true;
		}
	}
}
