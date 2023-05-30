/*
 * Date: 24/05/2023
 * Time: 14:10
 */
using System;
using System.Text;
using System.Collections.Generic;
using InputLimitator;

namespace Hangman
{
	public class Hangman
	{
		private int currentTheme = 0; // Theme related variables
		private string currentThemeName = "";
		
		private Random wordPicker; // Word list related variables
		private Dictionary<int, string> wordList;
		
		private string chosenWord, wordWithSpaces = "", letterToPlay, usedLetters; // Game variables
		private int totalMisses = 0;
		private bool win;
		
		LimitInput limitator = new LimitInput();
		
		public Hangman()
		{
			wordPicker = new Random();
			PickTheme(); // Picks the starting theme (the default is always Countries)
		}
		
		// Returns the current settings for the game
		// Note: Currently there's only one, but there will be more settings eventually
		public string[] GetCurrentSettings()
		{
			string[] settings = new String[1];
			
			settings[0] = currentThemeName;
			
			return settings;
		}
		
		// Method that picks the theme, based on the currentTheme variable, and loads the words into the themeList
		// Also saves the current theme's name to return to the menu
		private void PickTheme()
		{
			Words themeList = new Words();
			
			switch(currentTheme)
			{
				case 0:
					{
						wordList = themeList.countries;
						currentThemeName = "Countries";
						break;
					}
				case 1:
					{
						wordList = themeList.animals;
						currentThemeName = "Animals  ";
						break;
					}
			}
		}
		
		// Method that picks a new theme, by cycling through the available themes
		public void CycleTheme()
		{
			if (currentTheme == 1)
			{
				currentTheme = 0;
			}
			else
			{
				currentTheme++;
			}
			
			PickTheme();
		}
		
		// Method that draws the hangman on screen, depending on the amount of errors the player has made in the current game
		// Redraws only the necessary line for the current amount of misses
		private void RedrawHangMan()
		{
			switch(totalMisses)
			{
				case 1: // 1 miss: Head
					{
						Console.SetCursorPosition(40, 5);
						Console.Write(" O     | ");
						break;
					}
				case 2: // 2 misses: Body
					{
						Console.SetCursorPosition(40, 6);
						Console.Write(" |     | ");
						break;
					}
				case 3: // 3 misses: Left arm
					{
						Console.SetCursorPosition(40, 6);
						Console.Write("/|     | ");
						break;
					}
				case 4: // 4 misses: Right arm
					{
						Console.SetCursorPosition(40, 6);
						Console.Write("/|\\    | ");
						break;
					}
				case 5: // 5 misses: Left leg
					{
						Console.SetCursorPosition(40, 7);
						Console.Write("/      | ");
						break;
					}
				case 6: // 6 misses: Right leg
					{
						Console.SetCursorPosition(40, 7);
						Console.Write("/ \\    | ");
						break;
					}
			}
		}
		
		// Redraws the relevant parts of the playfield after every turn played
		private void RedrawPlayField()
		{
			Console.SetCursorPosition(0, 2);
			Console.Write(wordWithSpaces);
			
			Console.SetCursorPosition(10, 11); // Shows the letters that have already been used on the screen
			for (int i = 0; i < usedLetters.Length; i++)
			{
				Console.Write(usedLetters.Substring(i, 1) + " ");
			}
			
			RedrawHangMan(); // Redraws the relevant part of the hangman
		}
		
		// Draws the playfield once the game starts
		private void DrawPlayField()
		{
			Console.Clear();
			
			Console.SetCursorPosition(17, 0); // Centers the text on screen
			Console.Write("----- HANGMAN GAME -----");
			
			Console.SetCursorPosition(0, 3); // Drawing the starting hangman
			Console.Write(new String(' ', 40) + " ------- \n");
			Console.Write(new String(' ', 40) + " |     | \n");
			Console.Write(new String(' ', 40) + "       | \n");
			Console.Write(new String(' ', 40) + "       | \n");
			Console.Write(new String(' ', 40) + "       | \n");
			Console.Write(new String(' ', 40) + "      ---");
			
			Console.SetCursorPosition(0, 2); // Shows the spaces that correspond to the letters of the chosen word
			Console.Write(wordWithSpaces);
			
			Console.SetCursorPosition(20, 16);
			Console.Write("Theme: " + currentThemeName);
		}
		
		// Method that checks if the currently played letter exists in the chosen word
		private void CompareLetter()
		{
			if (!usedLetters.Contains(letterToPlay.ToLower())) // Only play if the letter wasn't already used
			{
				usedLetters += letterToPlay.ToUpper(); // The letter is now used
				bool error = true;
				
				for (int i = 0; i < chosenWord.Length; i++)
				{
					if (chosenWord.Substring(i, 1).ToLower() == letterToPlay.ToLower()) // Compares the letter to each letter in the chosen word
					{
						wordWithSpaces = wordWithSpaces.Remove(i*2, 1); // If it exists, change the space to the correct letter
						wordWithSpaces = wordWithSpaces.Insert(i*2, chosenWord.Substring(i, 1));
						error = false; // And don't count this turn as a miss
					}
				}
				
				if (error) // If the turn is still counted as a miss (that is, the letter doesn't exist in the chosen word)
				{
					totalMisses++;
				}
			}
		}
		
		// Method that checks if the player won, by checking if there's still any '_' in the word
		private void CheckWin()
		{
			win = !(wordWithSpaces.Contains("_"));
		}
		
		// Builds the word with spaces (hiding the original word) to be displayed in the game
		private void BuildWordWithSpaces()
		{
			wordWithSpaces = "";
			
			for (int i = 0; i < chosenWord.Length; i++)
			{
				if(chosenWord.Substring(i, 1) == " ")
				{
					wordWithSpaces += "  ";
				}
				else
				{
					wordWithSpaces += "_ ";
				}
			}
		}
		
		// Method that actually handles playing the game
		public void PlayGame()
		{
			win = false; // Resets all relevant variables
			totalMisses = 0;
			usedLetters = "";
			
			chosenWord = wordList[wordPicker.Next(1, wordList.Count + 1)];
			
			BuildWordWithSpaces();
			DrawPlayField();
			
			while(win == false) // Keep going while the word still has spaces
			{
				if (totalMisses == 6) // Stop if the player has 6 misses, which means the hangman is completed
				{
					break;
				}
				
				Console.SetCursorPosition(0, 4);
				Console.Write("Enter a letter: ");
				letterToPlay = limitator.LimitInputLetterOnly(1, 1); // Asks for an input, and guarantees it will be a letter (uppercase or lowercase)
				
				CompareLetter();
				RedrawPlayField();
				CheckWin();
			}
			
			Console.SetCursorPosition(0, 4);
			if (win)
			{
				Console.Write("Congratulations! You won!");
			}
			else
			{
				Console.Write("Oh no! You didn't make it!\n");
				Console.Write("The correct word was: \n" + chosenWord);
			}
			Console.ReadKey(true);
		}
	}
}
