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
			char character;
			
			ValidateInput validation = new ValidateInput();
			
			// Testing the validation of a string value, matching it with an array of expected inputs
			// The array of expected inputs has to be set (with the SetValidStrings method) before the ValidateString method can be used. Otherwise it will work exactly like a Console.ReadLine() and allow any input.
			// The method SetValidStrings is not case sensitive
			Console.WriteLine("Digite 'sim' ou 'nao' (pode utilizar apenas as iniciais): ");
			validation.SetValidStrings(new string[] {"sim", "s", "nao", "não", "n"}); // Sets the ValidStrings array to the values considered valid for this test
			text = validation.ValidateString(); // Asks for an input and keeps trying until the text entered corresponds to one of the values decided above
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a specific string value
			Console.WriteLine("\nDigite a frase 'O rato roeu a roupa do rei de Roma':");
			validation.SetValidStrings(new string[] {"O rato roeu a roupa do rei de Roma"}); // Sets the ValidStrings array with a new (and very specific) value for this test
			text = validation.ValidateString();
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a single character
			// The array of expected inputs has to eb set (with the SetValidChars method) before the ValidateChar method can be used. Otherwise it will work exactly like a Console.ReadKey() and allow any input
			// The method SetValidChars is not case sensitive 
			Console.WriteLine("\nDigite uma vogal (A, E, I, O ou U):");
			validation.SetValidChars(new char[] {'a', 'e', 'i', 'o', 'u'}); // Sets the ValidChars array with the values considered valid for this test
			character = validation.ValidateChar();
			Console.WriteLine("Valor válido: " + character);
			Thread.Sleep(1000);
			
			// Testing the validation of a 32-bit integer value
			Console.WriteLine("\nDigite um número inteiro (int 32 bit):");
			integer = validation.ValidateInt(); // Asks for an input and keeps trying until a 32 bit integer is entered
			Console.WriteLine("Valor válido: " + integer);
			Thread.Sleep(1000);
			
			// Testing the validation of a 32-bit integer value that cannot be 0
			Console.WriteLine("\nDigite um número inteiro (int 32 bit). Deve ser diferente de 0:");
			integer = validation.ValidateIntNotZero(); // Asks for an input and keeps trying until a 32 bit integer, that is not 0, is entered
			Console.WriteLine("Valor válido: " + integer);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric value (double variable)
			Console.WriteLine("\nDigite um número qualquer: ");
			number = validation.ValidateDouble(); // Asks for an input and keeps trying until a numeric value is entered
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric value that cannot be 0
			Console.WriteLine("\nDigite um número qualquer. Deve ser diferente de 0: ");
			number = validation.ValidateDoubleNotZero(); // Asks for an input and keeps trying until a numeric value, that is not 0, is entered
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a string value, but this time based on the amount of characters entered. 
			// The parameters passed to the method indicate the character amount allowed, defining both the minimum and maximum bounds for the amount of characters allowed. Note that, while the first is the minimum and the second is the maximum bound, the method swaps them in case the minimum is the higher bound
			// Note that the minimum parameter cannot be higher than 253, and the maximum cannot be lower than 1
			Console.WriteLine("\nDigite uma frase entre 20 e 50 caracteres: ");
			text = validation.ValidateInputSize(20, 50); // Asks for an input and keeps trying until the entered text has a specific length (In this case, between 20 and 50 characters)
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the way the method handles when the minimum bound is set higher than the maximum
			Console.WriteLine("\nDigite uma frase entre 10 e 5 caracteres: ");
			text = validation.ValidateInputSize(10, 5); // Despite the minimum bound being higher, the method should still correctly accept an input between 5 and 10 characters
			Console.WriteLine("Valor válido: " + text);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric input, based on the value of the number itself
			// The parameters passed to the method indicate the range of numbers allowed. Note that, while the first is the minimum and the second is the maximum value, the method swaps them in case the minimum is the higher value
			Console.WriteLine("\nDigite um número entre 3859 e 8465: ");
			number = validation.ValidateNumericValue(3859, 8465); // Asks for an input and keeps trying until the entered number has a value inside of a specific range (In this case, between 3859 and 8465)
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the way the method handles when the minimum value is higher than the maximum
			Console.WriteLine("\nDigite um número entre 3000 e 2000: ");
			number = validation.ValidateNumericValue(3000, 2000); // Despite the minimum value being higher, the method should still correctly accept a value between 2000 and 3000
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric input based on its sign
			// The parameter passed to the method indicates if the valid numbers should be positive or negative. Passing "true" means the method will validate for positive numbers
			Console.WriteLine("\nDigite um número positivo: ");
			number = validation.ValidateNumberSign(true); // Asks for an input and keeps trying until the entered number is positive
			Console.WriteLine("valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a numeric input based on its sign
			// The parameter passed to the method indicate if the valid numbers should be positive or negative. Passing "false" means the method will validate for negative numbers
			Console.WriteLine("\nDigite um número negativo: ");
			number = validation.ValidateNumberSign(false); // Asks for an input and keeps trying until the entered number is negative
			Console.WriteLine("valor válido: " + number);
			Thread.Sleep(1000);
			
			Console.ReadKey();
		}
	}
}