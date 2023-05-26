/*
 * Date: 24/05/2023
 * Time: 13:49
*/
using System;
using System.Media;
using System.Threading;

namespace Hangman
{
	public class Menu
	{
		private void DrawMenu()
		{
			Console.Clear();
			Console.SetCursorPosition(0,0);
			Console.Write("----- Hangman Game -----");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Start");
			Console.SetCursorPosition(10, 3);
			Console.Write("  Theme: Countries");
			//Console.SetCursorPosition(10, 4);
			//Console.Write("  ");
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
		
		public void StartMenu()
		{
			ConsoleKey menuInput;
			int currentOption = 0;
			Hangman game = new Hangman();
			
			DrawMenu();
			
			do
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0,0);
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput)
				{
					case ConsoleKey.UpArrow:
						{
							if (currentOption == 0)
							{
								SystemSounds.Beep.Play();
							}
							else
							{
								currentOption = MoveSelectionUp(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (currentOption >= 3)
							{
								SystemSounds.Beep.Play();
							}
							else
							{
								currentOption = MoveSelectionDown(currentOption);
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							switch(currentOption)
							{
								case 0:
									{
										game.PlayGame();
										DrawMenu();
										break;
									}
								case 1:
									{
										Console.SetCursorPosition(19, 3);
										Console.Write(game.CycleTheme());
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.SetCursorPosition(0, 12);
							Console.Write("Thanks for Playing!");
							Thread.Sleep(1000);
							break;
						}
					default:
						{
							break;
						}
				}
			}
			while(menuInput != ConsoleKey.Escape);
		}
	}
}
