/*
 * Date: 29/08/2023
 * Time: 21:17
 */
using System;

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
			
			formatChosen = dateConfig.ChooseDateFormat();
			dateChosen = dateConfig.ChooseDate();
			cultureChosen = dateConfig.ChooseCulture();
			
			dateToShow = dateRepo.ReturnDate(dateChosen);
			
			Console.Clear();
			Console.WriteLine("{0}\n", dateConfig.FormatDate(formatChosen, dateToShow, cultureChosen));
			Console.WriteLine(dateRepo.ReturnDescription(dateChosen));
			
			Console.ReadLine();
		}
	}
}