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
			
			Console.SetCursorPosition(17, 0);
			Console.Write("----- Jogo da Velha -----");
			
			Console.SetCursorPosition(47, 19);
			Console.Write("Versão 1.0");
			Console.SetCursorPosition(5, 17);
			Console.Write("Setas: Mover     Enter: Selecionar     Esc: Sair");
			
			Console.SetCursorPosition(10, 2);
			Console.Write("> Jogar");
			
			Console.SetCursorPosition(10, 3);
			Console.Write("  Oponente: " + settings[0]);
			Console.SetCursorPosition(10, 4);
			Console.Write("  Controles: " + settings[1]);
			//Console.SetCursorPosition(10, 5);
			//Console.Write("  Símbolo: X / O")
			//Console.SetCursorPosition(10, 6);
			//Console.Write("  Dificuldade (computador): Fácil");
		}
		
		private void RedrawCurrentSelection(string text, string setting, int current)
		{
			Console.SetCursorPosition(10, 2 + current);
			Console.Write("> " + text + setting);
			
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
							if (currentOption >= 2)
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
										game.SetOpponentMode();
										RedrawCurrentSelection("Oponente: ",game.GetCurrentSettings()[0], 1);
										break;
									}
								case 2:
									{
										game.SetControlType();
										RedrawCurrentSelection("Controles: ", game.GetCurrentSettings()[1], 2);
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
