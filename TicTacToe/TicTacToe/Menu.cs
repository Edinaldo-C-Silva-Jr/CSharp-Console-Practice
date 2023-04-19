/*
 * Date: 19/04/2023
 * Time: 20:00
*/
using System;
using System.Media;
using System.Threading;

namespace TicTacToe
{
	public class Menu
	{
		private void DrawMenu(string[] settings)
		{
			Console.Clear();
			Console.SetCursorPosition(40, 19);
			Console.Write("Versão 1.0");
			
			Console.SetCursorPosition(17, 0);
			Console.Write("----- Jogo da Velha -----");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Jogar");
			
			Console.SetCursorPosition(10, 3);
			Console.Write("  Oponente: " + settings[0]);
			//Console.SetCursorPosition(10, 4);
			//Console.Write("  Símbolo: X / O")
			//Console.SetCursorPosition(10, 5);
			//Console.Write("  Controles: Digitar");
			//Console.SetCursorPosition(10, 6);
			//Console.Write("  Dificuldade (computador): Fácil");
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
			
			TicTacToe game = new TicTacToe();
			
			DrawMenu(game.GetCurrentSettings());
			
			do
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0, 0);
				menuInput = Console.ReadKey(true).Key;
				
				switch(menuInput)
				{
					case ConsoleKey.UpArrow:
						{
							if (currentOption <= 0)
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
										game.PlayGame();
										DrawMenu(game.GetCurrentSettings());
										break;
									}
								case 1:
									{
										if (game.SetOpponentMode())
										{
											Console.SetCursorPosition(22, 3);
											Console.Write("Computador");
										}
										else
										{
											Console.SetCursorPosition(22, 3);
											Console.Write("Humano" + "    ");
										}
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.SetCursorPosition(20, 15);
							Console.Write("Obrigado por jogar!");
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
			while (menuInput != ConsoleKey.Escape);
		}
	}
}
