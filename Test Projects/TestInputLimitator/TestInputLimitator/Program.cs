/*
 * Date: 13/04/2023
 * Time: 19:31
*/
using System;
using InputLimitator;

namespace TestInputLimitator
{
	class Program
	{
		public static void Main(string[] args)
		{
			double number;
			
			LimitInput limitator = new LimitInput();
			
			Console.WriteLine("Digite number número: ");
			number = limitator.LimitInputNumberOnly(10, 30);
			Console.WriteLine("\n" + number);
			Console.ReadKey();
		}
	}
}