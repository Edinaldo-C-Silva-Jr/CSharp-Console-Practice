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
			
			Console.WriteLine("Digite um texto qualquer (10 a 100 caracteres): ");
			text = limitator.LimitInputAll(10, 100);
			Console.WriteLine("\n" + text);
			Console.ReadKey();
			
			Console.WriteLine("Digite um texto qualquer (máximo 80 caracteres): ");
			text = limitator.LimitInputAll(80);
			Console.WriteLine("\n" + text);
			Console.ReadKey();
			
			Console.WriteLine("Digite um número (10 a 30 caracteres): ");
			number = limitator.LimitInputNumberOnly(10, 30);
			Console.WriteLine("\n" + number);
			Console.ReadKey();
			
			Console.WriteLine("Digite um número (máximo 50 caracteres): ");
			number = limitator.LimitInputNumberOnly(50);
			Console.WriteLine("\n" + number);
			Console.ReadKey();
			
			Console.WriteLine("Digite um texto, somente letras (20 a 120 caracteres): ");
			text = limitator.LimitInputLetterOnly(20, 120);
			Console.WriteLine("\n" + text);
			Console.ReadKey();
			
			Console.WriteLine("Digite um texto, somente letras (máximo 60 caracteres): ");
			text = limitator.LimitInputLetterOnly(60);
			Console.WriteLine("\n" + text);
			Console.ReadKey();
		}
	}
}