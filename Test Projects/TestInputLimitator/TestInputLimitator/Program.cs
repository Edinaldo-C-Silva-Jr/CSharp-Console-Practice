/*
 * Date: 13/04/2023
 * Time: 19:31
*/
using System;
using InputLimitator;

namespace TestInputLimitator
{
	class Program
	{
		public static void Main(string[] args)
		{
			double number;
			string text;
			
			LimitInput limitator = new LimitInput();
			
			Console.WriteLine("Digite um texto qualquer: ");
			text = limitator.LimitInputAll(10, 100);
			Console.WriteLine("\n" + text);
			Console.ReadKey();
			
			Console.WriteLine("Digite um número (10 caracteres minimo): ");
			number = limitator.LimitInputNumberOnly(10, 30);
			Console.WriteLine("\n" + number);
			Console.ReadKey();
			
			Console.WriteLine("Digite um número: ");
			number = limitator.LimitInputNumberOnly(50);
			Console.WriteLine("\n" + number);
			Console.ReadKey();
		}
	}
}