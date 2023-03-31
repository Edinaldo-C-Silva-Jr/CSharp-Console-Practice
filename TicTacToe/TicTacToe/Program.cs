/*
 * Date: 28/03/2023
 * Time: 18:57
 */
using System;

namespace TicTacToe
{
	// An application that allows playing a game of Tic Tac Toe. Can be played by 2 humans, or by 1 human against a computer player.
	
	// Version 1.0: All basic features are finished. The game is fully functional and playable.
	// Can be played by 2 humans, or against a computer player (with very basic AI)
	class Program
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(49, 20); // Sets the window size to better fit the size of the game board
			Console.SetBufferSize(49, 20);
			TicTacToe game = new TicTacToe();
			
			do
			{
				Console.Clear();
				Console.SetCursorPosition(35, 19);
				Console.Write("Versão 1.0");
				Console.SetCursorPosition(0, 0);
				Console.WriteLine("-------- Jogo da Velha --------");
				Console.WriteLine("Escolha o número de jogadores (1 ou 2): ");
				
				game.SetOpponentMode(); // Asks for player amount and defines who the opponent will be
				
				game.PlayGame();
			}
			while (true); // TODO: Eventually will be "while input != esc"
		}
	}
}