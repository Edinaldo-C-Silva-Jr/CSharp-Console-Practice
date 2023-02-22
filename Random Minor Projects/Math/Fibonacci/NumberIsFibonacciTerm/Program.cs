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
		public static void Main(string[] args)
		{
			double numberToTest, term1 = 1, term2 = 1, auxiliaryTerm;
			
			Console.WriteLine("Digite o número para ver se é um termo de Fibonacci: ");
			numberToTest = ValidateInput.ValidDouble();
			
			do
			{
				auxiliaryTerm = term1;
				term1 = term1 + term2;
				term2 = auxiliaryTerm;
			}
			while (numberToTest > term1);
			
			if (term1 == numberToTest || term2 == numberToTest)
			{
				Console.WriteLine("O número " + numberToTest + " faz parte da sequência de Fibonacci.");
			}
			else
			{
				Console.WriteLine("O número " + numberToTest + " não faz parte da sequência de Fibonacci.");				
			}
			Console.ReadKey();
		}
	}
}