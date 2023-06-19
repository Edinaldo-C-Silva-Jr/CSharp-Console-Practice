/*
 * Date: 07/06/2023
 * Time: 15:24
 */
using System;
using System.Linq;
using System.Collections.Generic;

namespace MineSweeper
{
	// A class that implements a game of MineSweeper
	// It instances a grid of MineFieldCells and handles all the steps of creating, playing and ending the game 
	public class MineSweeper
	{
		private Random randomCoordinatePicker; // Game creation variables
		private MineFieldCell[,] mineField;
		private int xSize, ySize;
		
		private bool winGame, loseGame, thisIsTheFirstTurn; // Gameplay related variables
		private int playedX, playedY, totalCells, revealedCells, totalMines;
		
		public MineSweeper(int x, int y, int mineCount)
		{
			this.xSize = x;
			this.ySize = y;
			randomCoordinatePicker = new Random();
			totalCells = xSize * ySize;
			totalMines = mineCount;
			
			Console.SetWindowSize(5 + xSize * 4, 7 + ySize * 2);
			Console.SetBufferSize(5 + xSize * 4, 7 + ySize * 2);
		}
		
		#region Building the Mine Field
		// Instances every cell in the mine field, by giving them their coordinates
		private void InstanceMineFieldCells()
		{
			mineField = new MineFieldCell[xSize, ySize];
			
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					mineField[x,y] = new MineFieldCell(x, y, xSize, ySize);
				}
			}
		}
		
		// Draws the mine field on the screen
		// Shows every cell as a yellow '.' to hide their content
		private void DrawMineField()
		{
			Console.Clear();
			Console.SetCursorPosition((4*xSize - 20) / 2, 0);
			Console.Write("----- MINESWEEPER -----");
			
			Console.SetCursorPosition(0, 6);
			for (int y = 0; y < ySize; y++)
			{
				Console.Write("  " + new String('-', xSize * 4 + 1) + "\n ");
				for (int x = 0; x < xSize; x++)
				{
					Console.Write(" | ");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(".");
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				Console.Write(" | \n");
			}
			Console.Write("  " + new String('-', xSize * 4 + 1));
		}
		#endregion
		
		#region Playing the First Turn	
		// Based on the currently played cell, turns all its adjacent cells into safe cells
		private void PickSafeCells()
		{
			for (int x = 0; x < 3; x++) // Cycles through the adjacent cells of the currently played cell
			{
				for (int y = 0; y < 3; y++)
				{
					if (mineField[playedX, playedY].DoesThisNeighborExist(x,y)) // If the adjacent cell exists
					{
						mineField[playedX + x - 1, playedY + y - 1].MakeSafeCell(); // Turn it into a safe cell
					}
				}
			}
		}
		
		// Randomly picks the cells that will be mines, based on the amount chosen when starting the game
		private void PickMines()
		{
			HashSet<int> mineCellsPicker = new HashSet<int>();
			int cellCoordinates; // A single value that represents the absolute coordinate of a grid cell (i.e. the next row starts where the previous row left off. If the first row is 0 to 9, second row starts at 10)
			
			while(mineCellsPicker.Count < totalMines)
			{
				cellCoordinates = randomCoordinatePicker.Next(totalCells); // Picks a random cell
				
				if (!mineField[cellCoordinates % xSize, cellCoordinates / xSize].IsSafe()) // If cell is not a safe cell
				{
					mineCellsPicker.Add(cellCoordinates); // Add it to the mines list
				}
			}
			
			List<int> mineCellsList = mineCellsPicker.ToList();
			
			for (int i = 0; i < mineCellsList.Count; i++) 
			{
				mineField[mineCellsList[i] % xSize, mineCellsList[i] / xSize].TurnCellIntoMine(); // Turns the cells in the list into mines
			}
		}
		
		// Receives the coordinates of a cell, then checks all neighbors from that current cell to count how many mines are around it
		private void CheckCellNeighboringMines(int currentX, int currentY)
		{
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					if (mineField[currentX, currentY].DoesThisNeighborExist(x,y))
					{
						mineField[currentX, currentY].CheckAdjacentCellContent(mineField[currentX + x - 1, currentY + y - 1]);
					}
				}
			}
		}
		
		// Runs the above method for every cell in the mine field, thus setting all cells with their correct values
		private void CheckAllCellsNeighboringMines()
		{
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					CheckCellNeighboringMines(x, y);
				}
			}
		}
		#endregion
		
		#region Playing Turns
		// Draws a "selected  cursor" (The "> <"pointing at a specific cell) on the current cell coordinates
		private void SelectCell()
		{
			Console.SetCursorPosition(3 + 4*playedX, 7 + 2*playedY); // Formula to get the correct position to show the cursor
			Console.Write(">");
			Console.SetCursorPosition(5 + 4*playedX, 7 + 2*playedY);
			Console.Write("<");
		}
		
		// Removes the "selected cursor" from the current cell coordinates
		private void DeselectCell()
		{
			Console.SetCursorPosition(3 + 4*playedX, 7 + 2*playedY); // Formula to get the correct position to remove the cursor
			Console.Write(" ");
			Console.SetCursorPosition(5 + 4*playedX, 7 + 2*playedY);
			Console.Write(" ");
		}
		
		// Flags or unflags the current cell. Only unrevealed cells can be flagged
		// Flagging a cell prevents it from being revealed
		private void FlagCurrentCell()
		{
			if (mineField[playedX, playedY].IsRevealed()) // Do nothing if cell is already revealed
			{
				return;
			}
			
			mineField[playedX, playedY].FlagCell();
			
			Console.SetCursorPosition(4 + 4*playedX, 7 + 2*playedY); // Gets in position to change the cell content
			if (mineField[playedX, playedY].IsFlagged()) // If cell is flagged, write a green F
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("F");
			}
			else // If cell is not flagged, return it to a hidden cell
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write(".");
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		
		// Method that checks whether the current cell is a mine or a number
		// If the cell is a 0, it will also reveal all cells around it (Method receives currentX / currentY coordinates to allow the recursion)
		private void CheckCurrentCell(int currentX, int currentY)
		{
			if (mineField[currentX, currentY].IsRevealed() || mineField[currentX, currentY].IsFlagged()) // Do nothing if cell is flagged or revealed
			{
				return;
			}
			
			if (mineField[currentX, currentY].RevealCellContent() == 'M') // If cell is a mine, end the game in a loss
			{
				loseGame = true;
				return;
			}
			
			if (thisIsTheFirstTurn) // If this is the first turn of the game
			{
				PickSafeCells(); // Make the currently played cell and its neighbors safe cells
				PickMines(); // Then picks mines (has to be done after the first play, otherwise it's possible to lose on first turn)
				CheckAllCellsNeighboringMines(); // And finally gets the number on all cells
				thisIsTheFirstTurn = false;
			}
			
			Console.SetCursorPosition(4 + 4*currentX, 7 + 2*currentY); // Formula that gets the cursor in position to change the cell
			Console.Write(mineField[currentX, currentY].RevealCellContent()); // Show the content of the cell
			
			revealedCells++;
			
			if (mineField[currentX, currentY].RevealCellContent() == ' ') // If the cell is a 0, reveal surrouding cells
			{
				RevealAdjacentCells(currentX, currentY);
			}
		}
		
		// Reveals all adjacent cells of the current cell if its value is a 0
		private void RevealAdjacentCells(int currentX, int currentY)
		{
			for (int x = 0; x < 3; x++) // Cycles through all adjacent cells of the current cell
			{
				for (int y = 0; y < 3; y++)
				{
					if (mineField[currentX, currentY].DoesThisNeighborExist(x,y))
					{
						CheckCurrentCell(currentX + x - 1, currentY + y - 1);
					}
				}
			}
		}
		
		// Updates the game counters on screen, using their relevant color
		private void UpdateCounters()
		{
			Console.SetCursorPosition(0, 2);
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write("  Cells: " + totalCells);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("  Mines: " + totalMines);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("\n  Remaining Cells: " + (totalCells - (totalMines + revealedCells)) + "  ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n  Revealed Cells: " + revealedCells);
		}
		
		// Actually plays a turn in the game
		private void PlayTurn()
		{
			ConsoleKeyInfo control;
			
			do
			{
				control = Console.ReadKey(true);
				DeselectCell(); // Deselects the current cell before any player action
				switch(control.Key) // Handles the game's controls
				{
					case ConsoleKey.UpArrow:
						{
							if (playedY > 0) // if not already at the top
							{
								playedY--; // Move one cell up
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (playedY < ySize - 1) // If not already at the bottom
							{
								playedY++; // Move one cell down
							}
							break;
						}
					case ConsoleKey.LeftArrow:
						{
							if (playedX > 0) // If not already at left edge
							{
								playedX--; // Move one cell left
							}
							break;
						}
					case ConsoleKey.RightArrow:
						{
							if (playedX < xSize - 1) // If not already at right edge
							{
								playedX++; // Move one cell right
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							CheckCurrentCell(playedX, playedY);
							winGame = totalCells - revealedCells == totalMines; // Checks if the game is won (all non-mine cells have been revealed)
							break;
						}
					case ConsoleKey.Backspace:
						{
							FlagCurrentCell();
							break;
						}
				}
				SelectCell(); // Selects the current cell after the player's action
			}
			while(control.Key != ConsoleKey.Enter); // Keep going while the player has not revealed a new cell
		}
		
		// Reveals all mines once the game ends
		private void RevealMines()
		{
			for (int x = 0; x < xSize; x++) // Cycles through all cells
			{
				for (int y = 0; y < ySize; y++)
				{
					if (mineField[x,y].IsMine())
					{
						Console.SetCursorPosition(4 + 4*x, 7 + 2*y);
						Console.Write(mineField[x,y].RevealCellContent()); // If cell is a mine, reveal it
					}
				}
			}
		}
		#endregion
		
		#region Actually Plays the Game
		public void StartGame()
		{
			playedX = playedY = revealedCells = 0; // Starts at the top left cell
			winGame = loseGame = false;
			thisIsTheFirstTurn = true;
			
			InstanceMineFieldCells(); // Starts the game and draws the mine field, while selecting the top left cell
			DrawMineField();
			UpdateCounters();
			SelectCell();
			
			Console.ForegroundColor = ConsoleColor.White;
			
			do
			{
				PlayTurn();
				UpdateCounters();
			}
			while(!winGame && !loseGame);
			
			if (winGame)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
			}
			
			if (loseGame)
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			
			RevealMines();
			
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.ReadKey();
		}
		#endregion
	}
}
