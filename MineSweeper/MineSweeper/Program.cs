/*
 * Date: 04/06/2023
 * Time: 23:32
 */
using System;

namespace MineSweeper
{
	class Program
	{
		public static void Main(string[] args)
		{
			Random minePicker = new Random();
			MineFieldCell[,] mineField = new MineFieldCell[10,10];
			
			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
				{
					mineField[x,y] = new MineFieldCell(x, y, Convert.ToBoolean(minePicker.Next(2)));
				}
			}
			
			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
				{
					if (x != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y]);
					}
					
					if (x != 9)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y]);
					}
					
					if (y != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x, y - 1]);
					}
					
					if (y != 9)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x, y + 1]);
					}
					
					if (x != 0 && y != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y - 1]);
					}
					
					if (x != 0 && y != 9)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x - 1, y + 1]);
					}
					
					if (x != 9 && y != 0)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y - 1]);
					}
					
					if (x != 9 && y != 9)
					{
						mineField[x,y].CheckNeighboringCell(mineField[x + 1, y + 1]);
					}
				}
			}
			
			for (int x = 0; x < 10; x++)
			{
				Console.WriteLine(" ");
				
				for (int y = 0; y < 10; y++)
				{
					Console.Write(" " + mineField[x,y].GetNumber());
				}
			}
			
			Console.ReadKey();
		}
	}
}