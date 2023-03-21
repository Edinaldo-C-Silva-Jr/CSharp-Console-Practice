/*
 * Date: 19/02/2023
 * Time: 15:24
 */
using System;
using System.Threading;
using InputValidation;

namespace DescendingText
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string textToDescend = "";
			int cursorX = 0, descendValue = 0;
			
			ValidateInput validation = new ValidateInput();
			
			Console.WriteLine("Digite um texto qualquer (No máximo do tamanho da tela): ");
			textToDescend = validation.ValidateInputSize(0, 80); // Only accept input with 0 to 80 characters in length
			Console.WriteLine("Digite a distância que o texto irá cair (De 1 a 23): ");
			descendValue = (int)validation.ValidateNumericValue(1, 23); // Only accept values from 1 to 23
			
			if (textToDescend == "") // Easter Egg condition to not allow a blank text to be entered
			{
				textToDescend = "Hello World!"; // Every program needs a Hello World!
			}
			
			Console.Clear();
			
			cursorX = (Console.BufferWidth - textToDescend.Length) / 2; // Sets the horizontal position of the cursor based on the text length and buffer width
			Console.SetCursorPosition(cursorX, 0); // Centralizes the text on the screen regardless of text or buffer size
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
						Console.Write(textToDescend.Substring(i, 1));
						
						Thread.Sleep(500 / (((2 + textToDescend.Length) / 2) * ((2 + descendValue) / 2))); // Timer to wait between each descend step. Based on both the text lenght and descending distance, essentially increasing the text speed when there are more steps.
					}
				}
			}
			Thread.Sleep(1000);
		}
	}
}