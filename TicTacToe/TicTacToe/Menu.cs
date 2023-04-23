/*
 * Date: 19/04/2023
 * Time: 20:00
 */
using System;
using System.Media;
using System.Threading;

namespace TicTacToe
{
	// Implements a main menu screen for the game of TicTacToe
	// The menu screen can be controlled with the up/down arrow keys, and enter is used to choose an option
	// This menu handles all game settings, and starting a match
	public class Menu
	{
		#region Draw and Redraw Menu
		// Draws the entire menu
		// This is used once the program starts, and after a match is finished
		private void DrawMenu(string[] settings)
		{
			Console.Clear();
			
			Console.SetCursorPosition(17, 0); // Displays the game title centered on the screen
			Console.Write("----- Jogo da Velha -----");
			Console.SetCursorPosition(47, 19); // Displays current version on the screen corner
			Console.Write("Versão 2.0");
			Console.SetCursorPosition(5, 17);
			Console.Write("Setas: Mover     Enter: Selecionar     Esc: Sair");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Iniciar Partida");
			
			Console.SetCursorPosition(10, 3);
			Console.Write("  Oponente: " + settings[0]); // Displays the actual current value of these settings
			Console.SetCursorPosition(10, 4);
			Console.Write("  Controles: " + settings[1]);
			Console.SetCursorPosition(10, 5);
			Console.Write("  Primeira jogada: " + settings[2]);
			//Console.SetCursorPosition(10, 6);
			//Console.Write("  Dificuldade (computador): Fácil");
			
			ExplainOption(0);
		}
		
		// Redraws only the currently selected line
		// Used whenever a setting is changed, to accurately display the changed value without having to redraw the entire menu
		private void RedrawCurrentSelection(string text, string setting, int current)
		{
			Console.SetCursorPosition(10, 2 + current);
			Console.Write("> " + text + setting); // Redraws entire line with the selection cursor
			
		}
		
		// Moves the "selection cursor" (the > that points at the current option) one option up
		private int MoveSelectionUp(int currentSelection)
		{
			Console.SetCursorPosition(10, 1 + currentSelection); // Draws the cursor on the option above the currently selected
			Console.Write(">");
			Console.SetCursorPosition(10, 2 + currentSelection); // Erases the cursor on the current option
			Console.Write(" ");
			return currentSelection - 1; // Returns the newly selected option
		}
		
		// Moves the "selection cursor" one option down
		private int MoveSelectionDown(int currentSelection)
		{
			Console.SetCursorPosition(10, 2 + currentSelection);
			Console.Write(" ");
			Console.SetCursorPosition(10, 3 + currentSelection);
			Console.Write(">");
			return currentSelection + 1;
		}
		
		// Adds an explanation for the currently selected option
		private void ExplainOption(int currentSelection)
		{
			Console.SetCursorPosition(0, 12); // Erases any previous explanation that might be in place
			Console.Write(new String(' ', 160));
			
			string[] explanation = new String[2];
			
			switch(currentSelection) // Fills the explanation string with a different text depending on which option is currently selected
			{
				case 0:
					{
						explanation[0] = "Inicia uma partida com as configurações atuais.";
						break;
					}
				case 1:
					{
						explanation[0] = "Define qual será o oponente.";
						explanation[1] = "Pode ser um segundo jogador humano ou o computador.";
						break;
					}
				case 2:
					{
						explanation[0] = "Define o tipo de controle usado no jogo.";
						explanation[1] = "Pode ser digitando um número, ou usando as setas.";
						break;
					}
				case 3:
					{
						explanation[0] = "Define quem faz a primeira jogada na partida.";
						break;
					}
			}
			
			for (int i = 0; i < 2; i++) // Draws the explanation on screen
			{
				if (explanation[i] != null) // But only if the explanation actually exists
				{
					Console.SetCursorPosition((59 - explanation[i].Length) / 2, 12 + i); // Makes sure the text is centered
					Console.Write(explanation[i]);
				}
			}
			
		}
		#endregion
		
		#region Start the Menu
		// Actually starts the menu and gives the player control of it
		public void StartMenu()
		{
			ConsoleKey menuInput;
			int currentOption = 0;
			
			TicTacToe game = new TicTacToe();
			
			DrawMenu(game.GetCurrentSettings()); // Gets the current settings (default settings) to display the correct values in the menu
			
			do
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0, 0);
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput) // Handles user input
				{
					case ConsoleKey.UpArrow: // Up arrow pressed
						{
							if (currentOption <= 0) // If already at the top, can't move up any further
							{
								SystemSounds.Beep.Play();
							}
							else // If not at the top, then move one option up
							{
								currentOption = MoveSelectionUp(currentOption);
								ExplainOption(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow: // Down arrow pressed
						{
							if (currentOption >= 3) // If already at the bottom, can't go down any further
							{
								SystemSounds.Beep.Play();
							}
							else // If not at the bottom, then move one option down
							{
								currentOption = MoveSelectionDown(currentOption);
								ExplainOption(currentOption);
							}
							break;
						}
					case ConsoleKey.Enter: // Enter is pressed
						{
							switch(currentOption)
							{
								case 0: // First option: Start Game
									{
										game.PlayGame(); // Starts the game
										DrawMenu(game.GetCurrentSettings()); // Once it's over, redraw the entire menu
										break;
									}
								case 1: // Second option: Set opponent
									{
										game.SetOpponentMode(); // Change opponent (Computer <-> Human)
										RedrawCurrentSelection("Oponente: ",game.GetCurrentSettings()[0], 1);
										break;
									}
								case 2: // Third option: Set controls
									{
										game.SetControlType(); // Change controls (Typing <-> arrows)
										RedrawCurrentSelection("Controles: ", game.GetCurrentSettings()[1], 2);
										break;
									}
								case 3: // Fourth option: Set first player
									{
										game.SetFirstPlayer(); // Setswho goes first (Player 1 <-> Player 2)
										RedrawCurrentSelection("Primeira jogada: ", game.GetCurrentSettings()[2], 3);
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape: // Esc is pressed
						{
							Console.SetCursorPosition(0, 12); // Write "Thanks for playing!" in the place of the explanations
							Console.Write(new String(' ', 160));
							Console.SetCursorPosition(20, 12);
							Console.Write("Obrigado por jogar!");
							Thread.Sleep(1000);
							break;
						}
					default: // Any other key is pressed
						{
							SystemSounds.Beep.Play();
							break;
						}
				}
			}
			while (menuInput != ConsoleKey.Escape); // Keep going until Esc is pressed
		}
		#endregion
	}
}