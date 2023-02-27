/*
 * Date: 21/02/2023
 * Time: 22:46
*/
using System;
using InputValidation;

namespace NumberIsFibonacciTerm
{
	public class Program
	{
		// Receives a number and tells if it's a part of the Fibonacci Sequence. If yes, also tells what term of the sequence it is
		public static void Main(string[] args)
		{
			double numberToTest, term1 = 1, term2 = 1, auxiliaryTerm;
			int termCounter = 2;
			
			Console.WriteLine("Digite um número positivo para ver se é um termo de Fibonacci: ");
			numberToTest = ValidateInput.ValidNumberSign(true); // Only accept input if it is a positive number
			
			while (numberToTest > term1) // Check to know when to stop building the Fibonacci sequence
			{
				auxiliaryTerm = term1; // Building Fibonacci sequence. Term 1 is the higher term, and Term 2 is the lower
				term1 = term1 + term2;
				term2 = auxiliaryTerm;
				termCounter++; // Counts the number of terms as the sequence is built. Used to show the number's position in the sequence
			}
			
			if (term1 == numberToTest || term2 == numberToTest)
			{
				Console.WriteLine("\nO número " + numberToTest + " faz parte da sequência de Fibonacci!");
				Console.WriteLine("Ele é o termo número " + termCounter + " da sequência."); 
			}
			else
			{
				Console.WriteLine("\nO número " + numberToTest + " não é um termo da sequência de Fibonacci...");				
			}
			Console.ReadKey();
		}
	}
}