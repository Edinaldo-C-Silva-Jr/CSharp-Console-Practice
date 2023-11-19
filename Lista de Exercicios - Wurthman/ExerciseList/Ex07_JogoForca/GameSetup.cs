/*
 * Date: 19/11/2023
 * Time: 15:59
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex07_JogoForca.Resources
{
	/// <summary>
	/// Description of GameSetup.
	/// </summary>
	public class GameSetup
	{
		private Random randomNumber;
		private List<string> listOfWords;
		private List<Category> listOfCategories;
		
		public GameSetup()
		{
			randomNumber = new Random();
		}
		
		public void ReadWordListFile()
		{
			listOfWords = new List<string>();
			listOfCategories = new List<Category>();
			
			string line;
			string[] lineSplit;
			
			string path = AppDomain.CurrentDomain.BaseDirectory;
			path = path.TrimEnd(new char[]{'\\', 'b', 'i', 'n', 'D', 'e', 'u', 'g'});
			path += "\\Resources\\WordList.csv";
			
			using (StreamReader wordFileReader = new StreamReader(path))
			{
				while((line = wordFileReader.ReadLine()) != null)
				{
					lineSplit = line.Split(',');
					listOfWords.Add(lineSplit[0]);
					
					Category currentWordCategory;
					Enum.TryParse(lineSplit[1], out currentWordCategory);
					listOfCategories.Add(currentWordCategory);
				}
			}
			
			
		}
		
		public Category PickCategory()
		{
			Category chosenCategory = (Category)randomNumber.Next(0, 2);
			return chosenCategory;
		}
		
		public string PickWord(Category chosenCategory)
		{
			List<int> wordsInChosenCategory = new List<int>();
			
			for (int i = 0; i < listOfCategories.Count; i++)
			{
				if (listOfCategories[i] == chosenCategory)
				{
					wordsInChosenCategory.Add(i);
				}
			}
			
			int randomWord = wordsInChosenCategory[randomNumber.Next(0, wordsInChosenCategory.Count)];
			return listOfWords[randomWord];
		}
	}
}
