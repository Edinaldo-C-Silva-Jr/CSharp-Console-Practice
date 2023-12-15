/*
 * Date: 16/10/2023
 * Time: 20:14
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace Ex07_JogoForca
{
	/// <summary>
	/// A class that implements a Hangman Game, with methods to start the game, play it and a win condition.
	/// </summary>
	public class HangmanGame
	{
		Category wordCategory;
		string wordToPlay, wordWithSpaces;
		int mistakesMade, mistakesAllowed;
		string lettersUsed;
		
		/// <summary>
		/// Starts the hangman game, by resetting all variables and building the word.
		/// </summary>
		/// <param name="category">The category to use for this game.</param>
		/// <param name="word">The word to use for this game.</param>
		/// <param name="difficulty">The difficulty to use for this game.</param>
		private void StartGame(Category category, string word, Difficulty difficulty)
		{
			wordCategory = category;
			wordToPlay = word.ToUpper();
			mistakesAllowed = 7 - (int)difficulty;
			mistakesMade = 0;
			lettersUsed = "";
			
			BuildWordWithSpaces();
		}
		
		/// <summary>
		/// Builds the hidden word to be used while playing the game, changing every letter to a _.
		/// </summary>
		private void BuildWordWithSpaces()
		{
			wordWithSpaces = "";
			
			for (int i = 0; i < wordToPlay.Length; i++)
			{
				if(wordToPlay[i] == ' ') // Skips spaces
				{
					wordWithSpaces += "  ";
				}
				else if(Char.IsLetterOrDigit(wordToPlay[i])) // Changes letters to _
				{
					wordWithSpaces += "_ ";
				}
				else // Leaves special characters unchanged
				{
					wordWithSpaces += wordToPlay[i] + " ";
				}
			}
		}
		
		/// <summary>
		/// Draws the playing field of the game, which shows the word, category, scores and counters.
		/// </summary>
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
		
		/// <summary>
		/// Draws the part of the playing field that changes on every turn, the word, mistakes and letters used.
		/// </summary>
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
		
		/// <summary>
		/// Receives a letter and removes any accent marks from it.
		/// </summary>
		/// <param name="letter">The letter to remove accent marks from.</param>
		/// <returns>The letter without accent marks.</returns>
		private char RemoveAccentMarks(char letter)
		{
			byte[] temporaryBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(letter.ToString());
			string letterWithoutAccentMarks = Encoding.UTF8.GetString(temporaryBytes);
			
			return letterWithoutAccentMarks[0];
		}
		
		/// <summary>
		/// Asks for an input and validates if it is a letter. Only letters will be accepted as input, and it will only be accepted once Enter is pressed.
		/// </summary>
		/// <param name="CursorLeft">The horizontal position of the cursor.</param>
		/// <param name="CursorTop">The vertical position of the cursor.</param>
		/// <returns>The letter entered, after going through validation.</returns>
		private char ReceiveLetterInput(int CursorLeft, int CursorTop)
		{
			ConsoleKeyInfo input;
			char letter = '_'; // Shows a _ to indicate an empty input
			
			Console.SetCursorPosition(29, 10);
			Console.Write(letter);
			
			do
			{
				Console.SetCursorPosition(29, 10); // Keeps the cursor in the same position
				input = Console.ReadKey(true);
				
				if (input.Key != ConsoleKey.Enter) // Ignores validation for Enter key, since that's the confirmation.
				{
					if (!Char.IsLetter(input.KeyChar)) // If input is not a letter, make it blank
					{
						letter = '_';
					}
					else
					{
						letter = input.KeyChar;
					}
					Console.Write(letter); // Shows the chosen letter entered
				}
			}
			while(input.Key != ConsoleKey.Enter && letter != '_'); // Leave when Enter s pressed and the input isn't blank
			
			return letter;
		}
		
		/// <summary>
		/// Represents a turn of the game.
		/// The player inputs a letter.
		/// The game then checks if that letter has already been used.
		/// And finally checks if the letter exists in the word.
		/// </summary>
		private void ChooseLetter()
		{
			char letter = Char.ToUpper(ReceiveLetterInput(29, 10));
			letter = RemoveAccentMarks(letter);
			
			if (!Char.IsLetter(letter) || lettersUsed.IndexOf(letter) > -1) // If letter was already used, do nothing
			{
				return;
			}
			
			if (wordToPlay.IndexOf(letter) > -1) // If letter exists in the word, show it
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
			else // Otherwise, one more mistake
			{
				mistakesMade++;
			}
			
			lettersUsed += letter + " ";
			RedrawScores();
		}
		
		/// <summary>
		/// Checks the win condition, which is whether there are any _ in the word.
		/// </summary>
		/// <returns>True if the player won the game, false if the game is still running.</returns>
		private bool CheckWin()
		{
			return wordWithSpaces.IndexOf('_') == -1;
		}
		
		/// <summary>
		/// Actually plays the game, running the turns, checking win and lose conditions and updating counters and scores. 
		/// </summary>
		/// <param name="category">The category to use for this game.</param>
		/// <param name="word">The word to use for this game.</param>
		/// <param name="difficulty">The difficulty to use for this game.</param>
		public void PlayGame(Category category, string word, Difficulty difficulty)
		{
			StartGame(category, word, difficulty);
			
			Console.Clear();
			ShowGameField();
			
			bool win = false;
			
			while(!win) // Keep playing until the player wins...
			{
				if (mistakesMade == mistakesAllowed) // ...or all mistakes are made.
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
			Thread.Sleep(1000);
			Console.ReadKey();
		}
	}
}
