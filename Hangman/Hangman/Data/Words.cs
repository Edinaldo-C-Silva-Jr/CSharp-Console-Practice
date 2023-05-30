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
		public Dictionary<int, string> foods;
		public Dictionary<int, string> colors;
		public Dictionary<int, string> objects;
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
				{1, "Dog"}, {2, "Cat"}, {3, "Cow"}, {4, "Fox"}, {5, "Pig"}, {6, "Bat"}, {7, "Owl"}, {8, "Rat"}, {9, "Ant"}, {10, "Bee"}, {11, "Fly"}, {12, "Hen"},
				{13, "Goat"}, {14, "Wolf"}, {15, "Deer"}, {16, "Hawk"}, {17, "Duck"}, {18, "Boar"}, {19, "Mole"}, {20, "Lion"}, {21, "Crab"}, {22, "Slug"}, {23, "Moth"}, {24, "Seal"}, {25, "Bear"}, {26, "Crow"}, {27, "Fish"}, {28, "Frog"}, {29, "Worm"}, {30, "Wasp"},
				{31, "Koala"}, {32, "Llama"}, {33, "Zebra"}, {34, "Sheep"}, {35, "Mouse"}, {36, "Sloth"}, {37, "Snail"}, {38, "Shark"}, {39, "Squid"}, {40, "Tiger"}, {41, "Gecko"}, {42, "Whale"}, {43, "Eagle"}, {44, "Goose"}, {45, "Moose"}, {46, "Panda"}, {47, "Horse"}, {48, "Hyena"}, {49, "Snake"}, {50, "Camel"}, 
				{51, "Parrot"}, {52, "Spider"}, {53, "Beetle"}, {54, "Shrimp"}, {55, "Oyster"}, {56, "Coyote"}, {57, "Ferret"}, {58, "Turkey"}, {59, "Lizard"}, {60, "Donkey"}, {61, "Turtle"}, {62, "Rabbit"}, {63, "Beaver"}, {64, "Iguana"}, {65, "Pigeon"}, {66, "Dragon"}, {67, "Monkey"}, {68, "Toucan"}, 
				{69, "Ostrich"}, {70, "Gorilla"}, {71, "Giraffe"}, {72, "Hamster"}, {73, "Buffalo"}, {74, "Vulture"}, {75, "Mammoth"}, {76, "Peacock"}, {77, "Chicken"}, {78, "Rooster"}, {79, "Octopus"}, {80, "Lobster"}, {81, "Seagull"}, {82, "Sea Lion"}, {83, "Ladybug"}, {84, "Gazelle"}, {85, "Panther"}, {86, "Leopard"}, {87, "Dolphin"}, {88, "Raccoon"},
				{89, "Kangaroo"}, {90, "Hedgehog"}, {91, "Flamingo"}, {92, "Starfish"}, {93, "Anteater"}, {94, "Barnacle"}, {95, "Mosquito"}, {96, "Scorpion"}, {97, "Goldfish"}, {98, "Stingray"}, {99, "Capybara"}, {100, "Red Panda"}, {101, "Elephant"}, {102, "Tortoise"}, {103, "Squirrel"}, 
				{104, "Alligator"}, {105, "Armadillo"}, {106, "Orangutan"}, {107, "Chameleon"}, {108, "Jellyfish"}, {109, "Blue Whale"}, {110, "Black Bear"}, {111, "Guinea Pig"}, {112, "Earthworm"}, {113, "Butterfly"}, {114, "Centipede"}, {115, "Millipede"}, {116, "Cockroach"}, {117, "Dragonfly"}, {118, "Tarantula"}, {119, "Crocodile"}, {120, "Polar Bear"},
				{121, "Rhinoceros"}, {122, "Salamander"}, {123, "Hermit Crab"}, {124, "Chimpanzee"}, 
				{125, "Hummingbird"}, {126, "Grasshopper"}, {127, "Sea Cucumber"}, {128, "Grizzly Bear"},
				{129, "Hippopotamus"}, {130, "Komodo Dragon"},
			};
		}
		
		public int GetThemeAmount()
		{
			return this.themeAmount;
		}
	}
}
