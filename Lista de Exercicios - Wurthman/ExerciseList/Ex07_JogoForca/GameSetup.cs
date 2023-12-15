/*
 * Date: 19/11/2023
 * Time: 15:59
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Ex07_JogoForca
{
	/// <summary>
	/// A class with methods to setup the game, choose the words and the categories.
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
		
		/// <summary>
		/// Reads the WordList file to get all words ready to be picked.
		/// </summary>
		public void ReadWordListFile()
		{
			listOfWords = new List<string>();
			listOfCategories = new List<Category>();
			
			string line;
			string[] lineSplit;
			
			string path = AppDomain.CurrentDomain.BaseDirectory; // Gets the path of the assembly generated for this project.
			path = path.TrimEnd(new char[]{'\\', 'b', 'i', 'n', 'D', 'e', 'u', 'g'}); // Removes the "\bin\debug" part from the file.
			path += "\\Resources\\WordList.csv"; // References the WordList file inside the Resources folder.
			
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
		
		/// <summary>
		/// Randomly picks the category to use for a game session.
		/// </summary>
		/// <returns>The category chosen.</returns>
		public Category PickCategory()
		{
			Category chosenCategory = (Category)randomNumber.Next(0, 4);
			return chosenCategory;
		}
		
		/// <summary>
		/// Randomly picks a word from the category currently chosen for a game session.
		/// </summary>
		/// <param name="chosenCategory">The category currently chosen.</param>
		/// <returns>The word to be used in the game, without accent marks.</returns>
		public string PickWord(Category chosenCategory)
		{
			List<int> wordsInChosenCategory = new List<int>();
			
			for (int i = 0; i < listOfCategories.Count; i++)
			{
				if (listOfCategories[i] == chosenCategory) // Builds a new list with only words in the chosen category
				{
					wordsInChosenCategory.Add(i);
				}
			}
			
			int randomWord = wordsInChosenCategory[randomNumber.Next(0, wordsInChosenCategory.Count)];
			return RemoveAccentMarks(listOfWords[randomWord]);
		}
		
		/// <summary>
		/// Receives a word and removes the accent marks from it.
		/// </summary>
		/// <param name="word">The word to have accent marks removed.</param>
		/// <returns>The word without the accent marks.</returns>
		private string RemoveAccentMarks(string word)
		{
			byte[] temporaryBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(word);
			string wordWithoutAccentMarks = Encoding.UTF8.GetString(temporaryBytes);
			
			return wordWithoutAccentMarks;
		}
	}
}
