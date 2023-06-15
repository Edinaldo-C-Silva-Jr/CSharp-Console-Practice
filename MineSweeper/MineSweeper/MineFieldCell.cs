/*
 * Date: 04/06/2023
 * Time: 23:34
 */
using System;

namespace MineSweeper
{
	// A class that represents a single cell in a MineSweeper game field
	public class MineFieldCell
	{
		private int xPosition, yPosition, amountOfAdjacentMines = 0;
		private bool cellIsMine = false, cellIsFlagged = false, cellIsRevealed = false, initialSafety = false;
		private bool[,] neighborExists;
		
		// When the cell is instanced, it is given its coordinates on the current game's grid
		public MineFieldCell(int x, int y, int xMax, int yMax)
		{
			this.xPosition = x;
			this.yPosition = y;
			this.neighborExists = new bool[3,3] { {false, false, false} , {false, true, false} , {false, false, false} };
			CheckNeighborsExistence(xMax, yMax);
		}
		
		// Turns this cell into a mine
		// A mine cell ends the game if it is revealed
		public void TurnCellIntoMine()
		{
			this.cellIsMine = true;
		}
		
		// Returns whether this cell is a mine or not
		public bool IsMine()
		{
			return this.cellIsMine;
		}
		
		// Flags or unflags this cell, depending on what's the current flag status
		// A flagged cell cannot be revealed
		public void FlagCell()
		{
			cellIsFlagged = !cellIsFlagged;
		}
		
		// Returns whether this cell is flagged or not
		public bool IsFlagged()
		{
			return this.cellIsFlagged;
		}
		
		// Turns this cell into a safe cell
		// A safe cell cannot become a mine
		public void MakeSafeCell()
		{
			this.initialSafety = true;
		}
		
		// Returns whether this cell is safe or not
		public bool IsSafe()
		{
			return this.initialSafety;
		}
		
		// Returns the cell content and marks the cell as revealed
		public char RevealCellContent()
		{
			cellIsRevealed = true;
			
			if (cellIsMine)
			{
				return 'M';
			}
			
			if (amountOfAdjacentMines == 0)
			{
				return ' ';
			}
			
			return amountOfAdjacentMines.ToString()[0];
		}
		
		// Returns whether the cell has been revealed or not
		public bool IsRevealed()
		{
			return this.cellIsRevealed;
		}
		
		public void CheckNeighborsExistence(int xMax, int yMax)
		{
			if ((this.xPosition!= 0) && (this.yPosition!= 0))
			{
				this.neighborExists[0, 0] = true;
			}
			
			if (this.xPosition!= 0)
			{
				this.neighborExists[0, 1] = true;
			}
			
			if ((this.xPosition!= 0) && (this.yPosition!= yMax - 1))
			{
				this.neighborExists[0, 2] = true;
			}
			
			if (this.yPosition!= 0)
			{
				this.neighborExists[1, 0] = true;
			}
			
			if (this.yPosition!= yMax - 1)
			{
				this.neighborExists[1, 2] = true;
			}
			
			if ((this.xPosition!= xMax - 1) && (this.yPosition!= 0))
			{
				this.neighborExists[2, 0] = true;
			}
			
			if (this.xPosition!= xMax - 1)
			{
				this.neighborExists[2, 1] = true;
			}
			
			if ((this.xPosition!= xMax - 1) && (this.yPosition!= yMax - 1))
			{
				this.neighborExists[2, 2] = true;
			}
		}
		
		public bool DoesNeighborExist(int x, int y)
		{
			return this.neighborExists[x,y];
		}
		
		// Receives an adjacent cell and checks if it is a mine, to increase the adjacent mines counter
		public void CheckAdjacentCellContent(MineFieldCell neighbor)
		{
			if (neighbor.IsMine())
			{
				amountOfAdjacentMines++;
			}
		}
	}
}
