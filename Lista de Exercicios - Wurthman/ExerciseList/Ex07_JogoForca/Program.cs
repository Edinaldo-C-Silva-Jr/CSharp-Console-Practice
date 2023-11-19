/*
 * Date: 15/09/2023
 * Time: 20:57
 */
using System;
using Ex07_JogoForca.Resources;

namespace Ex07_JogoForca
{
	class Program
	{
		public static void Main(string[] args)
		{
			GameSetup setupGame = new GameSetup();
			
			
			setupGame.ReadWordListFile();
			Category wordCategory = setupGame.PickCategory();
			string chosenWord = setupGame.PickWord(wordCategory);
			
			HangmanGame game = new HangmanGame(wordCategory, chosenWord);
		}
	}
}