/*
 * Date: 27/08/2023
 * Time: 16:07
 */
using System;

namespace Ex04_JogarDados
{
	class Program
	{
		private static string nameP1, nameP2;
		private static int scoreP1, scoreP2, currentTurn;
		private static Random diceRoll;
		
		public static void Main(string[] args)
		{
			diceRoll = new Random();
			
			ReceiveNames();
			PlayTurn();
		}
		
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
		}
		
		public static void ShowScore()
		{
			Console.Clear();
			Console.WriteLine("{0} - Pontos: {1}", nameP1, scoreP1);
			Console.WriteLine("{0} - Pontos: {1}\n", nameP2, scoreP2);
		}
		
		public static void PlayTurn()
		{
			ShowScore();
			
			if (currentTurn == 3)
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
		
		public static int RollDice(string playerName)
		{
			int diceValue;
			Console.Write("{0}, pressione Enter para fazer sua jogada.", playerName);
			Console.ReadLine();
			Console.WriteLine("{0} tirou {1} no dado!\n", playerName, diceValue = diceRoll.Next(1, 7));
			return diceValue;
		}
		
		private static void ShowResults()
		{
			Console.Write("\nResultado!\n");
			
			if (scoreP1 > scoreP2)
			{
				Console.Write("{0} venceu a partida!", nameP1);
			}
			else
			{
				if (scoreP2 > scoreP1)
				{
					Console.Write("{0} venceu a partida!", nameP2);
				}
				else
				{
					Console.Write("A partida terminou em um empate!");
				}
			}
			Console.ReadLine();
		}
	}
}