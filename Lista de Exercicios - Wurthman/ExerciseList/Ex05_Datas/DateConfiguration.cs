/*
 * Date: 30/08/2023
 * Time: 20:55
*/
using System;
using System.Globalization;

namespace Ex05_Datas
{
	// A class that handles all the configurations related to the program
	public class DateConfiguration
	{
		// Returns the date chosen, in the format chosen, with the language chosen
		public string FormatDate(int formatChosen, DateTime dateToShow, CultureInfo cultureToFormat)
		{
			switch(formatChosen)
			{
				default:
					{
						return dateToShow.ToString(cultureToFormat);
					}
				case 2:
					{
						return dateToShow.ToString("dd/MM/yyyy", cultureToFormat);
					}
				case 3:
					{
						return dateToShow.ToString("dddd, dd MMMM yyyy", cultureToFormat);
					}
				case 4:
					{
						return dateToShow.ToString("R", cultureToFormat);
					}
				case 5:
					{
						return dateToShow.ToString("dd/MM/yyyy HH:mm:ss", cultureToFormat);
					}
				case 6:
					{
						return dateToShow.ToString("dd/MM/yyyy hh:mm:ss tt", cultureToFormat);
					}
				case 7:
					{
						return dateToShow.ToString("dddd dd/MM/yyyy", cultureToFormat);
					}
			}
		}
		
		// Handles the choice of the date format, showing examples and receiving the index of the format as an input, which is validated
		public int ChooseDateFormat(CultureInfo cultureDefault)
		{
			int format;
			
			Console.Clear();
			
			Console.WriteLine("Escolha um formato para visualizar a data: ");
			
			Console.SetCursorPosition(0, 4); // Shows an example of each format, using today's date
			Console.WriteLine("1 - Utilizar a configuração do sistema: {0}", FormatDate(1, DateTime.Now, cultureDefault)); // The first five formats were given by the exercise description
			Console.WriteLine("2 - Formato simples: {0}", FormatDate(2, DateTime.Now, cultureDefault));
			Console.WriteLine("3 - Formato longo: {0}", FormatDate(3, DateTime.Now, cultureDefault));
			Console.WriteLine("4 - Formato RFC1123: {0}", FormatDate(4, DateTime.Now, cultureDefault));
			Console.WriteLine("5 - Data e hora: {0}", FormatDate(5, DateTime.Now, cultureDefault));
			Console.WriteLine("6 - Data e hora formato 12 horas: {0}", FormatDate(6, DateTime.Now, cultureDefault)); // Formats 6 and 7 were picked by myself as part of the optional challenge
			Console.WriteLine("7 - Data com dia da semana: {0}", FormatDate(7, DateTime.Now, cultureDefault));
			Console.WriteLine("\n0 - Sair");
			
			Console.SetCursorPosition(43, 0);
			while (!(int.TryParse(Console.ReadLine(), out format)) || (format < 0 || format > 7)) {
				Console.SetCursorPosition(43, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(43, 0);
			}
			
			return format;
		}
		
		// Handles the choice of the date, showing the options and receiving the index as an input, that is validated
		public int ChooseDate()
		{
			int date;
			
			Console.Clear();
			Console.WriteLine("Escolha a data a ser visualizada: ");
			
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("1 - ENIAC");
			Console.WriteLine("2 - RFC1");
			Console.WriteLine("3 - Alan Turing");
			Console.WriteLine("\n0 - Sair");
			
			Console.SetCursorPosition(34, 0);
			while (!(int.TryParse(Console.ReadLine(), out date)) || (date < 0 || date > 3))
			{
				Console.SetCursorPosition(34, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(34, 0);
			}
			
			return date;
		}
		
		// Handles the choice of the language, also receiving and validating an index
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
			Console.WriteLine("\n0 - Sair");
			
			Console.SetCursorPosition(47, 0);
			while (!(int.TryParse(Console.ReadLine(), out culture)) || (culture < 0 || culture > 6))
			{
				Console.SetCursorPosition(47, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(47, 0);
			}
			
			return culture;
		}
	}
}
