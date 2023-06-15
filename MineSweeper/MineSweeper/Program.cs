/*
 * Date: 04/06/2023
 * Time: 23:32
 */
using System;

namespace MineSweeper
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(163, 55);
			Console.SetBufferSize(164, 55);
			Console.CursorVisible = false;
			MineSweeper game = new MineSweeper(10, 20, 10);
			
			// TODO: Create menu
			game.StartGame();
		}
	}
}