/*
 * Date: 17/06/2023
 * Time: 16:46
 */
using System;
using System.Media;
using System.Threading;

namespace MineSweeper
{
	// A class that implements the menu for the game of MineSweeper
	public class Menu
	{
		int xSize, ySize, mineCount;
		
		public Menu()
		{
			xSize = ySize = mineCount = 10;
		}
		
		#region Draw Menu
		private void DrawMenu()
		{
			Console.SetWindowSize(60, 25);
			Console.SetBufferSize(60, 25);
			Console.Clear();
			
			Console.SetCursorPosition(17, 0); // Displays the game title centered on the screen
			Console.Write("----- Mine Sweeper -----");
			
			Console.SetCursorPosition(0, 22);
			Console.Write("Arrows: Move Selection    Enter: Select Option    Esc: Exit");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Start Game");
			
			Console.SetCursorPosition(10, 3);
			Console.Write("  Horizontal Size: " + xSize);
			Console.SetCursorPosition(10, 4);
			Console.Write("  Vertical Size: " + ySize);
			Console.SetCursorPosition(10, 5);
			Console.Write("  Amount of Mines: " + mineCount);
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
		#endregion
		
		private void DrawOptionChoiceWindow(int amountOfOptions)
		{
			Console.SetCursorPosition(0, 9);
			Console.Write("   Choose the desired amount from the available options:\n     ");
			
			for (int i = 1; i < amountOfOptions + 1; i++)
			{
				if (i < 2)
				{
					Console.Write("00" + 5*i + "  ");
				}
				else
				{
					if (i < 20)
					{
						Console.Write("0" + 5*i + "  ");
					}
					else
					{
						Console.Write(5*i + "  ");
					}
				}
				
				if (i % 10 == 0)
				{
					Console.Write("\n     ");
				}
			}
		}
		
		private void DrawOptionChoiceSelectionCursor(int currentlySelectedOption)
		{
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 - 1, (currentlySelectedOption / 10 + 10));
			Console.Write(">");
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 + 3, (currentlySelectedOption / 10 + 10));
			Console.Write("<");
		}
		
		private void EraseOptionChoiceSelectionCursor(int currentlySelectedOption)
		{
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 - 1, (currentlySelectedOption / 10 + 10));
			Console.Write(" ");
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 + 3, (currentlySelectedOption / 10 + 10));
			Console.Write(" ");
		}
		
		private int ControlOptionChoiceWindow(int maxAmountOfOptions)
		{
			ConsoleKey optionInput;
			int currentOptionChoice = 0;
			DrawOptionChoiceSelectionCursor(0);
			
			do
			{
				optionInput = Console.ReadKey(true).Key;
				EraseOptionChoiceSelectionCursor(currentOptionChoice);
				
				switch(optionInput)
				{
					case ConsoleKey.UpArrow: // Up arrow pressed
						{
							if (currentOptionChoice > 9) // If not at the top, then move one option up
							{
								currentOptionChoice -= 10;
							}
							break;
						}
					case ConsoleKey.DownArrow: // Down arrow pressed
						{
							if (currentOptionChoice < maxAmountOfOptions - 10) // If not at the bottom, then move one option down
							{
								currentOptionChoice += 10;
							}
							break;
						}
					case ConsoleKey.LeftArrow: // Left arrow pressed
						{
							if (currentOptionChoice % 10 != 0) // If not at the left, then move one option left
							{
								currentOptionChoice--;
							}
							break;
						}
					case ConsoleKey.RightArrow: // Right arrow pressed
						{
							if (currentOptionChoice % 10 != 9 && currentOptionChoice != maxAmountOfOptions - 1) // If not at the right edge or at maximum option available, then move one option right
							{
								currentOptionChoice++;
							}
							break;
						}
					default: // Any other key is pressed
						{
							SystemSounds.Beep.Play();
							break;
						}
				}
				
				DrawOptionChoiceSelectionCursor(currentOptionChoice);
			}
			while (optionInput != ConsoleKey.Enter); // Keep going until Esc is pressed
			
			Console.SetCursorPosition(0, 9);
			Console.Write(new String(' ', 660));
			
			return (currentOptionChoice + 1) * 5;
		}
		
		private void ChangeHorizontalSize()
		{
			DrawOptionChoiceWindow(8);
			xSize = ControlOptionChoiceWindow(8);
			
			Console.SetCursorPosition(29, 3);
			Console.Write(xSize + " ");
			CheckMineCount();
		}
		
		private void ChangeVerticalSize()
		{
			DrawOptionChoiceWindow(5);
			ySize = ControlOptionChoiceWindow(5);
			
			Console.SetCursorPosition(27, 4);
			Console.Write(ySize + " ");
			CheckMineCount();
		}
		
		private void ChangeMineAmount()
		{
			DrawOptionChoiceWindow(ySize * xSize / 10);
			mineCount = ControlOptionChoiceWindow(ySize * xSize / 10);
			
			Console.SetCursorPosition(29, 5);
			Console.Write(mineCount + " ");
			CheckMineCount();
		}
		
		private void CheckMineCount()
		{
			if (mineCount > xSize * ySize / 2)
			{
				mineCount = xSize * ySize / 2;
				mineCount = mineCount - mineCount % 5;
			}
			Console.SetCursorPosition(29, 5);
			Console.Write(mineCount + "   ");
		}
		
		#region Start the Menu
		// Actually starts the menu and gives the player control of it
		public void StartMenu()
		{
			ConsoleKey menuInput;
			int currentOption = 0;
			MineSweeper game;
			
			DrawMenu();
			
			do
			{
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput)
				{
					case ConsoleKey.UpArrow: // Up arrow pressed
						{
							if (currentOption <= 0) // If already at the top, can't move up any further
							{
								SystemSounds.Beep.Play();
							}
							else // If not at the top, then move one option up
							{
								currentOption = MoveSelectionUp(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow: // Down arrow pressed
						{
							if (currentOption >= 3) // If already at the bottom, can't go down any further
							{
								SystemSounds.Beep.Play();
							}
							else // If not at the bottom, then move one option down
							{
								currentOption = MoveSelectionDown(currentOption);
							}
							break;
						}
					case ConsoleKey.Enter: // Enter key pressed
						{
							switch(currentOption)
							{
								case 0: // First option: Start Game
									{
										game = new MineSweeper(xSize, ySize, mineCount);
										game.StartGame(); // Starts the game, passing the current settings in the constructor
										DrawMenu(); // Once it's over, redraw the entire menu
										break;
									}
								case 1: // Second option: Set horizontal size of minefield
									{
										ChangeHorizontalSize();
										break;
									}
								case 2: // Third option: Set vertical size of minefield
									{
										ChangeVerticalSize();
										break;
									}
								case 3: // Fourth option: Set mine amount
									{
										ChangeMineAmount();
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape: // Esc is pressed
						{
							Console.SetCursorPosition(20, 20);
							Console.Write("Thanks for playing!");
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
			while (menuInput != ConsoleKey.Escape); // Keep going until Esc is pressed
		}
		#endregion
	}
}
