/*
 * Date: 10/03/2023
 * Time: 19:09
 */
using System;
using System.Threading;
using InputValidation;

// A second version of the simple "Calculator" program i made when getting back to C# development
// Similarly simple, however, this one allows doing the same operation multiple times (but only the same operation). It also keeps track of all values entered, so it can show them on screen as they're entered.
// This wasn't a good implementation, most notably for the subtraction and division operations. But it was an attempt before i got to the V3 of the application, so it is being kept as it was made.
// Like the first one, this is kept for archiving purposes. It also has some polishing compared to the original implementation.
namespace CalculatorV2
{
	class Program
	{
		private static double[] numbers;
		private static double result;
		
		// Method to ask for and receive an input
		private static void Input(int i, ValidateInput validation)
		{
			Console.WriteLine("\nDigite o " + (i+1) + "º numero: ");
			numbers[i] = validation.ValidateDouble();
		}
		
		// Method that asks and receives an input for the division operation. It doesn't accept 0 as an input
		private static void InputDivision(int i, ValidateInput validation)
		{
			Console.WriteLine("\nDigite o " + (i+1) + "º numero. Deve ser diferente de 0: ");
			numbers[i] = validation.ValidateDoubleNotZero();
		}
		
		// Method that receives the initial input for division and subtraction
		// These 2 operations need a different treatment because the subsequent values are subtracted from/divide the first one
		private static void InputInitial (string operation, string action, ValidateInput validation)
		{
			Console.Clear();
			Console.WriteLine("Operação Escolhida: " + operation);
			Console.WriteLine("Digite o valor inicial, os restantes serão " + action + " dele.");
			result = numbers[0] = validation.ValidateDouble();
		}
		
		// Method that shows all previous inputs during a set of operations
		private static void ShowInputs(string operation, int i)
		{
			Console.Clear();
			Console.WriteLine("Operação Escolhida: " + operation + ". \n\nValores: ");
			
			for (int j = 0; j < i; j++) {
				Console.WriteLine(numbers[j]);
			}
		}
		
		public static void Main()
		{
			int quantity;
			char operationChosen = ' ', continueYesNo = 's';
			
			ValidateInput validationMain = new ValidateInput();
			
			while(continueYesNo == 's') // Program will keep running while this variable stays as 's' (short for "sim", which means yes). If the variable is 'n' (short for "não", which means no) the program will end.
			{
				Console.Clear();
				validationMain.SetValidChars(new char[] {'a', 's', 'm', 'd'}); // Sets the characters considered valid inputs
				Console.WriteLine("Digite a operação desejada.\nA = Adição, \nS = Subtração, \nM = Multipliacação, \nD = Divisão."); Console.WriteLine("Operação: ");
				operationChosen = Char.ToLower(validationMain.ValidateChar(false)); // Validates if the input is within the array of values considered valid, which were defined above
				Thread.Sleep(600);
					
				Console.Clear();
				
				Console.WriteLine("Digite a quantidade de entradas de dados. \nAo menos 2 entradas são necessárias, e um máximo de 20 serão aceitas. \nEntradas: "); // Asks for the amount of inputs that will be entered for this set of operations. 
				quantity = (int)validationMain.ValidateNumericValue(2, 20); // 2 inputs are minimum in order to make at least one operation. 20 inputs has been arbitrarily defined as a maximum value to keep the program reasonable
				
				numbers = new double[quantity]; // Creates an array to receive the amount of inpus defined above
				
				switch(operationChosen)
				{
					case 'a': // Addition
						{
							result = 0;
							for (int i = 0; i < quantity; i++)
							{
								ShowInputs("Adição", i);
								Input(i, validationMain);
								result = result + numbers[i];
							}
							ShowInputs("Adição", quantity);
							Console.WriteLine("\nO valor da adição é: " + result);
							break;
						}
					case 's': // Subtraction
						{
							InputInitial("Subtração", "subtraídos", validationMain);
							
							for (int i = 1; i < quantity; i++)
							{
								ShowInputs("Subtração", i);
								Input(i, validationMain);
								result = result - numbers[i];
							}
							ShowInputs("Subtração", quantity);
							Console.WriteLine("\nO valor da subtração é: " + result);
							break;
						}
					case 'm': // Multiplication
						{
							result = 1;
							for (int i = 0; i < quantity; i++)
							{
								ShowInputs("Multiplicação", i);
								Input(i, validationMain);
								result = result * numbers[i];
							}
							ShowInputs("Multiplicação", quantity);
							Console.WriteLine("\nO valor da multiplicação é: " + result);
							break;
						}
					case 'd': // Division
						{
							InputInitial("Divisão", "divididos", validationMain);
							
							for (int i = 1; i < quantity; i++)
							{
								ShowInputs("Divisão", i);
								InputDivision(i, validationMain);
								result = result / numbers[i];
							}
							ShowInputs("Divisão", quantity);
							Console.WriteLine("\nO valor da divisão é: " + result);
							break;
						}
				}
				
				validationMain.SetValidChars(new char[] {'s', 'n'}); // Sets a new array of characters considered valid for input
				Console.WriteLine("\nDeseja realizar outra operação? S/N"); // Asks if the user wants to do another operation
				continueYesNo = Char.ToLower(validationMain.ValidateChar(false));
				Thread.Sleep(600);
			}
		}
	}
}