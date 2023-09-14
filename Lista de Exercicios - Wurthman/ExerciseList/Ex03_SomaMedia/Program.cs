/*
 * Date: 26/08/2023
 * Time: 16:05
 */
using System;
using System.Collections.Generic;
using System.Linq;

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
			
			// Doing the same exercise but with the methods available from the Linq library (one of the optional challenges)
			Console.WriteLine("\nUtilizando a biblioteca Linq!");
			Console.WriteLine("A soma dos números é {0}", numberList.Sum());
			Console.WriteLine("E a média deles é {0}", numberList.Average());
			Console.ReadLine();
		}
		
		// Receives and validates the amount of numbers that will be entered in the program
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
		
		// Receives the amount of numbers defined previously, validating each of them and adding to the list
		public static List<double> BuildList(int quantity)
		{
			List<double> numberList = new List<double>();
			for (int i = 0; i < quantity; i++)
			{
				Console.Write("Digite o {0}º número: ", i+1);
				int cursorX = Console.CursorLeft;
				
				double value;
				while(!(double.TryParse(Console.ReadLine(), out value)))
				{
					Console.SetCursorPosition(cursorX, i);
					Console.Write(new String(' ', 254));
					Console.SetCursorPosition(cursorX, i);
				}
				
				numberList.Add(value);
			}
			
			return numberList;
		}
		
		// A manual implementation of the Sum method
		public static double CalculateSum(List<double> numberList)
		{
			double sum = 0;
			
			foreach(double num in numberList)
			{
				sum += num;
			}
			
			return sum;
		}
		
		// A manual implementation of the Average method, using the result from the sum
		public static double CalculateAverage(double sum, int quantity)
		{
			return sum / quantity;
		}
	}
}