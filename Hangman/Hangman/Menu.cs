/*
 * Date: 24/05/2023
 * Time: 13:49
*/
using System;
using System.Media;
using System.Threading;

namespace Hangman
{
	// Implements the menu for the Hangman Game, which can be controlled with the up/down arrow keys and the enter key 
	// It allows the player to start the game, or set a few game options (only the word theme for now)
	public class Menu
	{
		// Method that draws the menu on screen
		private void DrawMenu(string[] settings)
		{
			Console.Clear();
			Console.SetCursorPosition(17 ,0); // Value used to center the text on screen
			Console.Write("----- HANGMAN GAME -----");
			Console.SetCursorPosition(8, 17);
			Console.Write("Arrows: Move     Enter: Select     Esc: Exit");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Start");
			Console.SetCursorPosition(10, 3);
			Console.Write("  Theme: " + settings[0]);
			//Console.SetCursorPosition(10, 4);
			//Console.Write("  ");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Start");
			
		}
		
		// Redraws only the currently selected line
		// Used whenever a setting is changed, to accurately display the changed value without having to redraw the entire menu
		private void RedrawCurrentSelection(string text, string setting, int current)
		{
			Console.SetCursorPosition(10, 2 + current);
			Console.Write("> " + text + setting); // Redraws entire line with the selection cursor
		}
		
		// Moves the "selection cursor" (the > that points at the current option) one option up
		private int MoveSelectionUp(int currentSelection)
		{
			Console.SetCursorPosition(10, 1 + currentSelection); // Draws the cursor on the option above the currently selected
			Console.Write(">");
			Console.SetCursorPosition(10, 2 + currentSelection); // Erases the cursor on the current option
			Console.Write(" ");
			return currentSelection - 1; // Returns the newly selected option
		}
		
		// Moves the "selection cursor" one option down
		private int MoveSelectionDown(int currentSelection)
		{
			Console.SetCursorPosition(10, 2 + currentSelection);
			Console.Write(" ");
			Console.SetCursorPosition(10, 3 + currentSelection);
			Console.Write(">");
			return currentSelection + 1;
		}
		
		// Method that actually starts the menu
		public void StartMenu()
		{
			ConsoleKey menuInput;
			int currentOption = 0;
			Hangman game = new Hangman();
			
			DrawMenu(game.GetCurrentSettings());
			
			do
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0,0);
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput) // Handles user input on the menu
				{
					case ConsoleKey.UpArrow: // Up arrow pressed
						{
							if (currentOption == 0) // If already at the top, can't go up any further
							{
								SystemSounds.Beep.Play();
							}
							else // Otherwise, move one option up
							{
								currentOption = MoveSelectionUp(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow: // Down arrow is pressed
						{
							if (currentOption >= 1) // If already at the bottom, can't go down any further
							{
								SystemSounds.Beep.Play();
							}
							else // Otherwise, move one option down
							{
								currentOption = MoveSelectionDown(currentOption);
							}
							break;
						}
					case ConsoleKey.Enter: // Enter key pressed
						{
							switch(currentOption)
							{
								case 0: // First option: Start game
									{
										Console.CursorVisible = true;
										game.PlayGame();
										DrawMenu(game.GetCurrentSettings());
										break;
									}
								case 1: // Second option: Select the theme by cycling through the themes available
									{
										Console.SetCursorPosition(19, 3); // Changes the name of the theme on the menu
										game.CycleTheme();
										RedrawCurrentSelection("Theme: ", game.GetCurrentSettings()[0], 1);
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape: // Esc key is pressed
						{
							Console.SetCursorPosition(20, 12); // Displays "Thanks for playing" before closing the program
							Console.Write("Thanks for Playing!");
							Thread.Sleep(1000);
							break;
						}
					default: // Any other key is pressed
						{
							SystemSounds.Beep.Play();
							break;
						}
				}
			}
			while(menuInput != ConsoleKey.Escape); // Keep going until Esc is pressed
		}
	}
}
