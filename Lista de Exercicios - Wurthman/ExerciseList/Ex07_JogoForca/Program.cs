/*
 * Date: 15/09/2023
 * Time: 20:57
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex07_JogoForca
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<string> words = new List<string>();
			List<Category> types = new List<Category>();
			string[] lineSplit;
			
			string line;
			string path = "C:\\Users\\Windows\\Documents\\SharpDevelop Projects\\C# Console Practice\\Lista de Exercicios - Wurthman\\ExerciseList\\Ex07_JogoForca\\Resources\\WordList.csv";
			StreamReader wordRead = new StreamReader(path);
			
			while((line = wordRead.ReadLine()) != null)
			{
				lineSplit = line.Split(',');
				words.Add(lineSplit[0]);
				
				Category type;
				Enum.TryParse(lineSplit[1], out type);
				types.Add(type);
			}
			
			foreach(string s in words)
			{
				Console.WriteLine(s);
			}
			
			foreach(Category c in types)
			{
				Console.WriteLine(c);
			}
			
			Console.ReadKey();
			for (int i = 0; i < 30; i++) 
			{
				HangmanGame game = new HangmanGame(types[i], words[i]);
			}
		}
	}
}