/*
 * Date: 23/05/2023
 * Time: 20:32
 */
using System;
using System.Collections.Generic;

namespace Hangman
{
	public class Words
	{
		public Dictionary<int, string> countries;
		public Dictionary<int, string> animals;
		private int themeAmount;
		
		public Words()
		{
			themeAmount = 2;
			
			this.countries = new Dictionary<int, string>()
			{
				{1, "Angola"}, {2, "Argentina"}, {3, "Armenia"}, {4, "Australia"}, {5, "Austria"},
				{6, "Bahamas"}, {7, "Belgium"}, {8, "Bolivia"}, {9, "Brazil"}, {10, "Bulgaria"},
				{11, "Canada"}, {12, "Chile"}, {13, "China"}, {14, "Colombia"}, {15, "Costa Rica"}, {16, "Cuba"},
				{17, "Denmark"}, {18, "Dominican Republic"},
				{19, "Ecuador"}, {20, "Egypt"}, {21, "Ethiopia"},
				{22, "Finland"}, {23, "France"}, {24, "French Guiana"},
				{25, "Germany"}, {26, "Greece"}, {27, "Greenland"}, {28, "Guatemala"},
				{29, "Honduras"}, {30, "Hong Kong"}, {31, "Hungary"},
				{32, "India"}, {33, "Indonesia"}, {34, "Iran"}, {35, "Ireland"}, {36, "Italy"},
				{37, "Jamaica"}, {38, "Japan"},
				{39, "Kenya"},
				{40, "Lebanon"}, {41, "Libya"}, {42, "Luxembourg"},
				{43, "Madagascar"}, {44, "Malasya"}, {45, "Mexico"}, {46, "Morocco"},
				{47, "Nepal"}, {48, "Netherlands"}, {49, "New Zealand"}, {50, "Nicaragua"}, {51, "Nigeria"}, {52, "North Korea"}, {53, "Norway"},
				{54, "Panama"}, {55, "Paraguay"}, {56, "Peru"}, {57, "Poland"}, {58, "Portugal"},
				{59, "Russia"},
				{60, "Saudi Arabia"}, {61, "Serbia"}, {62, "Singapore"}, {63, "South Africa"}, {64, "South Korea"}, {65, "Spain"}, {66, "Sweden"}, {67, "Switzerland"},
				{68, "Taiwan"}, {69, "Thailand"}, {70, "Turkey"},
				{71, "Ukreaine"}, {72, "United Kingdom"}, {73, "United States"}, {74, "Uruguay"},
				{75, "Venezuela"}
			};
			
			this.animals = new Dictionary<int, string>()
			{
				{1, "Dog"}, {2, "Cat"}, {3, "Bird"}
			};
		}
		
		public int GetThemeAmount()
		{
			return this.themeAmount;
		}
	}
}
