/*
 * Date: 17/03/2023
 * Time: 22:36
*/
using System;
using System.Media;
using System.Threading;

namespace YouCanMoveIt
{
	class Program
	{
		private static int cursorX = 0, cursorY = 0;
		private static ConsoleKey command;
		
		public static void EraseText ()
		{
			Console.SetCursorPosition(cursorX, cursorY);
			Console.WriteLine("            ");
		}
		
		public static void WriteText ()
		{
			Console.SetCursorPosition(cursorX, cursorY);
			Console.WriteLine("Hello World!");
		}
		
		public static void Main ()
		{
			WriteText();
			
			Console.SetCursorPosition(10, 24);
			Console.Write("Use the arrow keys to move the text around. Press Esc to exit.");
			
			while (command != ConsoleKey.Escape)
			{
				command = Console.ReadKey(true).Key;
				
				switch(command)
				{
					case ConsoleKey.RightArrow:
						{
							EraseText();
							cursorX++;
							WriteText();
							
							break;
						}
					case ConsoleKey.LeftArrow:
						{
							EraseText();
							cursorX--;
							WriteText();
							
							break;
						}
					case ConsoleKey.UpArrow:
						{
							EraseText();
							cursorY--;
							WriteText();
							
							break;
						}
					case ConsoleKey.DownArrow:
						{
							EraseText();
							cursorY++;
							WriteText();
							
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.SetCursorPosition(10, 24);
							Console.Write("                    Exiting the Program...                    ");
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
		}
	}
}