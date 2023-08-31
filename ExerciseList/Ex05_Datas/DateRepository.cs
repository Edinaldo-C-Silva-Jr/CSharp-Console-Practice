/*
 * Date: 30/08/2023
 * Time: 20:55
*/
using System;

namespace Ex05_Datas
{
	public class DateRepository
	{
		public DateRepository()
		{
		}
		
		public DateTime SetDate(int dateChosen)
		{
			switch(dateChosen)
			{
				case 1:
					{
						return new DateTime(1946, 08, 15);
					}
				case 2:
					{
						return new DateTime(1969, 04, 17);
					}
				case 3:
					{
						return new DateTime(1912, 06, 23);
					}
				default:
					{
						return new DateTime();
					}
			}
		}
		
		public string SetDescription(int dateChosen)
		{
			switch(dateChosen)
			{
				case 1:
					{
						return "No dia 15 de agosto de 1946 os norte-americanos John Eckert e John Mauchly apresentaram o ENIAC, o primeiro equipamento eletrônico chamado de computador no mundo.";
					}
				case 2:
					{
						return "Em 17 de abril de 1969 foi feita a publicação da RFC1, por esse motivo considera-se esse o dia da internet até hoje.";
					}
				case 3:
					{
						return "Nascimento de Alan Turing, matemático e criptoanalista britânico que é considerado o 'pai da informática' por ter sido essencial na criação de máquinas que, mais tarde, dariam origem aos PCs que utilizamos hoje para trabalhar, estudar e realizar nossas atividades diárias. Sua genialidade e influência fundamental na história da humanidade, entretanto, foram ceifadas pelo preconceito de uma época que, felizmente, já ficou para trás.";
					}
				default:
					{
						return "Data padrão.";
					}
			}
		}
	}
}
