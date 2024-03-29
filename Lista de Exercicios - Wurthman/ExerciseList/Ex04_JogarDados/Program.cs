﻿/*
 * Date: 27/08/2023
 * Time: 16:07
 */
using System;

namespace Ex04_JogarDados
{
	class Program
	{
		private static string nameP1, nameP2;
		private static int scoreP1, scoreP2, currentTurn, amountOfTurns;
		private static Random diceRoll;
		
		public static void Main(string[] args)
		{
			diceRoll = new Random();
			
			ReceiveNames();
			DecideAmountOfTurns();
			PlayTurn();
		}
		
		// Receives the name of both players. The program has to ensure their names are different
		public static void ReceiveNames()
		{
			Console.Write("Digite o nome do primeiro jogador: ");
			nameP1 = Console.ReadLine();
			
			Console.Write("Digite o nome do segundo jogador: ");
			while((nameP2 = Console.ReadLine()) == nameP1)
			{
				Console.SetCursorPosition(25, 5);
				Console.Write("Os nomes não podem ser iguais!");
				
				Console.SetCursorPosition(34, 1);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(34, 1);
			}
			Console.SetCursorPosition(25, 5);
			Console.Write(new String(' ', 30)); // Removes the "invalid name" message from the screen
		}
		
		// Receives and validates the amount of turns, which must be between 1 and 5 based on the exercise's description
		public static void DecideAmountOfTurns()
		{
			Console.SetCursorPosition(0, 2);
			Console.Write("Quantas rodadas vocês desejam jogar? Escolha um valor de 1 a 5: ");
			while(!(int.TryParse(Console.ReadLine(), out amountOfTurns)) || (amountOfTurns < 1 || amountOfTurns > 5))
			{
				Console.SetCursorPosition(64, 2);
				Console.Write(new String(' ', 260));
				Console.SetCursorPosition(64, 2);
			}
		}
		
		// Shows the current turn and the scoreboard
		public static void ShowScore()
		{
			Console.Clear();
			if (currentTurn < amountOfTurns)
			{
				Console.WriteLine("Rodada atual: {0}/{1}\n", currentTurn + 1, amountOfTurns);
			}
			Console.WriteLine("{0} - Pontos: {1}", nameP1, scoreP1);
			Console.WriteLine("{0} - Pontos: {1}\n", nameP2, scoreP2);
		}
		
		// Plays a turn of the dice roll game
		public static void PlayTurn()
		{
			ShowScore();
			
			if (currentTurn == amountOfTurns)
			{
				ShowResults();
				return;
			}
			
			int rollP1, rollP2;
			rollP1 = RollDice(nameP1);
			rollP2 = RollDice(nameP2);
			
			if (rollP1 > rollP2)
			{
				scoreP1++;
				Console.WriteLine("{0} venceu a rodada!", nameP1);
			}
			else
			{
				if (rollP2 > rollP1)
				{
					scoreP2++;
					Console.WriteLine("{0} venceu a rodada!", nameP2);
				}
				else
				{
					Console.WriteLine("Empate!");
				}
			}
			
			Console.WriteLine("\nPressione Enter para continuar...");
			currentTurn++;
			Console.ReadLine();
			
			PlayTurn();
		}
		
		// Rolls the dice for a player. Receives the player name to show on the screen
		public static int RollDice(string playerName)
		{
			int diceValue;
			Console.Write("{0}, pressione Enter para fazer sua jogada.", playerName);
			Console.ReadLine();
			Console.WriteLine("{0} tirou {1} no dado!\n", playerName, diceValue = diceRoll.Next(1, 7));
			return diceValue;
		}
		
		// Shows the results of the match and ends the application
		private static void ShowResults()
		{
			Console.Write("\nResultado!\n");
			
			if (scoreP1 > scoreP2)
			{
				Console.Write("{0} venceu a partida!", nameP1);
				Console.ReadLine();
			}
			else
			{
				if (scoreP2 > scoreP1)
				{
					Console.Write("{0} venceu a partida!", nameP2);
					Console.ReadLine();
				}
				else // If the result is a draw, play an extra turn (until a winner is defined)
				{
					currentTurn--;
					PlayTurn();
				}
			}
		}
	}
}