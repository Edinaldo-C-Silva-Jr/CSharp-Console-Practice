/*
 * Date: 26/08/2023
 * Time: 16:05
 */
using System;
using System.Collections.Generic;

namespace Ex03_SomaMedia
{
	class Program
	{
		public static void Main(string[] args)
		{
			int numberQuantity = ReceiveInput();
			
			Console.Clear();
			List<double> numberList = BuildList(numberQuantity);
			
			double numberSum = CalculateSum(numberList);
			double numberAverage = CalculateAverage(numberSum, numberQuantity);
			
			Console.Clear();
			Console.WriteLine("A soma dos números é {0}", numberSum);
			Console.WriteLine("E a média deles é {0}", numberAverage);
			Console.ReadLine();
		}
		
		public static int ReceiveInput()
		{
			Console.Write("Digite a quantidade de números que deseja calcular.\nPode ser de 3 a 10 números: ");
			
			int quantity;
			while(!(int.TryParse(Console.ReadLine(), out quantity)) || (quantity < 3 || quantity > 10))
			{
				Console.SetCursorPosition(28, 1);
				Console.Write(new String(' ', 254));
				Console.SetCursorPosition(28, 1);
			}
			
			return quantity;
		}
		
		public static List<double> BuildList(int quantity)
		{
			List<double> numberList = new List<double>();
			for (int i = 0; i < quantity; i++)
			{
				Console.Write("Digite o {0}º número: ", i+1);
				
				double value;
				while(!(double.TryParse(Console.ReadLine(), out value)))
				{
					Console.SetCursorPosition(20, i);
					Console.Write(new String(' ', 254));
					Console.SetCursorPosition(20, i);
				}
				
				numberList.Add(value);
			}
			
			return numberList;
		}
		
		public static double CalculateSum(List<double> numberList)
		{
			double sum = 0;
			
			foreach(double num in numberList)
			{
				sum += num;
			}
			
			return sum;
		}
		
		public static double CalculateAverage(double sum, int quantity)
		{
			return sum / quantity;
		}
	}
}