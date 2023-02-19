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
			//Input method
			textToDescend = Console.ReadLine();
			Console.WriteLine("Digite a distância que o texto irá cair: ");
			//Input method
			descendValue = int.Parse(Console.ReadLine());
			
			if (textToDescend == "")
			{
				textToDescend = "Hello World!";
			}
			
			Console.Clear();
			
			cursorX = (Console.BufferWidth - textToDescend.Length) / 2;
			Console.SetCursorPosition(cursorX, 0);
			Console.WriteLine(textToDescend);
			Thread.Sleep(1000);
			
			for(int i = 0; i < textToDescend.Length; i++)
			{
				if (textToDescend.Substring(i, 1) != " ")
				{
					for(int j = 0; j < descendValue; j++)
					{
						Console.SetCursorPosition(cursorX + i, j);
						Console.Write(" ");
						Console.SetCursorPosition(cursorX + i, j + 1);
						Console.WriteLine(textToDescend.Substring(i, 1));
						Thread.Sleep(500 / (((4 + textToDescend.Length) / 4) + ((2 + descendValue) / 2)));
					}
				}
			}
			Thread.Sleep(1000);
		}
	}
}