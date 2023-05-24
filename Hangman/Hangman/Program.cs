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
			string chosenWord;
			int chosen;
			Random choice = new Random();
			
			Words list = new Words();
			
			for (int i = 0; i < 10; i++)
			{
				chosen = choice.Next(1, 76);
				chosenWord = list.countries[chosen];
				
				Console.WriteLine(chosen + " - " + chosenWord);
			}
			
			Console.ReadKey();
		}
	}
}