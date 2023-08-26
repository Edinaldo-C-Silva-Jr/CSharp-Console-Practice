/*
 * Date: 26/08/2023
 * Time: 14:41
 */
using System;

namespace Ex02_Calculadora
{
	/// <summary>
	/// Description of Calculator.
	/// </summary>
	public class Calculator
	{
		double n1, n2;
		
		public Calculator()
		{
			
		}
		
		public void ReceiveInput()
		{
			Console.Clear();
			Console.Write("Digite o primeiro número: ");
			n1 = double.Parse(Console.ReadLine());
			Console.Write("Digite o segundo número: ");
			n2 = double.Parse(Console.ReadLine());
		}
		
		public void ReceiveInputDivision()
		{
			Console.Clear();
			Console.Write("Digite o primeiro número: ");
			n1 = double.Parse(Console.ReadLine());
			
			do
			{
				Console.Write("Digite o segundo número: ");
				n2 = double.Parse(Console.ReadLine());
				if (n2 == 0)
				{
					Console.SetCursorPosition(0, 6);
					Console.WriteLine("Não é possível dividir por 0.");
					Console.SetCursorPosition(0, 1);
					Console.Write(new String(' ', 50));
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
