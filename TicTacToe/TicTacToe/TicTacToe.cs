/*
 * Date: 28/03/2023
 * Time: 22:18
 */
using System;
using System.Threading;
using InputLimitator;

namespace TicTacToe
{
	// A class that implements a game of Tic Tac Toe
	// It has all the methods for starting the game, playing it, ending the game (by either finding a winner or defining a draw) and showing the results
	// It also has a bunch of variables that control settings: setting opponent, setting controls and setting who goes first
	// There are 2 control modes: Typing and using the arrow keys
	public class TicTacToe
	{
		private char[] gameFields = new char[9]; // Variable that keeps track of what was played on each field (X or O)
		private string[] drawnFields = new string[9]; // Variable that is used to draw the game fields on the screen
		private bool isPlayerOneTurn, winnerFound; 
		private int positionPlayed, currentTurn;
		
		private bool againstComputer = true, playWithArrows = false, playerOneGoesFirst = true; // Settings related variables
		
		LimitInput limitator = new LimitInput();
		
		#region Game Setup and Drawing
		// Resets all match related variables to the starting values. Used at the start of a match to make sure every variable has its default value
		private void ResetGame()
		{
			for (int i = 0; i < 9; i++) // Makes all fields blank spaces, which indicates they haven't been played yet
			{
				gameFields[i] = ' ';
				drawnFields[i] = new String(' ', 11);
			}
			
			currentTurn = 0;
			winnerFound = false;
			
			isPlayerOneTurn = !playerOneGoesFirst; // Whether player 1 goes first depends on the current game setting for the first player. This variable is altered once the match starts, so if player 1 goes first, it is set to false (as it becomes true on the first turn), and vice-versa
		}
		
		// Draws all the lines required to show the starting game board on the screen. Used only once at the start of a game
		private void DrawGameBoard()
		{
			Console.Clear();
			Console.SetCursorPosition(17, 0); // Centers the game title on the screen
			Console.Write("----- Jogo da Velha -----");
			Console.SetCursorPosition(47, 19); // Shows version at the corner of the screen
			Console.Write("Versão 2.0");
			
			RedrawGameBoard();
		}
		
		// Redraws the playing board after every turn is played. This method redraws only the portion of the screen that needs to be changed (that is, the lines that contain the fields, since they need to be changed to X or O)
		private void RedrawGameBoard()
		{
			Console.SetCursorPosition(0, 2);
			Console.WriteLine("       ---------------------------------------------"); // Spaces are used to keep the board centered
			Console.WriteLine("       [1]" + drawnFields[0] + "|[2]" + drawnFields[1] + "|[3]" + drawnFields[2] + "|");
			Console.WriteLine("       [4]" + drawnFields[3] + "|[5]" + drawnFields[4] + "|[6]" + drawnFields[5] + "|");
			Console.WriteLine("       [7]" + drawnFields[6] + "|[8]" + drawnFields[7] + "|[9]" + drawnFields[8] + "|");
			Console.WriteLine("       ---------------------------------------------\n");
		}
		#endregion
		
		#region Game Settings
		// Returns a string containing the details of the current game settings. Used to display the settings in the menu
		public string[] GetCurrentSettings()
		{
			string[] settings = new string[3];
			
			if (againstComputer)
			{
				settings[0] = "Computador";
			}
			else
			{
				settings[0] = "Humano    ";
			}
			
			if (playWithArrows)
			{
				settings[1] = "Setas  ";
			}
			else
			{
				settings[1] = "Digitar";
			}
			
			if (playerOneGoesFirst)
			{
				settings[2] = "Jogador 1";
			}
			else
			{
				settings[2] = "Jogador 2";
			}
			
			return settings;
		}
		
		// Sets whether the opponent will be a second human player or the computer
		public void SetOpponentMode()
		{
			againstComputer = !againstComputer;
		}
		
		// Sets whether the game is playing by typing the numeric value of the field or with the arrow keys
		public void SetControlType()
		{
			playWithArrows = !playWithArrows;
		}
		
		// Sets whether Player 1 or Player 2 goes first
		public void SetFirstPlayer()
		{
			playerOneGoesFirst = !playerOneGoesFirst;
		}
		#endregion
		
