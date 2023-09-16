/*
 * Date: 15/09/2023
 * Time: 20:57
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Ex07_JogoForca
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<string> word = new List<string>(), type = new List<string>();
			string[] lineSplit;
			
			string line;
			string path = "C:\\Users\\Windows\\Documents\\SharpDevelop Projects\\C# Console Practice\\Lista de Exercicios - Wurthman\\ExerciseList\\Ex07_JogoForca\\Resources\\WordList.csv";
			StreamReader wordRead = new StreamReader(path);
			
			while((line = wordRead.ReadLine()) != null)
			{
				lineSplit = line.Split(',');
				word.Add(lineSplit[0]);
				type.Add(lineSplit[1]);
			}
			
			foreach(string s in word)
			{
				Console.WriteLine(s);
			}
			
			foreach(string s in type)
			{
				Console.WriteLine(s);
			}
			
			Console.ReadKey();
		}
	}
}