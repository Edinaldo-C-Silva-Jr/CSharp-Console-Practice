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
		
		private bool win, lose;
		private int playedX, playedY, markedMines, revealedCells;
		
		public MineSweeper(int x, int y)
		{
			this.xSize = x;
			this.ySize = y;
			minePicker = new Random();
		}
		
		private void InstanceMineFieldCells()
		{
			mineField = new MineFieldCell[xSize, ySize];
			
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					mineField[x,y] = new MineFieldCell(x, y, Convert.ToBoolean(minePicker.Next(2)));
				}
			}
		}
		
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
		
		private void DrawMineField()
		{
			Console.WriteLine("MineSweeper");
			
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
		
		// Method that checks whether the field played is a mine or a number
		private void CheckCurrentCell()
		{
			Console.SetCursorPosition(3 + 4*playedX, 3 + 2*playedY); // Gets the cursor in position
			
			if (!mineField[playedX, playedY].IsFlagged()) // Only check if cell is not flagged
			{
				if (mineField[playedX, playedY].GetCellContent() == 'M') // If cell is a mine, end the game in a loss and make the text red
				{
					//lose = true;
					Console.ForegroundColor = ConsoleColor.Red;
				}
				Console.Write(mineField[playedX, playedY].GetCellContent()); // Show the content of the cell (either number or a mine)
				Console.ForegroundColor = ConsoleColor.White;
			}
		}
		
		private void SelectCurrentCell()
		{
			Console.SetCursorPosition(2 + 4*playedX, 3 + 2*playedY);
			Console.Write(">");
			Console.SetCursorPosition(4 + 4*playedX, 3 + 2*playedY);
			Console.Write("<");
		}
		
		private void DeselectCurrentCell()
		{
			Console.SetCursorPosition(2 + 4*playedX, 3 + 2*playedY);
			Console.Write(" ");
			Console.SetCursorPosition(4 + 4*playedX, 3 + 2*playedY);
			Console.Write(" ");
		}
		
		private void FlagCurrentCell()
		{
			if (!mineField[playedX, playedY].IsRevealed())
			{
				mineField[playedX, playedY].FlagCell();
				
				Console.SetCursorPosition(3 + 4*playedX, 3 + 2*playedY);
				if (mineField[playedX, playedY].IsFlagged())
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("F");
				}
				else
				{
					Console.Write(".");
				}
				Console.ForegroundColor = ConsoleColor.White;
			}
		}
		
		private void PlayTurn()
		{
			ConsoleKeyInfo control;
			
			do
			{
				control = Console.ReadKey(true);
				DeselectCurrentCell();
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
							CheckCurrentCell();
							break;
						}
					case ConsoleKey.Backspace:
						{
							FlagCurrentCell();
							break;
						}
				}
				SelectCurrentCell();
			}
			while(control.Key != ConsoleKey.Enter);
		}
		
		public void StartGame()
		{
			playedX = playedY = markedMines = revealedCells = 0;
			win = lose = false;
			
			InstanceMineFieldCells();
			CheckCellNeighbors();
			DrawMineField();
			SelectCurrentCell();
			
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
			}
			
			if (lose)
			{
				Console.Write("Loser!");
			}
			
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.ReadKey();
		}
	}
}
