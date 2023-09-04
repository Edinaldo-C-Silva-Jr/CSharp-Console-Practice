/*
 * Date: 03/09/2023
 * Time: 15:52
*/
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Ex06_ConversaoMoedas
{
	public class CurrencyConversion
	{
		private Dictionary<Currency, decimal> currencyValues = new Dictionary<Currency, decimal>
		{
			{Currency.Real, 1m},
			{Currency.Dolar, 4.5m},
			{Currency.Euro, 6.2m},
			{Currency.Yene, 0.052m},
			{Currency.Pound, 6.95m}
		};
		
		private Dictionary<Currency, string> currencyNames = new Dictionary<Currency, string>
		{
			{Currency.Real, "Real"},
			{Currency.Dolar, "Dólar Americano"},
			{Currency.Euro, "Euro"},
			{Currency.Yene, "Iene"},
			{Currency.Pound, "Libra Esterlina"}
		};
		
		private List<CultureInfo> listCultures = new List<CultureInfo>
		{
			new CultureInfo("pt-BR"), 
			new CultureInfo("en-US"), 
			new CultureInfo("de-DE"), 
			new CultureInfo("ja-JP"), 
			new CultureInfo("en-GB")
		};
		
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
		
		public string GetCurrencySymbol(Currency currencyOfCulture)
		{
			return listCultures[(int)currencyOfCulture - 1].NumberFormat.CurrencySymbol;
		}
	}
}
