/*
 * Date: 15/04/2023
 * Time: 15:13
*/
using System;

namespace TestKeyInfo
{
	class Program
	{
		public static void Main(string[] args)
		{
			ConsoleKeyInfo keyInfo;
			int asciiValue;
			
			Console.WriteLine("Press any key to see its information: ");
			
			while (true) {
				keyInfo = Console.ReadKey(true);
				asciiValue = (int)keyInfo.KeyChar; // Converts the entered character into its ascii value
				
				Console.SetCursorPosition(0, 2);
				Console.Write(new String(' ', 320)); // Erases previous input
				Console.SetCursorPosition(0, 2);
				// Shows: The key pressed. The character produced by it. The modifiers that affect it. The character's ascii value
				Console.Write("Key: " + keyInfo.Key + "\nCharacter: " + keyInfo.KeyChar + "\nModifier: " +  keyInfo.Modifiers + "\nValue: " + asciiValue);
			}
		}
	}
}