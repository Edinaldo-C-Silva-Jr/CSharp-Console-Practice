/*
 * Date: 24/05/2023
 * Time: 14:10
 */
using System;
using System.Text;
using System.Collections.Generic;

namespace Hangman
{
	public class Hangman
	{
		private int currentTheme = 0; // Theme related variables
		private string currentThemeName = "";
		
		private Random wordPicker; // Word list related variables
		private Dictionary<int, string> wordList;
		
		private string chosenWord, wordWithSpaces = "", letterToPlay; // Game variables
		private int totalMisses = 0;
		private bool win;
		
		public Hangman()
		{
			wordPicker = new Random();
			PickTheme();
		}
		
		private void PickTheme()
		{
			Words themeList = new Words();
			
			switch(currentTheme)
			{
				case 0:
					{
						wordList = themeList.countries;
						currentThemeName = "Countries";
						break;
					}
				case 1:
					{
						wordList = themeList.animals;
						currentThemeName = "Animals  ";
						break;
					}
			}
		}
		
		public string CycleTheme()
		{
			if (currentTheme == 1)
			{
				currentTheme = 0;
			}
			else
			{
				currentTheme++;
			}
			
			PickTheme();
			
			return currentThemeName;
		}
		
		private void DrawPlayField()
		{
			Console.Clear();
			
			Console.SetCursorPosition(12, 0);
			Console.Write("Hangman Game");
			
			Console.SetCursorPosition(0, 2);
			Console.Write(wordWithSpaces);
			
			Console.SetCursorPosition(0, 4);
			Console.Write("Misses: " + totalMisses);
		}
		
		private void CompareLetter()
		{
			bool error = true;
			
			for (int i = 0; i < chosenWord.Length; i++)
			{
				if (chosenWord.Substring(i, 1).ToLower() == letterToPlay.ToLower())
				{
					wordWithSpaces = wordWithSpaces.Remove(i*2, 1);
					wordWithSpaces = wordWithSpaces.Insert(i*2, chosenWord.Substring(i, 1));
					error = false;
				}
			}
			
			if (error)
			{
				totalMisses++;
			}
		}
		
		private void CheckWin()
		{
			win = !(wordWithSpaces.Contains("_"));
		}
		
		private void BuildWordWithSpaces()
		{
			wordWithSpaces = "";
			
			for (int i = 0; i < chosenWord.Length; i++)
			{
				if(chosenWord.Substring(i, 1) == " ")
				{
					wordWithSpaces += "  ";
				}
				else
				{
					wordWithSpaces += "_ ";
				}
			}
		}
		
		public void PlayGame()
		{
			win = false;
			totalMisses = 0;
			chosenWord = wordList[wordPicker.Next(1, wordList.Count + 1)];
			
			BuildWordWithSpaces();
			DrawPlayField();
			
			while(win == false)
			{
				if (totalMisses == 6)
				{
					break;
				}
				Console.SetCursorPosition(0, 6);
				Console.WriteLine("\nEnter a letter: ");
				letterToPlay = Console.ReadLine();
				
				CompareLetter();
				DrawPlayField();
				CheckWin();
			}
			
			Console.SetCursorPosition(0, 8);
			if (win)
			{
				Console.WriteLine("Winner!");
			}
			else
			{
				Console.WriteLine("Loser!");
			}
			Console.ReadKey(true);
		}
	}
}
