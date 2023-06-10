/*
 * Date: 07/06/2023
 * Time: 15:24
 */
using System;

namespace MineSweeper
{
	/// <summary>
	/// Description of MineSweeper.
	/// </summary>
	public class MineSweeper
	{
		private Random minePicker;
		private MineFieldCell[,] mineField;
		
		private int xSize, ySize;
		
		private bool win, lose, firstTurn;
		private int playedX, playedY, totalCells, revealedCells, totalMines;
		
		public MineSweeper(int x, int y, int mineCount)
		{
			this.xSize = x;
			this.ySize = y;
			minePicker = new Random();
			totalCells = xSize * ySize;
			totalMines = mineCount;
		}
		
		private void InstanceMineFieldCells()
		{
			mineField = new MineFieldCell[xSize, ySize];
			
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					mineField[x,y] = new MineFieldCell(x, y, minePicker.Next(10) == 0);
				}
			}
		}
		
		private void PickMines()
		{
			// TODO
		}
		
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
		
		// Draws the mine field on the screen
		// Shows every cell as a '.' to hide the cell's content
		private void DrawMineField()
		{
			Console.WriteLine("----- MINESWEEPER -----");
			
			for (int y = 0; y < ySize; y++)
			{
				Console.WriteLine("\n " + new String('-', xSize * 4 + 1));
				for (int x = 0; x < xSize; x++)
				{
					Console.Write(" | " + ".");
				}
				Console.Write(" | ");
			}
			Console.Write("\n " + new String('-', xSize * 4 + 1));
		}
		
		// Checks for mines in the neighboring cells of each cell to define the number they will show
		private void CheckCellNeighbors()
		{
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					if (x != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y]);
					}
					
					if (x != xSize - 1)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y]);
					}
					
					if (y != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x, y - 1]);
					}
					
					if (y != ySize - 1)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x, y + 1]);
					}
					
					if ((x != 0) && (y != 0))
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y - 1]);
					}
					
					if ((x != 0) && (y != ySize - 1))
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y + 1]);
					}
					
					if ((x != xSize - 1) && (y != 0))
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y - 1]);
					}
					
					if ((x != xSize - 1) && (y != ySize - 1))
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y + 1]);
					}
				}
			}
		}
		
		// Reveals the neighboring cells of the current cell if its value is a 0
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
		
		// Method that checks whether the cell played is a mine or a number
		// If the cell is a 0, it will also reveal all cells around it
		private void CheckCurrentCell(int currentX, int currentY)
		{
			if (mineField[currentX, currentY].IsRevealed() || mineField[currentX, currentY].IsFlagged()) // Do nothing if cell is flagged or revealed
			{
				return;
			}
			
			if (mineField[currentX, currentY].GetCellContent() == 'M') // If cell is a mine, end the game in a loss
			{
				lose = true;
				return;
			}
			
			if (firstTurn)
			{
				PickSafeCells();
				firstTurn = false;
			}
			
			Console.SetCursorPosition(3 + 4*currentX, 3 + 2*currentY); // Formula that gets the cursor in position to change the cell
			Console.Write(mineField[currentX, currentY].GetCellContent()); // Show the content of the cell
			
			revealedCells++;
			
			if (mineField[currentX, currentY].GetCellContent() == ' ') // If the cell is a 0, reveal surrouding cells
			{
				RevealNeighborCells(currentX, currentY);
			}
		}
		
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
		
		private void RevealMines()
		{
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					if (mineField[x,y].IsMine())
					{
						Console.SetCursorPosition(3 + 4*x, 3 + 2*y);
						Console.Write(mineField[x,y].GetCellContent());
					}
				}
			}
		}
		
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
							win = totalCells - revealedCells == totalMines;
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
		
		public void StartGame()
		{
			playedX = playedY = revealedCells = 0;
			win = lose = false;
			firstTurn = true;
			
			InstanceMineFieldCells();
			CheckCellNeighbors();
			DrawMineField();
			SelectNextCell();
			
			Console.ForegroundColor = ConsoleColor.White;
			
			do
			{
				PlayTurn();
			}
			while(!win && !lose);
			
			Console.SetCursorPosition(0,0);
			if (win)
			{
				Console.Write("Winner!");
				Console.ForegroundColor = ConsoleColor.Cyan;
			}
			
			if (lose)
			{
				Console.Write("Loser!");
				Console.ForegroundColor = ConsoleColor.Red;
			}
			
			RevealMines();
			
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.ReadKey();
		}
	}
}
