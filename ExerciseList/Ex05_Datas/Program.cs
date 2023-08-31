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
			
			int formatChosen = 0, dateChosen = 0;
			DateTime dateToShow;
			
			formatChosen = GetDateFormat();
			dateChosen = GetDate();
			
			dateToShow = dateRepo.SetDate(dateChosen);
			
			Console.Clear();
			Console.WriteLine("{0}\n", dateConfig.FormatDate(formatChosen, dateToShow));
			Console.WriteLine(dateRepo.SetDescription(dateChosen));
			
			Console.ReadLine();
		}

		public static int GetDateFormat()
		{
			int format;
			
			Console.Clear();
			
			Console.WriteLine("Escolha um formato para visualizar a data: ");
			
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("1 - Utilizar a configuração do sistema");
			Console.WriteLine("2 - Formato simples: 01-01-23");
			Console.WriteLine("3 - Formato longo: Domingo, 01 de dezembro de 2023");
			Console.WriteLine("4 - Formato longo personalizado: 01-01-2023 12:34:56");
			Console.WriteLine("5 - Formato RFC1123: Dom, 01 Jan 2023 12:34:56 GMT");
			
			Console.SetCursorPosition(43, 0);
			while (!(int.TryParse(Console.ReadLine(), out format)) || (format < 1 || format > 5)) {
				Console.SetCursorPosition(43, 0);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(43, 0);
			}
			
			return format;
		}
		
		public static int GetDate()
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
	}
}