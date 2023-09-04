/*
 * Date: 31/08/2023
 * Time: 21:04
 */
using System;

namespace Ex06_ConversaoMoedas
{
	class Program
	{
		private static CurrencyConversion converter = new CurrencyConversion();
		
		public static void Main(string[] args)
		{
			decimal originalValue = 0, convertedValue = 0;
			Currency originalCurrency, convertCurrency;
			
			originalCurrency = GetOriginalCurrency();
			originalValue = GetOriginalValue(originalCurrency);
			convertCurrency = GetCurrencyToConvert(originalCurrency, originalValue);
			
			convertedValue = converter.ConvertToNewCurrency(originalCurrency, convertCurrency, originalValue);
			
			Console.WriteLine(convertedValue.ToString("C", converter.GetCulture(convertCurrency)));
			Console.ReadLine();
		}
		
		public static Currency GetOriginalCurrency()
		{
			Currency originalCurrency;
			
			Console.Clear();
			Console.WriteLine("De qual moeda você deseja converter?");
			for (int i = 1; i < 6; i++)
			{
				Currency display = (Currency)i;
				Console.WriteLine("{0} - {1} ({2})", i, converter.GetCurrencyName(display), converter.GetCurrencySymbol(display));
			}
			Console.Write("Opção: ");
			
			while(!(Currency.TryParse(Console.ReadLine(), out originalCurrency)) || !(Enum.IsDefined(typeof(Currency), originalCurrency)))
			{
				Console.SetCursorPosition(7, 6);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(7, 6);
			}
			
			return originalCurrency;
		}
		
		public static decimal GetOriginalValue(Currency originalCurrency)
		{
			decimal originalValue;
			
			Console.Clear();
			Console.WriteLine("Digite o valor que deseja converter, em {0} ({1}): ", converter.GetCurrencyName(originalCurrency), converter.GetCurrencySymbol(originalCurrency));
			while(!(decimal.TryParse(Console.ReadLine(), out originalValue)))
			{
				Console.SetCursorPosition(0, 1);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(0, 1);
			}
			
			return originalValue;
		}
		
		public static Currency GetCurrencyToConvert(Currency originalCurrency, decimal originalValue)
		{
			Currency convertCurrency;
			
			Console.Clear();
			Console.WriteLine("Valor em {0} para conversão: {1}", converter.GetCurrencyName(originalCurrency), originalValue.ToString("C", converter.GetCulture(originalCurrency)));
			Console.WriteLine("Para qual moeda você deseja converter o valor? ");
			for (int i = 1; i < 6; i++)
			{
				Currency display = (Currency)i;
				Console.WriteLine("{0} - {1} ({2})", i, converter.GetCurrencyName(display), converter.GetCurrencySymbol(display));
			}
			Console.Write("Opção: ");
			
			while(!(Currency.TryParse(Console.ReadLine(), out convertCurrency)) || !(Enum.IsDefined(typeof(Currency), convertCurrency)))
			{
				Console.SetCursorPosition(7, 7);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(7, 7);
			}
			
			return convertCurrency;
		}
	}
}