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
			decimal valueInReal = 0, convertedValue = 0;
			int currencyID;
			
			Console.WriteLine("Digite o valor que deseja converter, em reais (R$): ");
			decimal.TryParse(Console.ReadLine(), out valueInReal);
			
			Console.Clear();
			Console.WriteLine("Valor em Reais para conversão: {0}", valueInReal);
			Console.WriteLine("Para qual moeda você deseja converter o valor? ");
			Console.WriteLine("1 - Dólar($)");
			Console.WriteLine("2 - Euro (€)");
			Console.WriteLine("3 - Iene (¥)");
			Console.WriteLine("4 - Libra esterlina (£)");
			Console.Write("Opção: ");
			
			while(!(int.TryParse(Console.ReadLine(), out currencyID)) || (currencyID < 1 || currencyID > 4))
			{
				Console.SetCursorPosition(7, 6);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(7, 6);
			}
			
			switch((Currency)currencyID)
			{
				case Currency.Dolar:
					{
						convertedValue = valueInReal / 4.5M;
						break;
					}
				case Currency.Euro:
					{
						convertedValue = valueInReal / 6.2M;
						break;
					}
				case Currency.Yene:
					{
						convertedValue = valueInReal / 0.052M;
						break;
					}
				case Currency.Pound:
					{
						convertedValue = valueInReal / 6.95M;
						break;
					}
				default:
					{
						break;
					}
			}
			
			Console.WriteLine(convertedValue.ToString());
			Console.ReadLine();
		}
	}
}