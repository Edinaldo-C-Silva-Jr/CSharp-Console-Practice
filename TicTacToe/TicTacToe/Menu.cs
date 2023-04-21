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
		#region Draw and Redraw Menu
		
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
			Console.Write("> Iniciar Partida");
			
			Console.SetCursorPosition(10, 3);
			Console.Write("  Oponente: " + settings[0]);
			Console.SetCursorPosition(10, 4);
			Console.Write("  Controles: " + settings[1]);
			Console.SetCursorPosition(10, 5);
			Console.Write("  Primeira jogada: " + settings[2]);
			//Console.SetCursorPosition(10, 6);
			//Console.Write("  Dificuldade (computador): Fácil");
			
			ExplainOption(0);
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
		
		private void ExplainOption(int currentSelection)
		{
			Console.SetCursorPosition(0, 12);
			Console.Write(new String(' ', 160));
			
			switch(currentSelection)
			{
				case 0:
					{
						Console.SetCursorPosition(6, 12);
						Console.Write("Inicia uma partida com as configurações atuais.");
						break;
					}
				case 1:
					{
						Console.SetCursorPosition(15, 12);
						Console.Write("Define qual será o oponente.");
						Console.SetCursorPosition(4, 13);
						Console.Write("Pode ser um segundo jogador humano ou o computador.");
						break;
					}
				case 2:
					{
						Console.SetCursorPosition(10, 12);
						Console.Write("Define o tipo de controle usado no jogo.");
						Console.SetCursorPosition(5, 13);
						Console.Write("Pode ser digitando um número, ou usando as setas.");
						break;
					}
				case 3:
					{
						Console.SetCursorPosition(7, 12);
						Console.Write("Define quem faz a primeira jogada na partida.");
						break;
					}
			}
		}
		#endregion
		
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
								ExplainOption(currentOption);
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (currentOption >= 3)
							{
								SystemSounds.Beep.Play();
							}
							else
							{
								currentOption = MoveSelectionDown(currentOption);
								ExplainOption(currentOption);
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
								case 3:
									{
										game.SetFirstPlayer();
										RedrawCurrentSelection("Primeira jogada: ", game.GetCurrentSettings()[2], 3);
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.SetCursorPosition(0, 12);
							Console.Write(new String(' ', 160));
							Console.SetCursorPosition(20, 12);              
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