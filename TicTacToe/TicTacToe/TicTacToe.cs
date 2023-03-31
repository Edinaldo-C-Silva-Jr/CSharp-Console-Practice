/*
 * Date: 28/03/2023
 * Time: 22:18
 */
using System;
using System.Threading;
using InputValidation;

namespace TicTacToe
{
	// A class that implements a game of Tic Tac Toe
	// It has all the methods for starting the game, playing it, ending the game (by either finding a winner or defining a draw) and showing the results
	public class TicTacToe
	{
		private char[] gameFields = new char[9]; // Variable that keeps track of what was played on each field (X or O)
		private string[] drawnFields = new string[9]; // Variable that is used to draw the game fields on the screen
		private bool againstComputer, isPlayerOneTurn, winnerFound;
		private int positionPlayed, currentTurn;
		
		ValidateInput validation = new ValidateInput();
		
		// Resets all variables to the starting values. Used at the start of a game to make sure every variable has its default value
		private void ResetGame()
		{
			for (int i = 0; i < 9; i++) // Makes all fields blank spaces, which indicates they haven't been played yet
			{
				this.gameFields[i] = ' ';
				this.drawnFields[i] = "         ";
			}
			
			this.currentTurn = 0;
			this.winnerFound = false;
			this.isPlayerOneTurn = false;
		}
		
		// Draws all the lines required to show the starting game board on the screen. Used only once at the start of a game
		private void DrawGameBoard()
		{
			Console.Clear();
			Console.SetCursorPosition(12, 0);
			Console.Write("----- Jogo da Velha -----");
			Console.SetCursorPosition(35, 19);
			Console.Write("Versão 1.0");
			
			
			RedrawGameBoard();
		}
		
		// Redraws the playing board after every turn is played. This method redraws only the portion of the screen that needs to be changed (that is, the lines that contain the fields, since they need to be changed to X or O)
		private void RedrawGameBoard()
		{
			Console.SetCursorPosition(0, 2);
			Console.WriteLine("     ----------------------------------------");
			Console.WriteLine("     |[1]" + this.drawnFields[0] + "|[2]" + this.drawnFields[1] + "|[3]" + this.drawnFields[2] + "|");
			Console.WriteLine("     |[4]" + this.drawnFields[3] + "|[5]" + this.drawnFields[4] + "|[6]" + this.drawnFields[5] + "|");
			Console.WriteLine("     |[7]" + this.drawnFields[6] + "|[8]" + this.drawnFields[7] + "|[9]" + this.drawnFields[8] + "|");
			Console.WriteLine("     ----------------------------------------\n");
		}
		
		// Sets whether the opponent will be a second human player or the computer
		// It currently utilizes the amount of players to define the opponent
		// If amount of players is 1, the opponent is a computer. If amount of players is 2, the opponent is a human
		public void SetOpponentMode()
		{
			int players = (int)validation.ValidateNumericValue(1, 2); // Ensures the input can only be '1' or '2'
			this.againstComputer = (players == 1);
		}
		
		// Method that handles a single turn being played by a human player
		private void PlayTurnHuman(string player, char shape)
		{
			Console.SetCursorPosition(0, 9);
			Console.Write(player + ", escolha a posição para jogar: ");
			
			do
			{
				Console.SetCursorPosition(41, 9); // Resets the cursor to its original position if the game field chosen is already filled
				Console.Write(" ");
				Console.SetCursorPosition(41, 9);
				positionPlayed = (int)validation.ValidateNumericValue(1, 9) - 1; // Ensures the input can only be from 0 to 9
			}
			while (gameFields[positionPlayed] != ' '); // Only allows a certain field to be played if it's blank (that is, it wasn't already filled with X or O)
			
			gameFields[positionPlayed] = shape; // Fill the field with the character passed to the method (X if player 1, O if player 2)
			drawnFields[positionPlayed] = "    " + gameFields[positionPlayed] + "    ";
		}
		
		// TODO: Try to make multiple difficulties
		// Method that handles a single turn being played by a computer player
		private void PlayTurnComputer()
		{
			Console.SetCursorPosition(0, 9); // Erases the line that asks for player input, and informs it's the computer's turn
			Console.Write("Jogada do computador." + new string(' ', 30));
			Thread.Sleep(500);
			
			// Easy Difficulty
			// The computer goes through all fields in ascending order, and plays the first position it finds available
			// The computer behavior is always the same regardless of player input
			positionPlayed = -1;
			do
			{
				positionPlayed++;
			}
			while(gameFields[positionPlayed] != ' ');
			
			gameFields[positionPlayed] = 'O'; // Computer is always player 2, so it will always play O
			drawnFields[positionPlayed] = "    " + gameFields[positionPlayed] + "    ";
		}
		
		// Checks the game board to find if a winning line was found. Winning lines are straight lines where all 3 fields match
		private void CheckForWinner()
		{
			// Checks if field 0 (Top Left) was played.
			// If it was played, checks all lines that contain it, to see if any of them have matching fields
			if (gameFields[0] != ' ')
			{
				if ((gameFields[0] == gameFields[1]) && (gameFields[1] == gameFields[2]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[1] = drawnFields[2] = "<<<<" + gameFields[0] + ">>>>"; // Changes the drawn fields to show the winning lines differently
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
			
			// Checks if field 4 (Middle) was played.
			// If it was played, checks all lines that contain it (except for the line that has already been checked above), to see if any of them have matching fields
			if (gameFields[4] != ' ')
			{
				if ((gameFields[3] == gameFields[4]) && (gameFields[4] == gameFields[5]))
				{
					winnerFound = true;
					drawnFields[3] = drawnFields[4] = drawnFields[5] = "<<<<" + gameFields[4] + ">>>>"; // Changes the drawn fields to show the winning lines differently
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
			
			// Checks if field 8 (Bottom Right) was played.
			// If it was played, checks all lines that contain it (except for the line that has already been checked above), to see if any of them have matching fields
			if (gameFields[8] != ' ')
			{
				if ((gameFields[6] == gameFields[7]) && (gameFields[7] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[6] = drawnFields[7] = drawnFields[8] = "<<<<" + gameFields[8] + ">>>>"; // Changes the drawn fields to show the winning lines differently
				}
				
				if ((gameFields[2] == gameFields[5]) && (gameFields[5] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[2] = drawnFields[5] = drawnFields[8] = "<<<<" + gameFields[8] + ">>>>";
				}
			}
		}
		
		// Method that actually starts the game
		public void PlayGame()
		{
			ResetGame();
			DrawGameBoard();
			
			while(!(winnerFound)) // Keep playing until a winner is found
			{
				currentTurn++;
				
				if (currentTurn > 9) // Declare a draw and leave if 9 turns have been played (Since that means every field is filled)
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
				
				if (currentTurn > 4) // Only checks for a winner from the 5th turn onwards (There can only be amatch if any player has played at least 3 times)
				{
					CheckForWinner();
				}
				
				RedrawGameBoard();
			}
			
			if (winnerFound) // Shows the winner, depending on whose turn the win was declared
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
			
			Console.ReadKey();
		}
	}
}
