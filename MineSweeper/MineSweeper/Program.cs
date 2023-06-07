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
			Console.SetWindowSize(161, 55);
			Console.SetBufferSize(163, 55);
			MineSweeper game = new MineSweeper(40,25);
			
			
			game.StartGame();
		}
	}
}