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
			ShowScore();
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
			Console.WriteLine(nameP1 + " - Pontos: " + scoreP1);
			Console.WriteLine(nameP2 + " - Pontos: " + scoreP2);
			
			Console.WriteLine("Pressione enter para jogar uma rodada.");
			Console.ReadLine();
			PlayTurn();
		}
		
		public static void PlayTurn()
		{
			int rollP1, rollP2;
			rollP1 = diceRoll.Next(6);
			rollP2 = diceRoll.Next(6);
			
			Console.Write("{0} tirou {1}, e {2} tirou {3}. ", nameP1, rollP1, nameP2, rollP2);
			
			if (rollP1 > rollP2)
			{
				scoreP1++;
				Console.Write("{0} venceu a rodada!", nameP1);
			}
			else
			{
				if (rollP2 > rollP1)
				{
					scoreP2++;
					Console.Write("{0} venceu a rodada!", nameP2);
				}
				else
				{
					Console.Write("Empate!");
				}
			}
			
			currentTurn++;
			Console.ReadLine();
			
			if (currentTurn < 3)
			{
				ShowScore();
			}
			else
			{
				Console.Write("\n\nResultado!\n");
				if (scoreP1 > scoreP2)
				{
					Console.Write("{0} venceu a partida!", nameP1);
				}
				else
				{
					if (scoreP2 > scoreP1)
					{
						Console.Write("{0} venceu a rodada!", nameP2);
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
}