/*
 * Date: 17/03/2023
 * Time: 21:56
*/
using System;
using System.Media;
using System.Threading;

namespace YouCanMoveIt
{
	// A Hello World program with a twist: you can move the "Hello World!" text by using the arrow keys!
	class Program
	{
		private static int cursorX = 34, cursorY = 11; // Variables that record the cursor position. Started at specific values that ensure the text will be centered on the screen
		private static ConsoleKey command;
		
		// Method that erases the text by writing spaces in the current cursor position
		public static void EraseText ()
		{
			Console.SetCursorPosition(cursorX, cursorY);
			Console.Write("            ");
		}
		
		// Method that writes the Hello World text in the current cursor position
		public static void WriteText ()
		{
			Console.SetCursorPosition(cursorX, cursorY);
			Console.Write("Hello World!");
		}
		
		public static void Main ()
		{
			WriteText(); // Writes the text once the program starts. The starting cursor position values make it centered on the screen
			
			Console.SetCursorPosition(9, 24); // Writes this text at the bottom of the screen. horizontally centered on the screen
			Console.Write("Use the arrow keys to move the text around. Press Esc to exit.");
			
			while (command != ConsoleKey.Escape) // Keep running until the user presses the Esc key
			{
				command = Console.ReadKey(true).Key;
				
				switch(command)
				{
					case ConsoleKey.RightArrow: // If right arrow key is pressed...
						{
							if (cursorX < Console.BufferWidth - 12) // Makes sure the text cannot go past the right side of the screen, to prevent it from looping and to prevent a crash from the cursor position overflowing the buffer
							{
								EraseText(); // Erases the current text
								cursorX++; // Moves the cursor one space to the right
								WriteText(); // Writes it in the new position
							}
							break;
						}
					case ConsoleKey.LeftArrow: // If the left arrow key is pressed...
						{
							if (cursorX > 0) // Makes sure the text cannot go past the left side of the screen, to prevent a crash from invalid cursor position
							{
								EraseText(); // Erases the current text
								cursorX--; // Moves the cursor one space to the left
								WriteText(); // Writes it in the new position
							}
							break;
						}
					case ConsoleKey.UpArrow: // If the up arrow key is pressed...
						{
							if (cursorY > 0) // Makes sure the text cannot go past the top of the screen, to prevent a crash from invalid cursor position
							{
								EraseText(); // Erases the current text
								cursorY--; // Moves the cursor one space up
								WriteText(); // Writes it in the new position
							}
							break;
						}
					case ConsoleKey.DownArrow: // If the down arrow key is pressed...
						{
							if (cursorY < 23) // Makes sure the text cannot go into the bottom of the screen, to prevent it from overwriting the instructions at the bottom
							{
								EraseText(); // Erases the current text
								cursorY++; // Moves the cursor one space down
								WriteText(); // Writes it in the new position
							}
							break;
						}
					case ConsoleKey.Escape: // If the Ecs key is pressed...
						{
							Console.SetCursorPosition(9, 24); // Places cursor at the bottom to inform that the program is being exited
							Console.Write("                    Exiting the Program...                    ");
							Thread.Sleep(1000);
							break;
						}
					default: // If any other key is pressed...
						{
							SystemSounds.Beep.Play(); // Play a beep sound to inform it is invalid
							break;
						}
				}
			}
		}
	}
}