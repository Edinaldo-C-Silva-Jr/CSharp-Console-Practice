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
			Console.SetWindowSize(59, 20); // Sets the window size to better fit the size of the game board
			Console.SetBufferSize(59, 20);
			
			Menu gameMenu = new Menu();
			
			gameMenu.StartMenu();
		}
	}
}