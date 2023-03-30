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
		
		private void ResetGame()
		{
			for (int i = 0; i < 9; i++) {
				this.gameFields[i] = ' ';
			}
			
			this.currentTurn = 0;
			this.victoryCombination = 0;
			this.winnerFound = false;
			this.isPlayerOneTurn = false;
		}
		
		private void DrawPlayField()
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
		
		private void PlayTurnHuman(string player, char shape)
		{
			Console.WriteLine(player + ", escolha a posição para jogar: ");
			
			do
			{
				positionPlayed = int.Parse(Console.ReadLine()); // Will be changed to validation class to prevent parsing errors
			}
			while (gameFields[positionPlayed - 1] != ' ');
			
			gameFields[positionPlayed - 1] = shape;
		}
		
		private void PlayTurnComputer()
		{
			// To do: Computer logic
			// Try to make multiple difficulties
		}
		
		private void CheckForWinner()
		{
			if (gameFields[0] != ' ')
			{
				if ((gameFields[0] == gameFields[1]) && (gameFields[1] == gameFields[2]))
				{
					winnerFound = true;
					victoryCombination = 1;
				}
				
				if ((gameFields[0] == gameFields[3]) && (gameFields[3] == gameFields[6]))
				{
					winnerFound = true;
					victoryCombination = 4;
				}
				
				if ((gameFields[0] == gameFields[4]) && (gameFields[4] == gameFields[8]))
				{
					winnerFound = true;
					victoryCombination = 7;
				}
			}
			
			if (gameFields[4] != ' ')
			{
				if ((gameFields[3] == gameFields[4]) && (gameFields[4] == gameFields[5]))
				{
					winnerFound = true;
					victoryCombination = 2;
				}
				
				if ((gameFields[1] == gameFields[4]) && (gameFields[4] == gameFields[7]))
				{
					winnerFound = true;
					victoryCombination = 5;
				}
				
				if ((gameFields[2] == gameFields[4]) && (gameFields[4] == gameFields[6]))
				{
					winnerFound = true;
					victoryCombination = 8;
				}
			}
			
			if (gameFields[8] != ' ')
			{
				if ((gameFields[6] == gameFields[7]) && (gameFields[7] == gameFields[8]))
				{
					winnerFound = true;
					victoryCombination = 3;
				}
				
				if ((gameFields[2] == gameFields[5]) && (gameFields[5] == gameFields[8]))
				{
					winnerFound = true;
					victoryCombination = 6;
				}
			}
		}
		
		// To do: Method that shows the winning line instead of explicitly saying it in the program
		
		public void PlayGame()
		{
			ResetGame();
			DrawPlayField();
			
			while(!(winnerFound))
			{
				currentTurn++;
				
				if (currentTurn > 9)
				{
					Console.WriteLine("Empate");
					break;
				}
				
				isPlayerOneTurn = !isPlayerOneTurn;
				
				if (isPlayerOneTurn)
				{
					PlayTurnHuman("Jogador 1", 'X');
				}
				else
				{
					if (againstComputer)
					{
						
					}
					else
					{
						PlayTurnHuman("Jogador 2", 'O');
					}
				}
				
				if (currentTurn > 4)
				{
					CheckForWinner();
				}
				
				DrawPlayField();
			}
			
			if (winnerFound)
			{
				if (isPlayerOneTurn)
				{
					Console.WriteLine("Jogador 1 venceu!");
				}
				else
				{
					Console.WriteLine("Jogador 2 venceu!");
				}
				
				Console.WriteLine("Linha da vitória: " + victoryCombination);
			}
		}
	}
}
