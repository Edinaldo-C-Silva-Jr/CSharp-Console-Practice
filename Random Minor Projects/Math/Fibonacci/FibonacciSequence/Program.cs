/*
 * Date: 25/02/2023
 * Time: 16:30
*/
using System;
using InputValidation;
using System.Threading;

namespace FibonacciSequence
{
	class Program
	{
		public static void Main(string[] args)
		{
			double term1 = 1, term2 = 0, auxiliaryTerm = 0;
			int numberOfTerms;
			
			Console.WriteLine("Digite a quantidade de termos para montar a sequência de Fibonacci. \nQuantidade máxima: 1476.");
			numberOfTerms = (int)ValidateInput.ValidNumericValue(1, 1476);
			
			Console.WriteLine("\nTermo 1: " + term1);
			
			for (int i = 1; i < numberOfTerms; i++)
			{
				double sleepTime = 500 / (2 * numberOfTerms);
				Thread.Sleep((int)sleepTime);
				
				auxiliaryTerm = term1 + term2;
				term2 = term1;
				term1 = auxiliaryTerm;
				
				Console.WriteLine("Termo " + (i + 1) + ": " + term1);
			}
			
			Console.ReadKey();
		}
	}
}