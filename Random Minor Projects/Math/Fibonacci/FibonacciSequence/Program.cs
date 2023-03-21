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
		// Builds the Fibonacci Sequence up to a desired amount of terms
		public static void Main(string[] args)
		{
			double term1 = 1, term2 = 0, auxiliaryTerm = 0;
			int numberOfTerms;
			
			ValidateInput validation = new ValidateInput();
			
			Console.WriteLine("Digite a quantidade de termos para montar a sequência de Fibonacci. \nQuantidade máxima: 1476.");
			numberOfTerms = (int)validation.ValidateNumericValue(1, 1476); // Guarantees the inputted number is valid. (Less than 1 would lead to no terms being built in the sequence, meanwhile more than 1476 would overflow the size of a double variable and return infinity as a result)
			
			if (numberOfTerms > 295) // Checks if the amount of terms will lead to the sequence exceeding the console buffer height
			{
				Console.SetBufferSize(Console.BufferWidth, (numberOfTerms + 5)); // Sets the console buffer height to a higher value, to handle showing the entire sequence
			}
			
			Console.WriteLine("\nTermo 1: " + term1); // Shows term 1 before doing any of the calculations
			
			for (int i = 1; i < numberOfTerms; i++)
			{
				Thread.Sleep(500 / (numberOfTerms * 2)); // Calculates the wait time between showing each ter. The more terms there are, the faster it shows them (maximum speed is reached by 251 terms)
				
				auxiliaryTerm = term1 + term2; // Builds the Fibonacci Sequence. Term 1 is the bigger term, Term 2 is the smaller one
				term2 = term1;
				term1 = auxiliaryTerm;
				
				Console.WriteLine("Termo " + (i + 1) + ": " + term1);
			}
			
			Console.ReadKey();
		}
	}
}