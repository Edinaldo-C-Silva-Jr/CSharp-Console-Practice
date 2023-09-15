/*
 * Date: 30/08/2023
 * Time: 20:55
 */
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ex05_Datas
{
	// A class to keep all the information of the default dates used by the exercise
	public class DateRepository
	{
		// Constains all three dates used by the exercise, which were provided in the exercise description
		// The exercise only provided dates, but wants time to be shown as well, which is why the time is set for 00:00:00 on every date
		List<DateTime> listDate = new List<DateTime>
		{
			new DateTime(1946, 08, 15, 0, 0, 0), // ENIAC
			new DateTime(1969, 04, 17, 0, 0, 0), // RFC1
			new DateTime(1912, 06, 23, 0, 0, 0) // Alan Turing
		};
		
		// Constains the description of all three dates used. Provided by the exercise description
		List<string> listDescriptions = new List<string>
		{
			"No dia 15 de agosto de 1946 os norte-americanos John Eckert e John Mauchly apresentaram o ENIAC, o primeiro equipamento eletrônico chamado de computador no mundo.",
			"Em 17 de abril de 1969 foi feita a publicação da RFC1, por esse motivo considera-se esse o dia da internet até hoje.",
			"Nascimento de Alan Turing, matemático e criptoanalista britânico que é considerado o 'pai da informática' por ter sido essencial na criação de máquinas que, mais tarde, dariam origem aos PCs que utilizamos hoje para trabalhar, estudar e realizar nossas atividades diárias. Sua genialidade e influência fundamental na história da humanidade, entretanto, foram ceifadas pelo preconceito de uma época que, felizmente, já ficou para trás."
		};
		
		// Contains all languages in which the dates will be shown. The exercise left this as a free choice, so the languages were picked by myself
		List<CultureInfo> listCultures = new List<CultureInfo>
		{
			new CultureInfo("pt-BR"), 
			new CultureInfo("en-US"), 
			new CultureInfo("es-ES"), 
			new CultureInfo("fr-FR"), 
			new CultureInfo("it-IT"), 
			new CultureInfo("de-DE")
		};
		
		// Methods to access the data in the repository
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
