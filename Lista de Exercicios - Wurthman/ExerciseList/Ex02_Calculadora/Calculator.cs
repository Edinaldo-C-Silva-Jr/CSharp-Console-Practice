/*
 * Date: 26/08/2023
 * Time: 14:41
 */
using System;

namespace Ex02_Calculadora
{
	// A class that implements the methods for a simple calculator, doing basic math operations with two values
	public class Calculator
	{
		double n1, n2;
		
		// Makes sure the inputted values are numbers, to avoid parsing errors
		public double ValidateNumber()
		{
			int cursorX = Console.CursorLeft, cursorY = Console.CursorTop;
			double number;
			
			while(!double.TryParse(Console.ReadLine(), out number))
			{
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(cursorX, cursorY);
			}
			
			return number;
		}
		
		// Receives the two numbers for the operations
		public void ReceiveInput()
		{
			Console.Clear();
			Console.Write("Digite o primeiro número: ");
			n1 = ValidateNumber();
			Console.Write("Digite o segundo número: ");
			n2 = ValidateNumber();
		}
		
		// Receives the two numbers for a division based operation. The second number has to be different than zero
		public void ReceiveInputDivision()
		{
			Console.Clear();
			Console.Write("Digite o primeiro número: ");
			n1 = ValidateNumber();
			
			do
			{
				Console.Write("Digite o segundo número: ");
				n2 = ValidateNumber();
				if (n2 == 0)
				{
					Console.SetCursorPosition(0, 8); // Writes an error warning
					Console.WriteLine("Não é possível dividir por 0.");
					Console.SetCursorPosition(0, 1); // Clears input and asks for it again
					Console.Write(new String(' ', 300));
					Console.SetCursorPosition(0, 1);
				}
			}
			while(n2 == 0);
		}
		
		
		public double Addition ()
		{
			ReceiveInput();
			return n1 + n2;
		}
		
		public double Subtraction ()
		{
			ReceiveInput();
			return n1 - n2;
		}
		
		public double Multiplication()
		{
			ReceiveInput();
			return n1 * n2;
		}
		
		public double Division()
		{
			ReceiveInputDivision();
			return n1 / n2;
		}
		
		public double RestDivision()
		{
			ReceiveInputDivision();
			return n1 % n2;
		}
		
		public double Exponential()
		{
			ReceiveInput();
			return Math.Pow(n1, n2);
		}
	}
}
