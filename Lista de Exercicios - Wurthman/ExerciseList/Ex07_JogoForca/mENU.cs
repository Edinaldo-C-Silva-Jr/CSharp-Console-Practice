/*
 * Date: 01/12/2023
 * Time: 22:54
 */
using System;
using System.Media;
using System.Threading;

namespace Ex07_JogoForca
{
	/// <summary>
	/// A class that implements a visual menu for the game, where the player can scroll through options such as difficulty selection or start the game.
	/// </summary>
	public class Menu
	{
		Difficulty chosenDifficulty;
		
		public Menu()
		{
			chosenDifficulty = Difficulty.Médio;
		}
		
		/// <summary>
		/// Draws the options of the menu onto the screen.
		/// </summary>
		private void DrawMenu()
		{
			Console.Clear();
			
			Console.SetCursorPosition(27, 0);
			Console.Write("----- JOGO DA FORCA -----");
			
			Console.SetCursorPosition(10, 22);
			Console.Write(" Setas: Mover Seleção    Enter: Selecionar   ESC: Sair");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Começar");
			Console.SetCursorPosition(10, 3);
			Console.Write("  Dificuldade: " + chosenDifficulty);
		}
		
		/// <summary>
		/// Redraws the line of the menu that shows the difficulty, to reflect a change in the difficulty setting.
		/// </summary>
		private void RedrawDifficulty()
		{
			Console.SetCursorPosition(10, 3);
			Console.Write("> Dificuldade: " + chosenDifficulty + "   ");
		}
		
		/// <summary>
		/// Moves the selection cursor of the menu to the option above the currently selected.
		/// </summary>
		/// <param name="currentSelection">The number of the option currently selected in the menu.</param>
		/// <returns>The number of the newly selected option.</returns>
		private int MoveSelectionUp(int currentSelection)
		{
			Console.SetCursorPosition(10, 1 + currentSelection); // Draws the cursor onto the new option
			Console.Write(">");
			Console.SetCursorPosition(10, 2 + currentSelection); // Erases the cursor from the previous option
			Console.Write(" ");
			return currentSelection - 1;
		}
		
		/// <summary>
		/// Moves the selection cursor of the menu to the option below the currently selected.
		/// </summary>
		/// <param name="currentSelection">The number of the option currently selected in the menu.</param>
		/// <returns>The number of the newly selected option.</returns>
		private int MoveSelectionDown(int currentSelection)
		{
			Console.SetCursorPosition(10, 2 + currentSelection); // Draws the cursor onto the new option
			Console.Write(" ");
			Console.SetCursorPosition(10, 3 + currentSelection); // Erases the cursor from the previous option
			Console.Write(">");
			return currentSelection + 1;
		}
		
		/// <summary>
		/// Runs the menu for the game.
		/// </summary>
		public void StartMenu()
		{
			ConsoleKey menuInput;
			int currentOption = 0;
			
			GameSetup setupGame = new GameSetup();
			setupGame.ReadWordListFile();
			HangmanGame game = new HangmanGame();
			
			DrawMenu();
			
			do
			{
				Console.SetCursorPosition(0,0);
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput)
				{
					case ConsoleKey.UpArrow:
						{
							if (currentOption == 0) // If already at the top, can't go up any further
							{
								SystemSounds.Beep.Play();
							}
							else
							{
								currentOption = MoveSelectionUp(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (currentOption >= 1) // If already at the bottom, can't go down any further
							{
								SystemSounds.Beep.Play();
							}
							else
							{
								currentOption = MoveSelectionDown(currentOption);
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							switch(currentOption)
							{
								case 0: // Option "Start Game". Picks the word, category and starts the game
									{
										Category wordCategory = setupGame.PickCategory();
										string chosenWord = setupGame.PickWord(wordCategory);
										game.PlayGame(wordCategory, chosenWord, chosenDifficulty);
										DrawMenu();
										break;
									}
								case 1: // Option "Choose Difficulty". 
									{
										int oldDifficulty = (int)chosenDifficulty;
										chosenDifficulty = (Difficulty)((oldDifficulty + 1) % 3); // Cycles through all 3 difficulties
										RedrawDifficulty();
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.SetCursorPosition(20, 12);
							Console.Write("Obrigado por jogar! Encerrando...");
							Thread.Sleep(1000);
							break;
						}
					default:
						{
							SystemSounds.Beep.Play();
							break;
						}
				}
			}
			while(menuInput != ConsoleKey.Escape);
		}
	}
}