		#region Gameplay Methods
		// Method that handles a single turn being played by a human player, while using the typing method
		private void PlayTurnHumanTyping(string player, char shape)
		{
			Console.CursorVisible = true;
			Console.SetCursorPosition(0, 9);
			Console.Write(player + ", escolha a posição para jogar: ");
			
			do
			{
				Console.SetCursorPosition(41, 9); // Resets the cursor to its original position if the game field chosen is already filled
				Console.Write(" ");
				Console.SetCursorPosition(41, 9);
				positionPlayed = int.Parse(limitator.LimitInputDigitsOnlyNotZero(1, 1)) - 1; // Ensures the input can only be from 1 to 9
			}
			while (gameFields[positionPlayed] != ' '); // Only allows a certain field to be played if it's blank (that is, it wasn't already filled with X or O)
			
			gameFields[positionPlayed] = shape; // Fill the field with the character passed to the method (X if player 1, O if player 2)
			drawnFields[positionPlayed] = "     " + gameFields[positionPlayed] + "     "; // Fills the drawn fields to draw them on screen
		}
		
		// Method that handles a single turn being played by a human player, while using the arrow keys method
		private void PlayTurnHumanArrows(string player, char shape)
		{
			positionPlayed = 0;
			int previousPosition = 0;
			ConsoleKey keyPressed;
			bool validPosition;
			
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, 9);
			Console.Write(player + ", use as setas e enter para jogar.");
			
