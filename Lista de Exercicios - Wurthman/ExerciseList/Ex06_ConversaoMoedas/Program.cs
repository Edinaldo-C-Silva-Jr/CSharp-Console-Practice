/*
 * Date: 31/08/2023
 * Time: 21:04
*/
using System;

namespace Ex06_ConversaoMoedas
{
	class Program
	{
		public static void Main(string[] args)
		{
			decimal valorReal = 0, valorConvertido = 0;
			byte moeda;
			
			Console.WriteLine("Digite o valor que deseja converter, em reais (R$): ");
			decimal.TryParse(Console.ReadLine(), out valorReal);
			
			Console.WriteLine("Para qual moeda você deseja converter o valor? ");
			Console.WriteLine("1 - Dólar($)");
			Console.WriteLine("2 - Euro (€)");
			Console.WriteLine("3 - Iene (¥)");
			Console.WriteLine("4 - Libra esterlina (£)");
			byte.TryParse(Console.ReadLine(), out moeda);
			
			switch(moeda)
			{
				case 1:
					{
						valorConvertido = valorReal / 4.5M;
						break;
					}
				case 2:
					{
						valorConvertido = valorReal / 6.2M;
						break;
					}
				case 3:
					{
						valorConvertido = valorReal / 0.052M;
						break;
					}
				case 4:
					{
						valorConvertido = valorReal / 6.95M;
						break;
					}
				default:
					{
						break;
					}
			}
			
			Console.WriteLine(valorConvertido.ToString());
			Console.ReadLine();
		}
	}
}