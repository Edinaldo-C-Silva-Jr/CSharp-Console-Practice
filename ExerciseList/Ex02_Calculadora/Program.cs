/*
 * Date: 26/08/2023
 * Time: 14:36
 */
using System;
using System.Diagnostics;

namespace Ex02_Calculadora
{
	class Program
	{
		public static void DrawMenu()
		{
			Console.Clear();
			Console.SetCursorPosition(23, 0);
			Console.Write("Menu");
			Console.SetCursorPosition(10, 2);
			Console.Write("1 - Adição");
			Console.SetCursorPosition(10, 3);
			Console.Write("2 - Subtração");
			Console.SetCursorPosition(10, 4);
			Console.Write("3 - Multiplicação");
			Console.SetCursorPosition(10, 5);
			Console.Write("4 - Divisão");
			Console.SetCursorPosition(10, 9);
			Console.Write("0 - Sair");
			
			Console.SetCursorPosition(5, 12);
			Console.Write("Escolha uma opção: ");
		}
		
		public static void Main(string[] args)
		{
			Console.SetWindowSize(50, 15);
			Console.SetBufferSize(50, 15);
			
			Calculator calculate = new Calculator();
			char option;
			
			do
			{
				DrawMenu();
				option = Console.ReadKey(false).KeyChar;
				
				switch(option)
				{
					case '0':
						{
							Console.Clear();
							Console.Write("Saindo do aplicativo...");
							break;
						}
					case '1':
						{
							Console.Write("Resultado: " + calculate.Addition());
							break;
						}
					case '2':
						{
							Console.Write("Resultado: " + calculate.Subtraction());
							break;
						}
					case '3':
						{
							Console.Write("Resultado: " + calculate.Multiplication());
							break;
						}
					case '4':
						{
							Console.Write("Resultado: " + calculate.Division());
							break;
						}
					default:
						{
							Console.Clear();
							Console.Write("Opção Inválida.");
							break;
						}
				};
				Console.ReadLine();
			}
			while(option != '0');
		}
	}
}