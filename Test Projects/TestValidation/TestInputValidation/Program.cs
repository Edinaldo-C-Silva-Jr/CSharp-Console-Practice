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
		public static void Main(string[] args)
		{
			int integer;
			double number;
			string yesno;
			string specific;
			
			// Testing the validation of an integer value
			Console.WriteLine("Digite um número inteiro (int 32 bit):");
			integer = ValidateInput.ValidInt();
			Console.WriteLine("Valor válido: " + integer);
			Thread.Sleep(1000);
			
			// Testing the validation of a double value
			Console.WriteLine("\nDigite um número qualquer: ");
			number = ValidateInput.ValidDouble();
			Console.WriteLine("Valor válido: " + number);
			Thread.Sleep(1000);
			
			// Testing the validation of a string value
			Console.WriteLine("\nDigite 'sim' ou 'nao' (pode utilizar apenas as iniciais): ");
			ValidateInput.SetValidValues(new string[] {"sim", "s", "nao", "não", "n"}); // Sets the ValidValues array to the values considered valid for this test
			yesno = ValidateInput.ValidInput();
			Console.WriteLine("Valor válido: " + yesno);
			Thread.Sleep(1000);
			
			// Testing the validation of a very specific string value
			Console.WriteLine("\nDigite a frase 'O rato roeu a roupa do rei de Roma':");
			ValidateInput.SetValidValues(new string[] {"o rato roeu a roupa do rei de roma"}); // Sets the ValidValues array with a new set of vallues for this test
			specific = ValidateInput.ValidInput();
			Console.WriteLine("Valor válido: " + specific);
			Thread.Sleep(1000);
			
			Console.ReadKey();
		}
	}
}