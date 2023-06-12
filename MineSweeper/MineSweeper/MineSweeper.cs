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
					mineField[x,y] = new MineFieldCell(x, y);
				}
			}
		}
		
		// Draws the mine field on the screen
		// Shows every cell as a '.' to hide their content
		private void DrawMineField()
		{
			Console.SetCursorPosition((4*xSize - 20) / 2, 0);
			Console.WriteLine("----- MINESWEEPER -----");
			
			Console.SetCursorPosition(0, 2);
			for (int y = 0; y < ySize; y++)
			{
				Console.Write(" " + new String('-', xSize * 4 + 1) + "\n");
				for (int x = 0; x < xSize; x++)
				{
					Console.Write(" | " + ".");
				}
				Console.Write(" | \n");
			}
			Console.Write(" " + new String('-', xSize * 4 + 1));
		}
		#endregion
		
		#region Playing the First Turn
		// Based on the currently played cell, turns all its adjacent cells into safe cells
		// TODO: Maybe make it more efficient
		private void PickSafeCells()
		{
			mineField[playedX, playedY].MakeSafeCell();
			
			if (playedX != 0)
			{
				mineField[playedX - 1, playedY].MakeSafeCell();
			}
			
			if (playedX != xSize - 1)
			{
				mineField[playedX + 1, playedY].MakeSafeCell();
			}
			
			if (playedY != 0)
			{
				mineField[playedX, playedY - 1].MakeSafeCell();
			}
			
			if (playedY != ySize - 1)
			{
				mineField[playedX, playedY + 1].MakeSafeCell();
			}
			
			if ((playedX != 0) && (playedY != 0))
			{
				mineField[playedX - 1, playedY - 1].MakeSafeCell();
			}
			
			if ((playedX != 0) && (playedY != ySize - 1))
			{
				mineField[playedX - 1, playedY + 1].MakeSafeCell();
			}
			
			if ((playedX != xSize - 1) && (playedY != 0))
			{
				mineField[playedX + 1, playedY - 1].MakeSafeCell();
			}
			
			if ((playedX != xSize - 1) && (playedY != ySize - 1))
			{
				mineField[playedX + 1, playedY + 1].MakeSafeCell();
			}
		}
		
		// Randomly picks the cells that will be mines, based on the amount chosen when starting the game
		private void PickMines()
		{
			HashSet<int> mineCellsPicker = new HashSet<int>();
			int cellCoordinates;
			
			while(mineCellsPicker.Count < totalMines)
			{
				cellCoordinates = randomCoordinatePicker.Next(totalCells); // Picks a random cell
				
				if (!mineField[cellCoordinates % xSize, cellCoordinates / xSize].IsSafe()) // If cell is not a safe cell
				{
					mineCellsPicker.Add(cellCoordinates); // Add it to the mines list
				}
			}
			
			List<int> mineCells = mineCellsPicker.ToList();
			
			for (int i = 0; i < mineCells.Count; i++) 
			{
				mineField[mineCells[i] % xSize, mineCells[i] / xSize].TurnCellIntoMine(); // Turns the cells in the list into mines
			}
		}
		
		// Checks for mines in the neighboring cells of each cell to define the number they will show
		// TODO: Maybe make it more efficient
		private void CheckCellNeighbors()
		{
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					if (x != 0)
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x - 1, y]);
					}
					
					if (x != xSize - 1)
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x + 1, y]);
					}
					
					if (y != 0)
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x, y - 1]);
					}
					
					if (y != ySize - 1)
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x, y + 1]);
					}
					
					if ((x != 0) && (y != 0))
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x - 1, y - 1]);
					}
					
					if ((x != 0) && (y != ySize - 1))
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x - 1, y + 1]);
					}
					
					if ((x != xSize - 1) && (y != 0))
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x + 1, y - 1]);
					}
					
					if ((x != xSize - 1) && (y != ySize - 1))
					{
						mineField[x,y].CheckAdjacentCellContent(mineField[x + 1, y + 1]);
					}
				}
			}
		}
		#endregion
		
		// TODO Clean up the code, possibly change method names and comment some more
		#region Playing Turns
		// Changes the "selected cursor" (the "> <" that points at a cell) to the newly selected cell after moving
		private void SelectNextCell()
		{
			Console.SetCursorPosition(2 + 4*playedX, 3 + 2*playedY); // Formula to get the correct position to show the cursor
			Console.Write(">");
			Console.SetCursorPosition(4 + 4*playedX, 3 + 2*playedY);
			Console.Write("<");
		}
		
		// Removes the "selected cursor" from the previously selected cell after moving
		private void DeselectPreviousCell()
		{
			Console.SetCursorPosition(2 + 4*playedX, 3 + 2*playedY); // Formula to get the correct position to remove the cursor
			Console.Write(" ");
			Console.SetCursorPosition(4 + 4*playedX, 3 + 2*playedY);
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
			
			Console.SetCursorPosition(3 + 4*playedX, 3 + 2*playedY); // Gets in position to change the cell content
			if (mineField[playedX, playedY].IsFlagged()) // If cell is flagged, write a green F
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("F");
			}
			else // If cell is not flagged, return it to a hidden cell
			{
				Console.Write(".");
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
		
		// Method that checks whether the cell played is a mine or a number
		// If the cell is a 0, it will also reveal all cells around it
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
			
			if (thisIsTheFirstTurn)
			{
				PickSafeCells();
				PickMines();
				CheckCellNeighbors();
				thisIsTheFirstTurn = false;
			}
			
			Console.SetCursorPosition(3 + 4*currentX, 3 + 2*currentY); // Formula that gets the cursor in position to change the cell
			Console.Write(mineField[currentX, currentY].RevealCellContent()); // Show the content of the cell
			
			revealedCells++;
			
			if (mineField[currentX, currentY].RevealCellContent() == ' ') // If the cell is a 0, reveal surrouding cells
			{
				RevealNeighborCells(currentX, currentY);
			}
		}
		
		// Reveals the neighboring cells of the current cell if its value is a 0
		// TODO: Maybe make it more efficient
		private void RevealNeighborCells(int currentX, int currentY)
		{
			if (currentX != 0)
			{
				CheckCurrentCell(currentX - 1, currentY);
			}
			
			if (currentX != xSize - 1)
			{
				CheckCurrentCell(currentX + 1, currentY);
			}
			
			if (currentY != 0)
			{
				CheckCurrentCell(currentX, currentY - 1);
			}
			
			if (currentY != ySize - 1)
			{
				CheckCurrentCell(currentX, currentY + 1);
			}
			
			if ((currentX != 0) && (currentY != 0))
			{
				CheckCurrentCell(currentX - 1, currentY - 1);
			}
			
			if ((currentX != 0) && (currentY != ySize - 1))
			{
				CheckCurrentCell(currentX - 1, currentY + 1);
			}
			
			if ((currentX != xSize - 1) && (currentY != 0))
			{
				CheckCurrentCell(currentX + 1, currentY - 1);
			}
			
			if ((currentX != xSize - 1) && (currentY != ySize - 1))
			{
				CheckCurrentCell(currentX + 1, currentY + 1);
			}
		}
		
		// Plays a turn
		private void PlayTurn()
		{
			ConsoleKeyInfo control;
			
			do
			{
				control = Console.ReadKey(true);
				DeselectPreviousCell();
				switch(control.Key)
				{
					case ConsoleKey.UpArrow:
						{
							if (playedY > 0)
							{
								playedY--;
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (playedY < ySize - 1)
							{
								playedY++;
							}
							break;
						}
					case ConsoleKey.LeftArrow:
						{
							if (playedX > 0)
							{
								playedX--;
							}
							break;
						}
					case ConsoleKey.RightArrow:
						{
							if (playedX < xSize - 1)
							{
								playedX++;
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							CheckCurrentCell(playedX, playedY);
							winGame = totalCells - revealedCells == totalMines;
							break;
						}
					case ConsoleKey.Backspace:
						{
							FlagCurrentCell();
							break;
						}
				}
				SelectNextCell();
			}
			while(control.Key != ConsoleKey.Enter);
			
			Console.SetCursorPosition(40, 0);
			Console.Write("Total: " + totalCells + " - Revealed: " + revealedCells + " // Mines: " + totalMines);
		}
		
		// Reveals all mines once the game ends
		private void RevealMines()
		{
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					if (mineField[x,y].IsMine())
					{
						Console.SetCursorPosition(3 + 4*x, 3 + 2*y);
						Console.Write(mineField[x,y].RevealCellContent());
					}
				}
			}
		}
		#endregion
		
		// TODO Clean up the code and comment some more
		#region Actually Playing the Game
		public void StartGame()
		{
			playedX = playedY = revealedCells = 0;
			winGame = loseGame = false;
			thisIsTheFirstTurn = true;
			
			InstanceMineFieldCells();
			DrawMineField();
			SelectNextCell();
			
			Console.ForegroundColor = ConsoleColor.White;
			
			do
			{
				PlayTurn();
			}
			while(!winGame && !loseGame);
			
			Console.SetCursorPosition(0,0);
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
