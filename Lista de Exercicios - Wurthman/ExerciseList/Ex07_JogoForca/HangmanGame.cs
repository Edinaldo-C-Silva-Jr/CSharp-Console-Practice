/*
 * Date: 16/10/2023
 * Time: 20:14
*/
using System;

namespace Ex07_JogoForca
{
	public class HangmanGame
	{
		Category category;
		string word, wordWithSpaces;
		
		public HangmanGame(Category category, string word)
		{
			this.category = category;
			this.word = word;
			
			BuildWordWithSpaces();
		}
		
		private void BuildWordWithSpaces()
		{
			wordWithSpaces = "";
			
			for (int i = 0; i < word.Length; i++)
			{
				if(word[i] == ' ')
				{
					wordWithSpaces += "  ";
				}
				else if(Char.IsLetterOrDigit(word[i]))
				{
					wordWithSpaces += "_ ";
				}
			}
			
			Console.WriteLine(category);
			Console.WriteLine(word);
			Console.WriteLine(wordWithSpaces);
			Console.ReadKey();
		}
	}
}
