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
		
		private string chosenWord, wordWithSpaces = "", letterToPlay, usedLetters, customTheme; // Game variables
		private int totalMisses = 0;
		private bool win, customWord;
		
		LimitInput limitator = new LimitInput();
		
		public Hangman()
		{
			wordPicker = new Random();
			
			Words themeList = new Words();
			PickTheme(themeList); // Picks the starting theme (the default is always Countries)
		}
		
		#region Settings (Theme)
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
		private void PickTheme(Words themeList)
		{
			customWord = false;
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
						currentThemeName = "Animals";
						break;
					}
				case 2:
					{
						wordList = themeList.fruits;
						currentThemeName = "Fruits";
						break;
					}
				default:
					{
						wordList = null;
						customWord = true;
						currentThemeName = "Custom";
						break;
					}
			}
		}
		
		// Method that picks a new theme, by cycling through the available themes
		public void CycleTheme()
		{
			Words themeList = new Words();
			
			if (currentTheme == themeList.GetThemeAmount())
			{
				currentTheme = 0;
			}
			else
			{
				currentTheme++;
			}
			
			PickTheme(themeList);
		}
		#endregion
		
		#region Drawing the play field and the Hangman
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
			
			Console.SetCursorPosition(20, 16); // Shows theme, either default or custom
			if (customWord)
			{
				Console.Write("Theme: " + customTheme);
			}
			else
			{
				Console.Write("Theme: " + currentThemeName);
			}
		}
		#endregion
		
		#region Game Setup (Building the word and defining custom word)
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
		
		// Method that defines the custom word and theme to be used when "Custom" is chosen as the theme
		// It also has the ability to hide the word (on by default) to prevent the second player from peeking at the screen
		private void DefineCustomWord()
		{
			ConsoleKeyInfo input;
			int inputAscii;
			bool showWord = false;
			
			Console.Clear();
			Console.Write("Enter the theme of your custom word: ");
			customTheme = Console.ReadLine();
			
			Console.SetCursorPosition(0, 12);
			Console.Write("You can use letters or space. \nThe word should have at least 2 characters. \nESC: Erase entire word.     !: Show or hide word.");
			Console.SetCursorPosition(0, 1);
			Console.Write("Enter the word to be guessed: ");
			do
			{
				input = Console.ReadKey(true); // Uses Console.Readkey(true) to hide the input on the screen
				inputAscii = (int)input.KeyChar;
				
				if (inputAscii == 8) // If input is Backspace
				{
					if (chosenWord.Length > 0) // And the word is not empty
					{
						Console.SetCursorPosition(30, 1);
						Console.Write(new String(' ', chosenWord.Length));
						chosenWord = chosenWord.Substring(0, chosenWord.Length - 1); // Removes the last letter from the word
					}
				}
				
				if (inputAscii == 27) // If input is Esc
				{
					Console.SetCursorPosition(30, 1);
					Console.Write(new String(' ', chosenWord.Length));
					chosenWord = ""; // Erases the word
				}
				
				if (inputAscii == 33) // If input is !
				{
					showWord = !showWord; // Alternates between showing and hiding the word on screen
				}
				
				if ((inputAscii == 32) || (inputAscii > 64 && inputAscii < 91) || (inputAscii > 96 && inputAscii < 123)) // Only allows uppercase / lowercase letters and space
				{
					chosenWord += input.KeyChar;
				}
				
				Console.SetCursorPosition(30, 1);
				if (showWord)
				{
					Console.Write(chosenWord); // If set to show word, just shows the word on screen
				}
				else
				{
					Console.Write(new String('*', chosenWord.Length)); // If set to hide word, shows asterisks instead
				}
			}
			while(input.Key != ConsoleKey.Enter || chosenWord.Length < 2); // Keep waiting for input until Enter key is pressed and the word has at least 2 letters
		}
		#endregion
		
		#region Gameplay Methods (Change letter and check win)
		// Method that checks if the currently played letter exists in the chosen word
		private void CompareLetter()
		{
			if (!usedLetters.Contains(letterToPlay.ToUpper())) // Only play if the letter entered wasn't already used
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
					totalMisses++; // Increases misses
				}
			}
		}
		
		// Method that checks if the player won, by checking if there's still any '_' in the word
		private void CheckWin()
		{
			win = !(wordWithSpaces.Contains("_"));
		}
		#endregion
		
		#region Playign the game
		// Method that actually handles playing the game
		public void PlayGame()
		{
			win = false; // Resets all relevant variables
			totalMisses = 0;
			usedLetters = "";
			chosenWord = "";
			
			if (customWord)
			{
				DefineCustomWord();
			}
			else
			{
				chosenWord = wordList[wordPicker.Next(1, wordList.Count + 1)];
			}
			
			BuildWordWithSpaces();
			DrawPlayField();
			
			while(win == false) // Keep going while the word still has spaces
			{
				if (totalMisses == 6) // Stop if the player has 6 misses, which means the hangman is completed
				{
					break;
				}
				
				Console.SetCursorPosition(0, 4);
				Console.Write(new String(' ', 18)); // Used to erase the previously entered letter
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
		#endregion
	}
}
