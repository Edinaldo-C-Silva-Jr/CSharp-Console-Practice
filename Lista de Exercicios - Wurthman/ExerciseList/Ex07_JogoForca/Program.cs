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
			Random wordPicker = new Random();
			List<string> words = new List<string>();
			List<Category> types = new List<Category>();
			string[] lineSplit;
			
			// Read the file
			
			string line;
			string path = AppDomain.CurrentDomain.BaseDirectory;
			path = path.TrimEnd(new char[]{'\\', 'b', 'i', 'n', 'D', 'e', 'u', 'g'});
			path += "\\Resources\\WordList.csv";
			StreamReader wordRead = new StreamReader(path);
			
			while((line = wordRead.ReadLine()) != null)
			{
				lineSplit = line.Split(',');
				words.Add(lineSplit[0]);
				
				Category type;
				Enum.TryParse(lineSplit[1], out type);
				types.Add(type);
			}
			
			// Pick category
			
			Category category = (Category)wordPicker.Next(0, 2);
			List<int> wordsInCategory = new List<int>();
			
			for (int i = 0; i < types.Count; i++)
			{
				if (types[i] == category)
				{
					wordsInCategory.Add(i);
				}
			}
			
			int randomWord = wordsInCategory[wordPicker.Next(0, wordsInCategory.Count)];
			string pickedWord = words[randomWord];
			
			// Start Game
			
			HangmanGame game = new HangmanGame(category, pickedWord);
		}
	}
}