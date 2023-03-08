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
		
		private static void Input()
		{
			Console.WriteLine("Digite o primeiro numero: ");
			number1 = ValidateInput.ValidDouble();
			
			if (operationChosen == 'd')
			{
				Console.WriteLine("Digite o segundo numero, ele deve ser diferente de 0: ");
				do
				{
					number2 = ValidateInput.ValidDouble();
				}
				while (number2 == 0);
			}
			else
			{
				Console.WriteLine("Digite o segundo numero: ");
				number2 = ValidateInput.ValidDouble();
			}
		}
		
		public static void Main()
		{	
			while(continueYesNo == 's')
			{
				Console.Clear();
				ValidateInput.SetValidValues(new string[] {"a", "s", "m", "d"});
				Console.WriteLine("Digite a operação desejada.\na = Adição, \ns = Subtração, \nm = Multipliacação, \nd = Divisão." );
				Console.WriteLine("Operação: ");
				operationChosen = char.Parse(ValidateInput.ValidInput());
				
				Console.Clear();
				
				switch(operationChosen)
				{
					case 'a':
						{
							Console.WriteLine("Operação Escolhida: Adição. \n");
							Input();
							result = number1 + number2;
							Console.WriteLine("\nO valor da adição é: " + result);
							break;
						}
					case 's':
						{
							Console.WriteLine("Operação Escolhida: Subtração. \n");
							Input();
							result = number1 - number2;
							Console.WriteLine("\nO valor da subtração é: " + result);
							break;
						}
					case 'm':
						{
							Console.WriteLine("Operação Escolhida: Multiplicação. \n");
							Input();
							result = number1 * number2;
							Console.WriteLine("\nO valor da multiplicação é: " + result);
							break;
						}
					case 'd':
						{
							Console.WriteLine("Operação Escolhida: Divisão. \n");
							Input();
							result = number1 / number2;
							Console.WriteLine("\nO valor da divisão é: " + result);
							break;
						}
				}
				
				ValidateInput.SetValidValues(new string[] {"s", "n"});
				Console.WriteLine("\nDeseja realizar outra operação? s/n");
				continueYesNo = char.Parse(ValidateInput.ValidInput());
			}
		}
	}
}