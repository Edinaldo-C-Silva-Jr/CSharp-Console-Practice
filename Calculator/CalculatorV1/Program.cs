/*
 * Date: 07/03/2023
 * Time: 21:01
 */
using System;
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
		private static void Input()
		{
			Console.WriteLine("Digite o primeiro numero: "); // Asks for the first input and validates if it is a number
			number1 = ValidateInput.ValidDouble();
			
			if (operationChosen == 'd') // Checks whether the operation is division
			{
				Console.WriteLine("Digite o segundo numero, ele deve ser diferente de 0: "); // If operation is division, then ask for a number that's not 0
				number2 = ValidateInput.ValidDoubleNotZero();
			}
			else
			{
				Console.WriteLine("Digite o segundo numero: "); // If not division, then receive any number
				number2 = ValidateInput.ValidDouble();
			}
		}
		
		public static void Main()
		{	
			while(continueYesNo == 's') // Program will keep running while this variable stays as "yes" ("sim"). If the variable is "no" ("não") the program will end.
			{
				Console.Clear();
				ValidateInput.SetValidValues(new string[] {"a", "s", "m", "d"}); // Sets the strings considered valid inputs
				Console.WriteLine("Digite a operação desejada.\nA = Adição, \nS = Subtração, \nM = Multipliacação, \nD = Divisão." );
				Console.WriteLine("Operação: ");
				operationChosen = char.Parse(ValidateInput.ValidInput()); // Validates if the input is within the array of values considered valid, which were defined above
				
				Console.Clear();
				
				switch(operationChosen)
				{
					case 'a': // Addition
						{
							Console.WriteLine("Operação Escolhida: Adição. \n");
							Input();
							result = number1 + number2;
							Console.WriteLine("\nO valor da adição é: " + result);
							break;
						}
					case 's': // Subtraction
						{
							Console.WriteLine("Operação Escolhida: Subtração. \n");
							Input();
							result = number1 - number2;
							Console.WriteLine("\nO valor da subtração é: " + result);
							break;
						}
					case 'm': // Multiplication
						{
							Console.WriteLine("Operação Escolhida: Multiplicação. \n");
							Input();
							result = number1 * number2;
							Console.WriteLine("\nO valor da multiplicação é: " + result);
							break;
						}
					case 'd': // Division
						{
							Console.WriteLine("Operação Escolhida: Divisão. \n");
							Input();
							result = number1 / number2;
							Console.WriteLine("\nO valor da divisão é: " + result);
							break;
						}
				}
				
				ValidateInput.SetValidValues(new string[] {"s", "n"}); // Sets a new array of values considered valid for input
				Console.WriteLine("\nDeseja realizar outra operação? s/n"); // Asks if the user wants to do another operation
				continueYesNo = char.Parse(ValidateInput.ValidInput());
			}
		}
	}
}