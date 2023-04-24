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
			
			// Asks for a text input, with a minimum accepted size of 5 characters, and a maximum of 50
			// This method accepts any non-control character as input
			Console.WriteLine("Digite um texto qualquer (5 a 50 caracteres): ");
			text = limitator.LimitInputAll(5, 50);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Tests the way the method handles when the sizes are switched (That is. the minimum is bigger than the maximum)
			Console.WriteLine("Digite um texto qualquer (10 a 60 caracteres): ");
			text = limitator.LimitInputAll(60, 10);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			// Testing the overloaded method that only receives one parameter
			// The maximum amount of characters is 80, and there's no minimum
			Console.WriteLine("Digite um texto qualquer (máximo 80 caracteres): ");
			text = limitator.LimitInputAll(80);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			
			// This method accepts only digit characters, from 0 to 9, and stores them as a string value
			Console.WriteLine("Digite um número qualquer (10 a 80 caracteres): ");
			text = limitator.LimitInputDigitsOnly(10, 80);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número qualquer (5 a 40 caracteres): ");
			text = limitator.LimitInputDigitsOnly(40, 5);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número qualquer (máximo 60 caracteres): ");
			text = limitator.LimitInputDigitsOnly(60);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			
			// This method accepts only digit characters, from 0 to 9, and stores them as a double value
			// Note: If the amount of characters is higher than 307, the entered number can overflow the size of a double variable, thus marking input as invalid
			Console.WriteLine("Digite um número (10 a 45 caracteres): ");
			number = limitator.LimitInputDoubleNumber(10, 45);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número (5 a 60 caracteres): ");
			number = limitator.LimitInputDoubleNumber(60, 5);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número (máximo 100 caracteres): ");
			number = limitator.LimitInputDoubleNumber(100);
			Console.WriteLine("\nNúmero: " + number + "\n");
			Thread.Sleep(800);
			
			
			// This method accepts only digit characters, from 1 to 9, and stores them as a string value
			Console.WriteLine("Digite um número qualquer que não contenha 0 (5 a 30 caracteres): ");
			text = limitator.LimitInputDigitsOnlyNotZero(5, 30);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número qualquer que não contenha 0 (10 a 70 caracteres): ");
			text = limitator.LimitInputDigitsOnlyNotZero(70, 10);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um número qualquer que não contenha 0 (máximo 90 caracteres): ");
			text = limitator.LimitInputDigitsOnlyNotZero(90);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			
			// This method accepts only letters, either lowercase or uppercase, as input
			Console.WriteLine("Digite um texto, somente letras (10 a 60 caracteres): ");
			text = limitator.LimitInputLetterOnly(10, 60);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um texto, somente letras (10 a 70 caracteres): ");
			text = limitator.LimitInputLetterOnly(70, 10);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
			
			Console.WriteLine("Digite um texto, somente letras (máximo 80 caracteres): ");
			text = limitator.LimitInputLetterOnly(80);
			Console.WriteLine("\nTexto: " + text + "\n");
			Thread.Sleep(800);
		}
	}
}