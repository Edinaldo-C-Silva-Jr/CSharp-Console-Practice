/*
 * Date: 13/03/2023
 * Time: 20:48
 */
using System;
using System.Threading;
using InputValidation;

// Third and final version of the simple Calculator application i made when getting back to C# development
// This one acts a little more like a calculator, in that it allows the user to dynamically do operations with no hard limit of how many are being done. It also allows to clear the current number at any time to start a new operation
// This is also being kept for archiving purposes. And it also received some polishing
namespace CalculatorV3
{
	class Program
	{
		private static double numberForOperation, currentNumber;
		private static char commandEntered = ' ';
		private static char[] validCommands = {'+', '-', '*', '/', '?', 'S', 'E'}; // Commands accepted by the program
		
		// Method that receives an input. It displays a dynamic message that can be defined as a parameter
		private static double Input(string messageToDisplay, ValidateInput validation)
		{
			Console.WriteLine("\n" + messageToDisplay);
			return validation.ValidateDouble();
		}
		
		// Method that receives an input for the division operation. It does not accept 0 as an input
		// It displays a dynamic message that can be defined as a parameter
		public static void InputDivision(string messageToDislpay, ValidateInput validation)
		{
			Console.WriteLine("\n" + messageToDislpay);
			numberForOperation = validation.ValidateDoubleNotZero();
		}
		
		// Method that redraws the main screen after each operation is done
		public static void DrawMainScreen()
		{
			Console.Clear();
			Console.WriteLine("-----------------     CALCULADORA     -----------------");
			Console.WriteLine("Digite um comando válido para iniciar as operações."); 
			Console.WriteLine("Para saber os comandos válidos, digite '?'");
			Console.WriteLine("As operações serão realizadas com o valor abaixo.");
			Console.WriteLine("Valor atual: " + currentNumber);
		}
		
		// Method that shows the help option, informing what are the valid commands and what they do
		public static void ShowHelp()
		{
			Console.Clear();
			Console.WriteLine("-------------------------     CALCULADORA     -------------------------");
			Console.WriteLine("\n(S) - Permite digitar o primeiro número que será utilizado nas operações. Caso este comando não seja utilizado, o número utilizado será o resultado da operação anterior.");
			Console.WriteLine("\n(+) - Realiza uma operação de adição, onde o primeiro número é o 'valor atual', e o segundo número deve ser digitado.");
			Console.WriteLine("\n(-) - Realiza uma operação de subtração, onde o primeiro número é o 'valor atual', e o segundo número deve ser digitado.");
			Console.WriteLine("\n(*) - Realiza uma operação de multiplicação, onde o primeiro número é o 'valor atual', e o segundo número deve ser digitado.");
			Console.WriteLine("\n(/) - Realiza uma operação de divisão, onde o primeiro número é o 'valor atual', e o segundo número deve ser digitado.");
			Console.WriteLine("\n(E) - Finaliza o programa.");
			Console.ReadKey();
		}
		
		public static void Main()
		{
			ValidateInput validationMain = new ValidateInput();
			
			while(commandEntered != 'e') // While the command is not "e" (for Exit), the program will keep running
			{
				DrawMainScreen();
				Console.Write("Comando: ");
				validationMain.SetValidChars(validCommands); // Sets the characters considered valid commands for the program
				commandEntered = Char.ToLower(validationMain.ValidateChar(false));
				Thread.Sleep(600);
				
				switch(commandEntered)
				{
					case 's': // Starting value: receives the first value to start an operation
						{
							currentNumber = Input("\nNúmero Inicial: ", validationMain);
							break;
						}
					case '?': // Help: Shows the available commands
						{
							ShowHelp();
							break;
						}
					case '+': // Addition
						{
							Console.WriteLine("\n\nAdição");
							numberForOperation = Input("Digite o segundo termo: ", validationMain);
							currentNumber += numberForOperation;
							break;
						}
					case '-': // Subtraction
						{
							Console.WriteLine("\n\nSubtração");
							numberForOperation = Input("Digite o segundo termo: ", validationMain);
							currentNumber -= numberForOperation;
							break;
						}
					case '*': // Multiplication
						{
							Console.WriteLine("\n\nMultiplicação");
							numberForOperation = Input("Digite o segundo termo: ", validationMain);
							currentNumber *= numberForOperation;
							break;
						}
					case '/': // Division
						{
							Console.WriteLine("\n\nDivisão");
							InputDivision("Digite o segundo termo. Deve ser diferente de 0: ", validationMain);
							currentNumber /= numberForOperation;
							break;
						}
				}
			}
		}
	}
}