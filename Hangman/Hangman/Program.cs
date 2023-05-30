/*
 * Date: 23/05/2023
 * Time: 20:28
 */
using System;

namespace Hangman
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(59, 20);
			Console.SetBufferSize(59, 20);
			Menu menu = new Menu();
			
			menu.StartMenu();
		}
	}
}