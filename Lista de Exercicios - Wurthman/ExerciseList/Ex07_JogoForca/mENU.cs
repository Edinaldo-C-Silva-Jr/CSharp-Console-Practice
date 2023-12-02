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
	/// Description of Menu.
	/// </summary>
	public class Menu
	{
		Difficulty chosenDifficulty;
		
		public Menu()
		{
			chosenDifficulty = Difficulty.Médio;
		}
		
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
		
		private void RedrawDifficulty()
		{
			Console.SetCursorPosition(10, 3);
			Console.Write("> Dificuldade: " + chosenDifficulty + "   ");
		}
		
		private int MoveSelectionUp(int currentSelection)
		{
			Console.SetCursorPosition(10, 1 + currentSelection);
			Console.Write(">");
			Console.SetCursorPosition(10, 2 + currentSelection);
			Console.Write(" ");
			return currentSelection - 1;
		}
		
		private int MoveSelectionDown(int currentSelection)
		{
			Console.SetCursorPosition(10, 2 + currentSelection);
			Console.Write(" ");
			Console.SetCursorPosition(10, 3 + currentSelection);
			Console.Write(">");
			return currentSelection + 1;
		}
		
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
							if (currentOption == 0)
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
							if (currentOption >= 1)
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
								case 0:
									{
										Category wordCategory = setupGame.PickCategory();
										string chosenWord = setupGame.PickWord(wordCategory);
										game.PlayGame(wordCategory, chosenWord, chosenDifficulty);
										DrawMenu();
										break;
									}
								case 1:
									{
										int oldDifficulty = (int)chosenDifficulty;
										chosenDifficulty = (Difficulty)((oldDifficulty + 1) % 3);
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
