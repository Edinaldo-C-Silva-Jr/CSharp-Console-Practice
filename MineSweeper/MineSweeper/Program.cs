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
			Console.CursorVisible = false;
			Menu menu = new Menu();
			
			menu.StartMenu();
		}
	}
}