/*
 * Date: 17/02/2023
 * Time: 22:33
*/
using System;
using InputValidation;
using System.Threading;

namespace TestInputValidation
{
	class TestInputValidation
	{
		// Testing all methods in the InputValidation class
		public static void Main(string[] args)
		{
			int integer;
			double number;
			string text;
			
			// Testing the validation of an integer value
			Console.WriteLine("Digite um número inteiro (int 32 bit):");
			integer = ValidateInput.ValidInt(); // Asks for an input and keeps trying until an integer is entered
			Console.WriteLine("Valor válido: " + integer);
			Thread.Sleep(1000);
			
			// Testing the validation of a double value
			Console.WriteLine("\nDigite um número qualquer: ");
			number = ValidateInput.ValidDouble(); // Asks for an input and keeps trying until a numeric (double) value is entered
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a string value, matching it with an array of expected inputs
			Console.WriteLine("\nDigite 'sim' ou 'nao' (pode utilizar apenas as iniciais): ");
			ValidateInput.SetValidValues(new string[] {"sim", "s", "nao", "não", "n"}); // Sets the ValidValues array to the values considered valid for this test
			text = ValidateInput.ValidInput(); // Asks for an input and keeps trying until the text entered corresponds to one of the values decided above
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a very specific string value
			Console.WriteLine("\nDigite a frase 'O rato roeu a roupa do rei de Roma':");
			ValidateInput.SetValidValues(new string[] {"o rato roeu a roupa do rei de roma"}); // Sets the ValidValues array with a new (and very specific) value for this test
			text = ValidateInput.ValidInput();
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a string value, but this time based on the amount of characters entered
			Console.WriteLine("\nDigite uma frase entre 20 e 50 caracteres: ");
			text = ValidateInput.ValidInputSize(20, 50); // Asks for an input and keeps trying until the entered text has a specific length (In this case, between 20 and 50 characters)
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric input, based on the value of the number itself
			Console.WriteLine("\nDigite um número entre 3859 e 8465: ");
			number = ValidateInput.ValidNumericValue(3859, 8465); // Asks for an input and keeps trying until the entered number has a value inside of a specific range (In this case, between 3859 and 8465)
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			Console.ReadKey();
		}
	}
}