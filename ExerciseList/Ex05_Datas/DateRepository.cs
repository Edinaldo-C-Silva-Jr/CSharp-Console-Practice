/*
 * Date: 30/08/2023
 * Time: 20:55
 */
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ex05_Datas
{
	public class DateRepository
	{
		List<DateTime> listDate = new List<DateTime>
		{
			new DateTime(1946, 08, 15, 0, 0, 0),
			new DateTime(1969, 04, 17, 0, 0, 0),
			new DateTime(1912, 06, 23, 0, 0, 0)
		};
		
		List<string> listDescriptions = new List<string>
		{
			"No dia 15 de agosto de 1946 os norte-americanos John Eckert e John Mauchly apresentaram o ENIAC, o primeiro equipamento eletrônico chamado de computador no mundo.",
			"Em 17 de abril de 1969 foi feita a publicação da RFC1, por esse motivo considera-se esse o dia da internet até hoje.",
			"Nascimento de Alan Turing, matemático e criptoanalista britânico que é considerado o 'pai da informática' por ter sido essencial na criação de máquinas que, mais tarde, dariam origem aos PCs que utilizamos hoje para trabalhar, estudar e realizar nossas atividades diárias. Sua genialidade e influência fundamental na história da humanidade, entretanto, foram ceifadas pelo preconceito de uma época que, felizmente, já ficou para trás."
		};
		
		List<CultureInfo> listCultures = new List<CultureInfo>
		{
			new CultureInfo("pt-BR"), 
			new CultureInfo("en-US"), 
			new CultureInfo("es-ES"), 
			new CultureInfo("fr-FR"), 
			new CultureInfo("it-IT"), 
			new CultureInfo("de-DE")
		};
		
		public DateRepository()
		{
		}
		
		public DateTime ReturnDate(int dateChosen)
		{
			return listDate[dateChosen - 1];
		}
		
		public string ReturnDescription(int dateChosen)
		{
			return listDescriptions[dateChosen - 1];
		}
		
		public CultureInfo ReturnCulture(int cultureChosen)
		{
			return listCultures[cultureChosen - 1];
		}
	}
}
