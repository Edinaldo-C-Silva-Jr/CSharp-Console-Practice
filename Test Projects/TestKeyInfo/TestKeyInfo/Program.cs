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
				asciiValue = (int)keyInfo.KeyChar;
				
				Console.SetCursorPosition(0, 2);
				Console.Write(new String(' ', 320));
				Console.SetCursorPosition(0, 2);
				Console.Write("Key: " + keyInfo.Key + "\nCharacter: " + keyInfo.KeyChar + "\nModifier: " +  keyInfo.Modifiers + "\nValue: " + asciiValue);
			}
		}
	}
}