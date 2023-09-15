/*
 * Date: 03/09/2023
 * Time: 15:52
*/
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Ex06_ConversaoMoedas
{
	// Class that keeps all currency information and handles the conversion
	public class CurrencyConversion
	{
		// Contains currency values related to real. These values were given by the exercise's description
		// The exercise uses Brazilian Real as a base for all conversions
		private Dictionary<Currency, decimal> currencyValues = new Dictionary<Currency, decimal>
		{
			{Currency.Real, 1m},
			{Currency.Dolar, 4.5m},
			{Currency.Euro, 6.2m},
			{Currency.Yene, 0.052m},
			{Currency.Pound, 6.95m}
		};
		
		// Contains currency names to be shown on screen (as opposed to the enum that is used only inside the code)
		private Dictionary<Currency, string> currencyNames = new Dictionary<Currency, string>
		{
			{Currency.Real, "Real"},
			{Currency.Dolar, "Dólar Americano"},
			{Currency.Euro, "Euro"},
			{Currency.Yene, "Iene"},
			{Currency.Pound, "Libra Esterlina"}
		};
		
		// Contains the languages for each currency type. These were given by the exercise's description
		private List<CultureInfo> listCultures = new List<CultureInfo>
		{
			new CultureInfo("pt-BR"), 
			new CultureInfo("en-US"), 
			new CultureInfo("de-DE"), 
			new CultureInfo("ja-JP"), 
			new CultureInfo("en-GB")
		};
		
		// Receives the value and two currencies. The conversion formula uses the Brazilian Real as a base.
		public decimal ConvertToNewCurrency(Currency originalCurrency, Currency newCurrency, decimal valueToConvert)
		{
			return valueToConvert * currencyValues[originalCurrency] / currencyValues[newCurrency];
		}
		
		public string GetCurrencyName(Currency currency)
		{
			return currencyNames[currency];
		}
		
		public CultureInfo GetCulture(Currency currencyOfCulture)
		{
			return listCultures[(int)currencyOfCulture - 1];
		}
		
		// Gets the currency symbol from the culture of that currency
		public string GetCurrencySymbol(Currency currencyOfCulture)
		{
			return listCultures[(int)currencyOfCulture - 1].NumberFormat.CurrencySymbol;
		}
	}
}
