/*
 * Date: 19/02/2023
 * Time: 15:24
 */
using System;
using System.Threading;

namespace DescendingText
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string textToDescend = "";
			int cursorX = 0, descendValue = 0;
			
			Console.WriteLine("Digite um texto qualquer: ");
			//Input method (1 a 80)
			textToDescend = Console.ReadLine();
			Console.WriteLine("Digite a distância que o texto irá cair: ");
			//Input method (1 a 23)
			descendValue = int.Parse(Console.ReadLine());
			
			if (textToDescend == "") // Easter Egg condition to not allow a blank text to be entered
			{
				textToDescend = "Hello World!"; // Every program needs a Hello World
			}
			
			Console.Clear();
			
			cursorX = (Console.BufferWidth - textToDescend.Length) / 2; // Sets the horizontal position of the cursor based on the text length and buffer width
			Console.SetCursorPosition(cursorX, 0); // Centralizes the text on the screen no regardless of text or buffer size
			Console.WriteLine(textToDescend);
			Thread.Sleep(1000);
			
			for(int i = 0; i < textToDescend.Length; i++) // Each iteration refers to one character of the text
			{
				if (textToDescend.Substring(i, 1) != " ") // Skips descending process if the character
				{
					for(int j = 0; j < descendValue; j++) // Each iteration refers to one line of text descending
					{
						Console.SetCursorPosition(cursorX + i, j); // Makes current position blank
						Console.Write(" ");
						Console.SetCursorPosition(cursorX + i, j + 1); // Writes character on the position below
						Console.WriteLine(textToDescend.Substring(i, 1));
						
						Thread.Sleep(500 / (((4 + textToDescend.Length) / 4) * ((3 + descendValue) / 3))); // Timer to wait between each descend step. Based on both the text lenght and descending distance, essentially increasing the text speed when there are more steps.
					}
				}
			}
			Thread.Sleep(1000);
		}
	}
}