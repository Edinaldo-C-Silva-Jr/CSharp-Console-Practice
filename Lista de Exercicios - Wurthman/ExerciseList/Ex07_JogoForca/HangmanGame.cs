/*
 * Date: 16/10/2023
 * Time: 20:14
 */
using System;
using System.Collections.Generic;

namespace Ex07_JogoForca
{
	public class HangmanGame
	{
		Category wordCategory;
		string wordToPlay, wordWithSpaces;
		int mistakesMade, mistakesAllowed;
		string lettersUsed;
		
		public HangmanGame(Category category, string word)
		{
			wordCategory = category;
			wordToPlay = word.ToUpper();
			mistakesAllowed = 6;
			mistakesMade = 0;
			lettersUsed = "";
			
			BuildWordWithSpaces();
			ShowGameField();
		}
		
		private void BuildWordWithSpaces()
		{
			wordWithSpaces = "";
			
			for (int i = 0; i < wordToPlay.Length; i++)
			{
				if(wordToPlay[i] == ' ')
				{
					wordWithSpaces += "  ";
				}
				else if(Char.IsLetterOrDigit(wordToPlay[i]))
				{
					wordWithSpaces += "_ ";
				}
			}
		}
		
		private void ShowGameField()
		{
			Console.SetCursorPosition(28, 0);
			Console.Write("----- JOGO DA FORCA -----");
			
			Console.SetCursorPosition(30, 8);
			Console.Write("Categoria: " + wordCategory);
			
			Console.SetCursorPosition(10, 10);
			Console.Write("Escolha uma letra: ");
			
			RedrawScores();
		}
		
		private void RedrawScores()
		{
			Console.SetCursorPosition(10, 2);
			Console.Write("Tentativas Disponíveis: " + mistakesAllowed);
			Console.SetCursorPosition(50, 2);
			Console.Write("Tentativas Usadas: " + mistakesMade);
			
			Console.SetCursorPosition(5, 4);
			Console.Write("Letras Utilizadas: " + lettersUsed);
			
			Console.SetCursorPosition(10, 6);
			Console.Write(wordWithSpaces);
		}
		
		private void ChooseLetter()
		{
			Console.SetCursorPosition(29, 10);
			char letter = Char.ToUpper(Console.ReadKey().KeyChar);
			
			if (!Char.IsLetter(letter) || lettersUsed.IndexOf(letter) > -1)
			{
				return;
			}
			
			if (wordToPlay.IndexOf(letter) > -1)
			{
				int count = wordToPlay.IndexOf(letter);
				while(count <= wordToPlay.LastIndexOf(letter))
				{
					if (wordToPlay.Substring(count, 1) == letter.ToString())
					{
						wordWithSpaces = wordWithSpaces.Remove(2*count, 1).Insert(2*count, wordToPlay.Substring(count, 1));
					}
					count++;
				}
			}
			else
			{
				mistakesMade++;
			}
			
			lettersUsed += letter + " ";
			RedrawScores();
		}
		
		private bool CheckWin()
		{
			return wordWithSpaces.IndexOf('_') == -1;
		}
		
		public void PlayGame()
		{
			bool win = false;
			
			while(!win)
			{
				if (mistakesMade == mistakesAllowed)
				{
					break;
				}
				
				ChooseLetter();
				win = CheckWin();
			}
			
			Console.SetCursorPosition(10, 12);
			if (win)
			{
				Console.Write("Fim de jogo, você venceu!");
			}
			else
			{
				Console.Write("Fim de jogo, você perdeu! A palavra era: " + wordToPlay);
			}
			Console.ReadKey();
		}
	}
}
