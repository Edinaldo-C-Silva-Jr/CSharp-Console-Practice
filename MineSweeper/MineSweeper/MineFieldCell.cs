/*
 * Date: 04/06/2023
 * Time: 23:34
*/
using System;

namespace MineSweeper
{
	/// <summary>
	/// Description of MineFieldCell.
	/// </summary>
	public class MineFieldCell
	{
		private int xPosition, yPosition, neighborMinesAmount;
		private bool cellIsMine;
		
		public MineFieldCell(int x, int y, bool mine)
		{
			this.xPosition = x;
			this.yPosition = y;
			this.cellIsMine = mine;
		}
		
		public int GetX()
		{
			return this.xPosition;
		}
		
		public int GetY()
		{
			return this.yPosition;
		}
		
		public char GetNumber()
		{
			if (cellIsMine)
			{
				return 'M';
			}
			else
			{
				return neighborMinesAmount.ToString()[0];
			}
		}
		
		public bool IsMine()
		{
			return this.cellIsMine;
		}
		
		public void CheckNeighboringCell(MineFieldCell neighbor)
		{
			if (neighbor.IsMine())
			{
				neighborMinesAmount++;
			}
		}
	}
}
