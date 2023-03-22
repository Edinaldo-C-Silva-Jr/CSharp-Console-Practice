/*
 * Date: 07/03/2023
 * Time: 21:01
 */
using System;
using System.Threading;
using InputValidation;

// A super simple "Calculator" program i made back when i was getting back to C# development, with the bare minimum features to be functional.
// Keeping it here for archiving purposes. This version adds some polishing, but keeps the same features the original program did.
namespace CalculatorV1
{
	class Program
	{
		private static double number1, number2, result;
		private static char operationChosen = ' ', continueYesNo = 's';
		
		// Method that receives the inputs for the calculator
		private static void Input(ValidateInput validation)
		{
			Console.WriteLine("Digite o primeiro numero: "); // Asks for the first input and validates if it is a number
			number1 = validation.ValidateDouble();
			
			if (operationChosen == 'd') // Checks whether the operation is division
			{
				Console.WriteLine("Digite o segundo numero, ele deve ser diferente de 0: "); // If operation is division, then ask for a number that's not 0
				number2 = validation.ValidateDoubleNotZero();
			}
			else
			{
				Console.WriteLine("Digite o segundo numero: "); // If not division, then receive any number
				number2 = validation.ValidateDouble();
			}
		}
		
		public static void Main()
		{
			ValidateInput validationMain = new ValidateInput();
			
			while(continueYesNo == 's') // Program will keep running while this variable stays as 's' (short for "sim", which means yes). If the variable is 'n' (short for "não", which means no) the program will end.
			{
				Console.Clear();
				validationMain.SetValidChars(new char[] {'a', 's', 'm', 'd'}); // Sets the characters considered valid inputs
				Console.WriteLine("Digite a operação desejada.\nA = Adição, \nS = Subtração, \nM = Multipliacação, \nD = Divisão." );
				Console.WriteLine("Operação: ");
				operationChosen = Char.ToLower(validationMain.ValidateChar(false)); // Validates if the input is within the array of values considered valid, which were defined above
				Thread.Sleep(600);
				
				Console.Clear();
				
				switch(operationChosen)
				{
					case 'a': // Addition
						{
							Console.WriteLine("Operação Escolhida: Adição. \n");
							Input(validationMain);
							result = number1 + number2;
							Console.WriteLine("\nO valor da adição é: " + result);
							break;
						}
					case 's': // Subtraction
						{
							Console.WriteLine("Operação Escolhida: Subtração. \n");
							Input(validationMain);
							result = number1 - number2;
							Console.WriteLine("\nO valor da subtração é: " + result);
							break;
						}
					case 'm': // Multiplication
						{
							Console.WriteLine("Operação Escolhida: Multiplicação. \n");
							Input(validationMain);
							result = number1 * number2;
							Console.WriteLine("\nO valor da multiplicação é: " + result);
							break;
						}
					case 'd': // Division
						{
							Console.WriteLine("Operação Escolhida: Divisão. \n");
							Input(validationMain);
							result = number1 / number2;
							Console.WriteLine("\nO valor da divisão é: " + result);
							break;
						}
				}
				
				validationMain.SetValidChars(new char[] {'s', 'n'}); // Sets a new array of values considered valid for input
				Console.WriteLine("\nDeseja realizar outra operação? s/n"); // Asks if the user wants to do another operation
				continueYesNo = Char.ToLower(validationMain.ValidateChar(false));
				Thread.Sleep(600);
			}
		}
	}
}