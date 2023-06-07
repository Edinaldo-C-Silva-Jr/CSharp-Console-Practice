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
		
		public MineSweeper(int x, int y)
		{
			this.xSize = x;
			this.ySize = y;
			minePicker = new Random();
		}
		
		private void InstanceMineFields()
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
		
		public void StartGame()
		{
			InstanceMineFields();
			CheckCellNeighbors();
			
			Console.WriteLine("MineSweeper");
			
			for (int y = 0; y < ySize; y++)
			{
				Console.WriteLine("\n" + new String('-', xSize * 4 + 1));
				
				for (int x = 0; x < xSize; x++)
				{
					Console.Write("| ");
					
					if (mineField[x,y].GetCellContent() == 'M')
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}
					
					Console.Write(mineField[x,y].GetCellContent() + " ");
					Console.ForegroundColor = ConsoleColor.White;
				}
				
				Console.Write("| ");
			}
			Console.Write("\n" + new String('-', xSize * 4 + 1));
			
			Console.ReadKey();
		}
	}
}
