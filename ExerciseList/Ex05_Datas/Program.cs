/*
 * Date: 29/08/2023
 * Time: 21:17
 */
using System;
using System.Globalization;

namespace Ex05_Datas
{
	class Program
	{
		public static void Main(string[] args)
		{
			DateRepository dateRepo = new DateRepository();
			DateConfiguration dateConfig = new DateConfiguration();
			
			int formatChosen = 0, dateChosen = 0, cultureChosen = 0;
			DateTime dateToShow;
			CultureInfo cultureToFormat;
			
			while(true)
			{
				formatChosen = dateConfig.ChooseDateFormat(new CultureInfo("pt-BR"));
				if (formatChosen == 0)
				{
					break;
				}
				
				dateChosen = dateConfig.ChooseDate();
				if (dateChosen == 0)
				{
					break;
				}
				
				cultureChosen = dateConfig.ChooseCulture();
				if (cultureChosen == 0)
				{
					break;
				}
				
				dateToShow = dateRepo.ReturnDate(dateChosen);
				cultureToFormat = dateRepo.ReturnCulture(cultureChosen);
				
				Console.Clear();
				Console.WriteLine("{0}\n", dateConfig.FormatDate(formatChosen, dateToShow, cultureToFormat));
				Console.WriteLine(dateRepo.ReturnDescription(dateChosen));
				
				Console.ReadLine();
			}
		}
	}
}