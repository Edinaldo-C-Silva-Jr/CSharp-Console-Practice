/*
 * Date: 28/03/2023
 * Time: 22:18
 */
using System;
using System.Threading;
using InputValidation;

namespace TicTacToe
{
	/// <summary>
	/// Description of TicTacToe.
	/// </summary>
	public class TicTacToe
	{
		private char[] gameFields = new char[9];
		private string[] drawnFields = new string[9];
		private bool againstComputer, isPlayerOneTurn, winnerFound;
		private int positionPlayed, currentTurn;
		
		ValidateInput validation = new ValidateInput();
		
		private void ResetGame()
		{
			for (int i = 0; i < 9; i++) {
				this.gameFields[i] = ' ';
				this.drawnFields[i] = "         ";
			}
			
			this.currentTurn = 0;
			this.winnerFound = false;
			this.isPlayerOneTurn = false;
		}
		
		private void DrawPlayField()
		{
			Console.Clear();
			Console.SetCursorPosition(12, 0);
			Console.Write("----- Jogo da Velha -----");
			
			RedrawPlayField();
		}
		
		private void RedrawPlayField()
		{
			Console.SetCursorPosition(0, 2);
			Console.WriteLine("     ----------------------------------------");
			Console.WriteLine("     |[1]" + this.drawnFields[0] + "|[2]" + this.drawnFields[1] + "|[3]" + this.drawnFields[2] + "|");
			Console.WriteLine("     |[4]" + this.drawnFields[3] + "|[5]" + this.drawnFields[4] + "|[6]" + this.drawnFields[5] + "|");
			Console.WriteLine("     |[7]" + this.drawnFields[6] + "|[8]" + this.drawnFields[7] + "|[9]" + this.drawnFields[8] + "|");
			Console.WriteLine("     ----------------------------------------\n");
		}
		
		public void SetOpponentMode()
		{
			int players = (int)validation.ValidateNumericValue(1, 2);
			this.againstComputer = (players == 1);
		}
		
		private void PlayTurnHuman(string player, char shape)
		{
			Console.SetCursorPosition(0, 9);
			Console.Write(player + ", escolha a posição para jogar: ");
			
			do
			{
				Console.SetCursorPosition(41, 9);
				Console.Write(" ");
				Console.SetCursorPosition(41, 9);
				positionPlayed = (int)validation.ValidateNumericValue(1, 9) - 1;
			}
			while (gameFields[positionPlayed] != ' ');
			
			gameFields[positionPlayed] = shape;
			drawnFields[positionPlayed] = "    " + gameFields[positionPlayed] + "    ";
		}
		
		// Try to make multiple difficulties
		private void PlayTurnComputer()
		{
			Console.SetCursorPosition(0, 9);
			Console.Write("Jogada do computador." + new string(' ', 30));
			Thread.Sleep(500);
			
			// Easy
			positionPlayed = -1;
			do
			{
				positionPlayed++;
			}
			while(gameFields[positionPlayed] != ' ');
			
			gameFields[positionPlayed] = 'O';
			drawnFields[positionPlayed] = "    " + gameFields[positionPlayed] + "    ";
		}
		
		private void CheckForWinner()
		{
			if (gameFields[0] != ' ')
			{
				if ((gameFields[0] == gameFields[1]) && (gameFields[1] == gameFields[2]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[1] = drawnFields[2] = "<<<<" + gameFields[0] + ">>>>";
				}
				
				if ((gameFields[0] == gameFields[3]) && (gameFields[3] == gameFields[6]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[3] = drawnFields[6] = "<<<<" + gameFields[0] + ">>>>";
				}
				
				if ((gameFields[0] == gameFields[4]) && (gameFields[4] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[4] = drawnFields[8] = "<<<<" + gameFields[0] + ">>>>";
				}
			}
			
			if (gameFields[4] != ' ')
			{
				if ((gameFields[3] == gameFields[4]) && (gameFields[4] == gameFields[5]))
				{
					winnerFound = true;
					drawnFields[3] = drawnFields[4] = drawnFields[5] = "<<<<" + gameFields[4] + ">>>>";
				}
				
				if ((gameFields[1] == gameFields[4]) && (gameFields[4] == gameFields[7]))
				{
					winnerFound = true;
					drawnFields[1] = drawnFields[4] = drawnFields[7] = "<<<<" + gameFields[4] + ">>>>";
				}
				
				if ((gameFields[2] == gameFields[4]) && (gameFields[4] == gameFields[6]))
				{
					winnerFound = true;
					drawnFields[2] = drawnFields[4] = drawnFields[6] = "<<<<" + gameFields[4] + ">>>>";
				}
			}
			
			if (gameFields[8] != ' ')
			{
				if ((gameFields[6] == gameFields[7]) && (gameFields[7] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[6] = drawnFields[7] = drawnFields[8] = "<<<<" + gameFields[8] + ">>>>";
				}
				
				if ((gameFields[2] == gameFields[5]) && (gameFields[5] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[2] = drawnFields[5] = drawnFields[8] = "<<<<" + gameFields[8] + ">>>>";
				}
			}
		}
		
		public void PlayGame()
		{
			ResetGame();
			DrawPlayField();
			
			while(!(winnerFound))
			{
				currentTurn++;
				
				if (currentTurn > 9)
				{
					Console.SetCursorPosition(21, 14);
					Console.Write("Empate!");
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
						PlayTurnComputer();
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
				
				RedrawPlayField();
			}
			
			if (winnerFound)
			{
				Console.SetCursorPosition(16, 14);
				if (isPlayerOneTurn)
				{
					Console.Write("Jogador 1 venceu!");
				}
				else
				{
					if (againstComputer)
					{
						Console.Write("Computador venceu!");
					}
					else
					{
						Console.Write("Jogador 2 venceu!");
					}
				}
			}
		}
	}
}
