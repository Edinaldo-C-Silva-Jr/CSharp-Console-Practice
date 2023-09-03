/*
 * Date: 31/08/2023
 * Time: 21:04
 */
using System;

namespace Ex06_ConversaoMoedas
{
	class Program
	{
		public static void Main(string[] args)
		{
			CurrencyConversion converter = new CurrencyConversion();
			decimal valueInReal = 0, convertedValue = 0;
			Currency chosenCurrency;
			
			Console.WriteLine("Digite o valor que deseja converter, em reais (R$): ");
			decimal.TryParse(Console.ReadLine(), out valueInReal);
			
			Console.Clear();
			Console.WriteLine("Valor em Reais para conversão: {0}", valueInReal);
			Console.WriteLine("Para qual moeda você deseja converter o valor? ");
			Console.WriteLine("1 - Dólar ($)");
			Console.WriteLine("2 - Euro (€)");
			Console.WriteLine("3 - Iene (¥)");
			Console.WriteLine("4 - Libra esterlina (£)");
			Console.Write("Opção: ");
			
			while(!(Currency.TryParse(Console.ReadLine(), out chosenCurrency)) || !(Enum.IsDefined(typeof(Currency), chosenCurrency)))
			{
				Console.SetCursorPosition(7, 6);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(7, 6);
			}
			
			convertedValue = converter.ConvertFromReal(chosenCurrency, valueInReal);
			
			Console.WriteLine(convertedValue.ToString("C", converter.GetCulture(chosenCurrency)));
			Console.ReadLine();
		}
	}
}