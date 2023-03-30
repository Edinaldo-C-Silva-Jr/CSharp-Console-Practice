/*
 * Date: 28/03/2023
 * Time: 18:57
 */
using System;

namespace TicTacToe
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(49, 20);
			Console.SetBufferSize(49, 20);
			TicTacToe game = new TicTacToe();
			
			do
			{
				Console.Clear();
				Console.WriteLine("---------- Jogo da Velha ----------");
				Console.WriteLine("Escolha o número de jogadores (1 ou 2): ");
				
				game.SetOpponentMode();
				
				game.PlayGame();
				
				Console.ReadKey();
			}
			while (true); // Eventually will be "while input != esc"
		}
	}
}