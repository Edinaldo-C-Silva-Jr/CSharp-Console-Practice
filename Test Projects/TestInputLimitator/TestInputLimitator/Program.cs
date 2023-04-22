/*
 * Date: 13/04/2023
 * Time: 19:31
*/
using System;
using System.Threading;
using InputLimitator;

namespace TestInputLimitator
{
	class Program
	{
		// Tests the methods implemented by the InputLimitator class
		// They limit the input based on a desired maximum and minimum amount of characters accepted
		// They're also set to only allow specific characters to be accepted as input
		public static void Main(string[] args)
		{
			double number;
			string text;
			
			LimitInput limitator = new LimitInput();
			
			// Asks for a text input, with a minimum accepted size of 10 characters, and a maximum of 100
			// This method accepts any non-control character as input
			Console.WriteLine("Digite um texto qualquer (10 a 100 caracteres): ");
			text = limitator.LimitInputAll(10, 100);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Tests the way the method handles when the sizes are switched (That is. the minimum is bigger than the maximum)
			Console.WriteLine("Digite um texto qualquer (20 a 50 caracteres): ");
			text = limitator.LimitInputAll(50, 20);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Testing the overloaded method that only receives one parameter
			// The maximum amount of characters is 80, and there's no minimum
			Console.WriteLine("Digite um texto qualquer (máximo 80 caracteres): ");
			text = limitator.LimitInputAll(80);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			
			Console.WriteLine("Digite um número que não contenha zero (5 a 40 caracteres): ");
			text = limitator.LimitInputDigitsOnlyNotZero(5, 40);
			Console.WriteLine("\nNúmero: " + text + "\n");
			Thread.Sleep(800);
			
			
			// Asks for a numeric input, with a minimum accepted size of 10 characters, and a maximum of 30
			// This method accepts only number characters as input
			Console.WriteLine("Digite um número (10 a 30 caracteres): ");
			number = limitator.LimitInputDoubleNumber(10, 30);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			// Tests the way the method handles when the sizes are switched
			Console.WriteLine("Digite um número (15 a 40 caracteres): ");
			number = limitator.LimitInputDoubleNumber(40, 15);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			// Testing the overloaded method that only receives one parameter
			Console.WriteLine("Digite um número (máximo 50 caracteres): ");
			number = limitator.LimitInputDoubleNumber(50);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			
			// Asks for a text input, with a minimum accepted size of 20 characters, and a maximum of 120
			// This method accepts only letters, either lowercase or uppercase, as input
			Console.WriteLine("Digite um texto, somente letras (20 a 120 caracteres): ");
			text = limitator.LimitInputLetterOnly(20, 120);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Tests the way the method handles when the sizes are switched
			Console.WriteLine("Digite um texto, somente letras (10 a 70 caracteres): ");
			text = limitator.LimitInputLetterOnly(70, 10);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Testing the overloaded method that only receives one parameter
			Console.WriteLine("Digite um texto, somente letras (máximo 60 caracteres): ");
			text = limitator.LimitInputLetterOnly(60);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
		}
	}
}