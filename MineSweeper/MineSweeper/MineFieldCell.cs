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
		private int xPosition, yPosition, neighborMinesAmount = 0;
		private bool cellIsMine, cellIsFlagged = false, cellIsRevealed = false;
		
		public MineFieldCell(int x, int y, bool mine)
		{
			this.xPosition = x;
			this.yPosition = y;
			this.cellIsMine = mine;
		}
		
		public char GetCellContent()
		{
			cellIsRevealed = true;
			
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
		
		public void FlagCell()
		{
			cellIsFlagged = !cellIsFlagged;
		}
		
		public bool IsFlagged()
		{
			return this.cellIsFlagged;
		}
		
		public bool IsRevealed()
		{
			return this.cellIsRevealed;
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
