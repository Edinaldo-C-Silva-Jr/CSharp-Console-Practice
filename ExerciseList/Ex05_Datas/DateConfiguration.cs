﻿/*
 * Date: 30/08/2023
 * Time: 20:55
*/
using System;
using System.Globalization;

namespace Ex05_Datas
{
	/// <summary>
	/// Description of DateConfiguration.
	/// </summary>
	public class DateConfiguration
	{
		public DateConfiguration()
		{
		}
		
		public string FormatDate(int formatChosen, DateTime dateToShow, int cultureChosen)
		{
			DateRepository dateRepo = new DateRepository();
			CultureInfo culture = dateRepo.ReturnCulture(cultureChosen);
			
			switch(formatChosen)
			{
				default:
					{
						return dateToShow.ToString(culture);
					}
				case 2:
					{
						return dateToShow.ToString("dd/MM/yyyy", culture);
					}
				case 3:
					{
						return dateToShow.ToString("dddd, dd MMMM yyyy", culture);
					}
				case 4:
					{
						return dateToShow.ToString("R", culture);
					}
				case 5:
					{
						return dateToShow.ToString("dd/MM/yyyy HH:mm:ss", culture);
					}
				case 6:
					{
						return dateToShow.ToString("dd/MM/yyyy hh:mm:ss tt", culture);
					}
				case 7:
					{
						return dateToShow.ToString("dddd dd/MM/yyyy", culture);
					}
			}
		}
		
		public int ChooseDateFormat()
		{
			int format;
			int culture = 1;
			
			Console.Clear();
			
			Console.WriteLine("Escolha um formato para visualizar a data: ");
			
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("1 - Utilizar a configuração do sistema: {0}", FormatDate(1, DateTime.Now, culture));
			Console.WriteLine("2 - Formato simples: {0}", FormatDate(2, DateTime.Now, culture));
			Console.WriteLine("3 - Formato longo: {0}", FormatDate(3, DateTime.Now, culture));
			Console.WriteLine("4 - Formato RFC1123: {0}", FormatDate(4, DateTime.Now, culture));
			Console.WriteLine("5 - Data e hora: {0}", FormatDate(5, DateTime.Now, culture));
			Console.WriteLine("6 - Data e hora formato 12 horas: {0}", FormatDate(6, DateTime.Now, culture));
			Console.WriteLine("7 - Data com dia da semana: {0}", FormatDate(7, DateTime.Now, culture));
			
			Console.SetCursorPosition(43, 0);
			while (!(int.TryParse(Console.ReadLine(), out format)) || (format < 1 || format > 7)) {
				Console.SetCursorPosition(43, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(43, 0);
			}
			
			return format;
		}
		
		public int ChooseDate()
		{
			int date;
			
			Console.Clear();
			Console.WriteLine("Escolha a data a ser visualizada: ");
			
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("1 - ENIAC");
			Console.WriteLine("2 - RFC1");
			Console.WriteLine("3 - Alan Turing");
			
			Console.SetCursorPosition(34, 0);
			while (!(int.TryParse(Console.ReadLine(), out date)) || (date < 1 || date > 3))
			{
				Console.SetCursorPosition(34, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(34, 0);
			}
			
			return date;
		}
		
		public int ChooseCulture()
		{
			int culture;
			
			Console.Clear();
			Console.WriteLine("Escolha o idioma em que a data será formatada: ");
			
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("1 - Português (Brasil)");
			Console.WriteLine("2 - Inglês (Estados Unidos)");
			Console.WriteLine("3 - Espanhol (Espanha)");
			Console.WriteLine("4 - Francês (França)");
			Console.WriteLine("5 - Italiano (Itália)");
			Console.WriteLine("6 - Alemão (Alemanha)");
			
			Console.SetCursorPosition(47, 0);
			while (!(int.TryParse(Console.ReadLine(), out culture)) || (culture < 1 || culture > 6))
			{
				Console.SetCursorPosition(47, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(47, 0);
			}
			
			return culture;
		}
	}
}