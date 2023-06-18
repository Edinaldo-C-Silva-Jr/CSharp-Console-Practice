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
		// Draws the game menu on screen
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
		
		#region Handling Option Values Submenu
		// Method that draws on the screen all the values that can be selected for the current option
		// It receives the amount of available values as a parameter
		private void DrawOptionChoiceSubmenu(int amountOfOptions)
		{
			Console.SetCursorPosition(0, 9);
			Console.Write("   Choose the desired amount from the available options:\n     ");
			
			for (int i = 1; i < amountOfOptions + 1; i++) // Cycles through all options, starts at 1 because there can't be a zero option
			{
				string number = (i*5).ToString();
				
				if (number.Length < 3) // Makes sure the numbers always have the same length (a 5 becomes 005)
				{
					number = new String('0', 3 - number.Length) + number;
				}
				Console.Write(number + "  ");
				
				if (i % 10 == 0) // Goes to the next line after 10 options
				{
					Console.Write("\n     ");
				}
			}
		}
		
		// Draws the "selection cursor" (the "> <" that points at the current option) on the selected option
		private void DrawOptionChoiceSelectionCursor(int currentlySelectedOption)
		{
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 - 1, (currentlySelectedOption / 10 + 10)); // Formula to get the correct screen position for drawing
			Console.Write(">");
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 + 3, (currentlySelectedOption / 10 + 10));
			Console.Write("<");
		}
		
		// Erases the "selection cursor" from the selected option
		private void EraseOptionChoiceSelectionCursor(int currentlySelectedOption)
		{
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 - 1, (currentlySelectedOption / 10 + 10));
			Console.Write(" ");
			Console.SetCursorPosition((currentlySelectedOption % 10 + 1) * 5 + 3, (currentlySelectedOption / 10 + 10));
			Console.Write(" ");
		}
		
		// Method that allows te player to move and select the option values
		private int ControlOptionChoiceSubmenu(int maxAmountOfOptions)
		{
			ConsoleKey optionInput;
			int currentOptionChoice = 0; // Starts at the top left value
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
					case ConsoleKey.Enter: // Enter pressed
						{
							break; // Don't beep
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
			
			Console.SetCursorPosition(0, 9); // Erases all options when returning to the main menu
			Console.Write(new String(' ', 660));
			
			return (currentOptionChoice + 1) * 5;
		}
		#endregion
		
		#region Changing the Settings
		// Calls the option choice submenu to change the horizontal size of the mine field
		private void ChangeHorizontalSize()
		{
			DrawOptionChoiceSubmenu(8); // Passes the amount of options for horizontal size
			xSize = ControlOptionChoiceSubmenu(8);
			
			Console.SetCursorPosition(29, 3); // Changes the value in the main menu
			Console.Write(xSize + " ");
			CheckMineCount(); // Checks if the mines need to be changed
		}
		
		// Calls the option choice submenu to change the vertical size of the mine field
		private void ChangeVerticalSize()
		{
			DrawOptionChoiceSubmenu(5); // Passes the amount of options for horizontal size
			ySize = ControlOptionChoiceSubmenu(5);
			
			Console.SetCursorPosition(27, 4);
			Console.Write(ySize + " ");
			CheckMineCount();
		}
		
		// Calls the option choice submenu to change the amount of mines in the mine field
		private void ChangeMineAmount()
		{
			DrawOptionChoiceSubmenu(ySize * xSize / 10); // The amount of options depends on the size of the mine field (mines can only take up to 50% of the cells in the field)
			mineCount = ControlOptionChoiceSubmenu(ySize * xSize / 10);
			
			Console.SetCursorPosition(29, 5);
			Console.Write(mineCount + " ");
		}
		
		// Checks the mine count after the size of the mine field has been canged
		private void CheckMineCount()
		{
			if (mineCount > xSize * ySize / 2) // If mine amount exceeds 50% of the cells in the new field, change it so it's <= 50%
			{
				mineCount = xSize * ySize / 2;
				mineCount = mineCount - mineCount % 5;
			}
			Console.SetCursorPosition(29, 5);
			Console.Write(mineCount + "   ");
		}
		#endregion
		
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
							if (currentOption > 0) // If not at the top, then move one option up
							{
								currentOption = MoveSelectionUp(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow: // Down arrow pressed
						{
							if (currentOption < 3) // If not at the bottom, then move one option down
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
