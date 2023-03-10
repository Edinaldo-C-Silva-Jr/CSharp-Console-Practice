/*
 * Date: 10/03/2023
 * Time: 19:09
 */
using System;
using InputValidation;

namespace CalculatorV2
{
	class Program
	{
		private static double[] numbers;
		private static double result;
		private static int quantity;
		private static char operationChosen = ' ', continueYesNo = 's';
		
		private static void Input(int i)
		{
			Console.WriteLine("\nDigite o " + (i+1) + "º numero: ");
			numbers[i] = ValidateInput.ValidDouble();
		}
		
		private static void InputDivision(int i)
		{
			Console.WriteLine("\nDigite o " + (i+1) + "º numero. Deve ser diferente de 0: ");
			numbers[i] = ValidateInput.ValidDoubleNotZero();
		}
		
		private static void InputInitial (string operation, string action)
		{
			Console.Clear();
			Console.WriteLine("Operação Escolhida: " + operation);
			Console.WriteLine("Digite o valor inicial, os restantes serão " + action + " dele.");
			result = numbers[0] = ValidateInput.ValidDouble();
		}
		
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
			while(continueYesNo == 's')
			{
				Console.Clear();
				ValidateInput.SetValidValues(new string[] {"a", "s", "m", "d"});
				Console.WriteLine("Digite a operação desejada.\nA = Adição, \nS = Subtração, \nM = Multipliacação, \nD = Divisão."); Console.WriteLine("Operação: ");
				operationChosen = char.Parse(ValidateInput.ValidInput());
					
				Console.Clear();
				Console.WriteLine("Digite a quantidade de entradas de dados. Ao menos 2 entradas são necessárias. \nEntradas: ");
				quantity = (int)ValidateInput.ValidNumericValue(2, 10);
				
				numbers = new double[quantity];
				
				switch(operationChosen)
				{
					case 'a':
						{
							result = 0;
							for (int i = 0; i < quantity; i++)
							{
								ShowInputs("Adição", i);
								Input(i);
								result = result + numbers[i];
							}
							ShowInputs("Adição", quantity);
							Console.WriteLine("\nO valor da adição é: " + result);
							break;
						}
					case 's':
						{
							InputInitial("Subtração", "subtraídos");
							
							for (int i = 1; i < quantity; i++)
							{
								ShowInputs("Subtração", i);
								Input(i);
								result = result - numbers[i];
							}
							ShowInputs("Subtração", quantity);
							Console.WriteLine("\nO valor da subtração é: " + result);
							break;
						}
					case 'm':
						{
							result = 1;
							for (int i = 0; i < quantity; i++)
							{
								ShowInputs("Multiplicação", i);
								Input(i);
								result = result * numbers[i];
							}
							ShowInputs("Multiplicação", quantity);
							Console.WriteLine("\nO valor da multiplicação é: " + result);
							break;
						}
					case 'd':
						{
							InputInitial("Divisão", "divididos");
							
							for (int i = 1; i < quantity; i++)
							{
								ShowInputs("Divisão", i);
								InputDivision(i);
								result = result / numbers[i];
							}
							ShowInputs("Divisão", quantity);
							Console.WriteLine("\nO valor da divisão é: " + result);
							break;
						}
				}
				
				Console.WriteLine("\nDeseja realizar outra operação? s/n");
				continueYesNo = char.Parse(Console.ReadLine());
			}
		}
	}
}