			do
			{
				validPosition = false;
				
				// The formula places the cursor at the left side of the currently selected game field
				Console.SetCursorPosition(10 + ((previousPosition % 3) * 15), 3 + (previousPosition / 3)); 
				Console.Write(" "); // Erases the "selection cursor" from the previous selection
				Console.SetCursorPosition(10 + ((positionPlayed % 3) * 15), 3 + (positionPlayed / 3));
				Console.Write(">"); // Draws a new "selection cursor" for the current selection
				
				Console.SetCursorPosition(0, 0);
				keyPressed = Console.ReadKey(true).Key;
				
				switch(keyPressed) // Handles the user input
				{
					case ConsoleKey.UpArrow: 
						{
							if (positionPlayed > 2) // If position was 2 or less, it would already be the top row, so can't move up any further
							{
								previousPosition = positionPlayed; // Records previous position
								positionPlayed -= 3; // Move cursor up
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (positionPlayed < 6) // If position is 6 or more, it would already be the bottom row, so can't move down any further
							{
								previousPosition = positionPlayed;
								positionPlayed += 3; // Move cursor down
							}
							break;
						}
					case ConsoleKey.LeftArrow:
						{
							if (!(positionPlayed == 0 || positionPlayed == 3 || positionPlayed == 6)) // If position is 0, 3 or 6, it's already the left column, so can't move left any further
							{
								previousPosition = positionPlayed;
								positionPlayed--; // Move cursor left
							}
							break;
						}
					case ConsoleKey.RightArrow:
						{
							if (!(positionPlayed == 2 || positionPlayed == 5 || positionPlayed == 8)) // If position is 2, 5 or 8, it's already the right column, so can't move right any further
							{
								previousPosition = positionPlayed;
								positionPlayed++; // Move cursor right
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							if (gameFields[positionPlayed] == ' ') // If the currently chosen position is empty, then it's a valid play
							{
								validPosition = true;
							}
							break;
						}
					default:
						{
							break;
						}
				}
			}
			while (!validPosition); // Keep going while it's not valid
			
			gameFields[positionPlayed] = shape; // Fills the game field for the current player
			drawnFields[positionPlayed] = "     " + gameFields[positionPlayed] + "     "; // Fills the drawn field
		}
		
		// TODO: Try to make multiple difficulties
		// Method that handles a single turn being played by a computer player
		private void PlayTurnComputer()
		{
			Console.SetCursorPosition(0, 9); // Erases the line that asks for player input, and informs it's the computer's turn
			Console.Write("Jogada do computador." + new string(' ', 30));
			Thread.Sleep(200);
			
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
			drawnFields[positionPlayed] = "     " + gameFields[positionPlayed] + "     ";
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
					drawnFields[0] = drawnFields[1] = drawnFields[2] = "<<<<<" + gameFields[0] + ">>>>>"; // Changes the drawn fields to show the winning lines differently
				}
				
				if ((gameFields[0] == gameFields[3]) && (gameFields[3] == gameFields[6]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[3] = drawnFields[6] = "<<<<<" + gameFields[0] + ">>>>>";
				}
				
				if ((gameFields[0] == gameFields[4]) && (gameFields[4] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[0] = drawnFields[4] = drawnFields[8] = "<<<<<" + gameFields[0] + ">>>>>";
				}
			}
			
			// Checks if field 4 (Middle) was played.
			// If it was played, checks all lines that contain it (except for the line that has already been checked above), to see if any of them have matching fields
			if (gameFields[4] != ' ')
			{
				if ((gameFields[3] == gameFields[4]) && (gameFields[4] == gameFields[5]))
				{
					winnerFound = true;
					drawnFields[3] = drawnFields[4] = drawnFields[5] = "<<<<<" + gameFields[4] + ">>>>>"; // Changes the drawn fields to show the winning lines differently
				}
				
				if ((gameFields[1] == gameFields[4]) && (gameFields[4] == gameFields[7]))
				{
					winnerFound = true;
					drawnFields[1] = drawnFields[4] = drawnFields[7] = "<<<<<" + gameFields[4] + ">>>>>";
				}
				
				if ((gameFields[2] == gameFields[4]) && (gameFields[4] == gameFields[6]))
				{
					winnerFound = true;
					drawnFields[2] = drawnFields[4] = drawnFields[6] = "<<<<<" + gameFields[4] + ">>>>>";
				}
			}
			
			// Checks if field 8 (Bottom Right) was played.
			// If it was played, checks all lines that contain it (except for the line that has already been checked above), to see if any of them have matching fields
			if (gameFields[8] != ' ')
			{
				if ((gameFields[6] == gameFields[7]) && (gameFields[7] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[6] = drawnFields[7] = drawnFields[8] = "<<<<<" + gameFields[8] + ">>>>>"; // Changes the drawn fields to show the winning lines differently
				}
				
				if ((gameFields[2] == gameFields[5]) && (gameFields[5] == gameFields[8]))
				{
					winnerFound = true;
					drawnFields[2] = drawnFields[5] = drawnFields[8] = "<<<<<" + gameFields[8] + ">>>>>";
				}
			}
		}
		#endregion
		
		#region Playing The Game
		// Method that actually starts the game
		public void PlayGame()
		{
			ResetGame();
			DrawGameBoard();
			
			while(!winnerFound) // Keep playing until a winner is found
			{
				currentTurn++;
				
				if (currentTurn > 9) // Declare a draw and leave if 9 turns have been played (Since that means every field is filled)
				{
					Console.SetCursorPosition(26, 14);
					Console.Write("Empate!");
					break;
				}
				
				isPlayerOneTurn = !isPlayerOneTurn; // Swaps the player before playing the turn (this means the variable should actually be set to "false" if player 1 is the one that starts the game)
				
				if (isPlayerOneTurn)
				{
					if (playWithArrows)
					{
						PlayTurnHumanArrows("Jogador 1", 'X');
					}
					else
					{
						PlayTurnHumanTyping("Jogador 1", 'X');
					}
				}
				else
				{
					if (againstComputer)
					{
						PlayTurnComputer();
					}
					else
					{
						if (playWithArrows)
						{
							PlayTurnHumanArrows("Jogador 2", 'O');
						}
						else
						{
							PlayTurnHumanTyping("Jogador 2", 'O');
						}
					}
				}
				Thread.Sleep(200);
				
				if (currentTurn > 4) // Only checks for a winner from the 5th turn onwards (There can only be a line match if any player has played at least 3 times)
				{
					CheckForWinner();
				}
				
				RedrawGameBoard();
			}
			
			if (winnerFound) // Shows the winner, depending on whose turn the win was declared
			{
				Console.SetCursorPosition(21, 14);
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
			
			Thread.Sleep(1000);
			Console.ReadKey();
		}
		#endregion
	}
}