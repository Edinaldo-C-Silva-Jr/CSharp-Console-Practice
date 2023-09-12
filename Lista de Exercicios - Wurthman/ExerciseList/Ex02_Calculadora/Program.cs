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
		// Draws the menu of the application, showing all the options available and asking the user to choose one of them
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
			Console.SetCursorPosition(10, 6);
			Console.Write("5 - Resto da Divisão");
			Console.SetCursorPosition(10, 7);
			Console.Write("6 - Potenciação");
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
					case '0': // Leave the Application
						{
							Console.Clear();
							Console.Write("Saindo do aplicativo...");
							break;
						}
					case '1': // Addition
						{
							Console.Write("Resultado da adição: " + calculate.Addition());
							break;
						}
					case '2': // Subtraction
						{
							Console.Write("Resultado da subtração: " + calculate.Subtraction());
							break;
						}
					case '3': // Multiplication
						{
							Console.Write("Resultado da multiplicação: " + calculate.Multiplication());
							break;
						}
					case '4': // Division
						{
							Console.Write("Resultado da divisão: " + calculate.Division());
							break;
						}
					case '5': // Mod (rest of division)
						{
							Console.Write("Resto da divisão: " + calculate.RestDivision());
							break;
						}
					case '6': // Exponential
						{
							Console.Write("Resultado da potenciação: " + calculate.Exponential());
							break;
						}
					default: // If none of the previous, tell the user the operation is invalid
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