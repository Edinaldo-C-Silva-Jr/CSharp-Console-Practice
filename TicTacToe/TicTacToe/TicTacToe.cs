/*
 * Date: 28/03/2023
 * Time: 22:18
 */
using System;

namespace TicTacToe
{
	/// <summary>
	/// Description of TicTacToe.
	/// </summary>
	public class TicTacToe
	{
		private char[] gameFields = new char[9];
		private bool againstComputer, isPlayerOneTurn, winnerFound;
		private int positionPlayed, currentTurn, victoryCombination;
		
		public TicTacToe()
		{
		}
		
		public void ResetGame()
		{
			for (int i = 0; i < 9; i++) {
				this.gameFields[i] = ' ';
			}
			
			this.currentTurn = 0;
			this.victoryCombination = 0;
			this.winnerFound = false;
			this.isPlayerOneTurn = false;
		}
		
		public void DrawPlayField()
		{
			Console.Clear();
			Console.SetCursorPosition(12, 0);
			Console.Write("----- Jogo da Velha -----");
			Console.SetCursorPosition(0, 2);
			Console.WriteLine("     ---------------------------------------");
			Console.WriteLine("     |[1]    " + this.gameFields[0] + "    |[2]    " + this.gameFields[1] + "    |[3]    " + this.gameFields[2] + "   |");
			Console.WriteLine("     |[4]    " + this.gameFields[3] + "    |[5]    " + this.gameFields[4] + "    |[6]    " + this.gameFields[5] + "   |");
			Console.WriteLine("     |[7]    " + this.gameFields[6] + "    |[8]    " + this.gameFields[7] + "    |[9]    " + this.gameFields[8] + "   |");
			Console.WriteLine("     ---------------------------------------\n");
		}
		
		public void SetOpponentMode()
		{
			int players = int.Parse(Console.ReadLine());
			this.againstComputer = (players == 1);
		}
		
		
		
		
		
		
		
		
		
		public void PlayGame()
		{
			while(!(winnerFound))
			{
				isPlayerOneTurn = !isPlayerOneTurn;
				
				if (isPlayerOneTurn)
				{
					Console.WriteLine("Jogador 1, escolha a posição");
					positionPlayed = int.Parse(Console.ReadLine()); // Will be changed to validation class
					
					gameFields[positionPlayed - 1] = 'X';
				}
				else
				{
					if (againstComputer)
					{
						
					}
					else
					{
						Console.WriteLine("Jogador 2, escolha a posição");
						positionPlayed = int.Parse(Console.ReadLine()); // Will be changed to validation class
						
						gameFields[positionPlayed - 1] = 'O';
					}
				}
				
				
				DrawPlayField();
				currentTurn++;
			}
		}
	}
}
