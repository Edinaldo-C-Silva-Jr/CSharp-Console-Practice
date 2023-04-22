/*
 * Date: 12/04/2023
 * Time: 18:11
 */
using System;
using System.Threading;
using System.Media;
using System.Collections.Generic;

namespace InputLimitator
{
	// Class that validates the values inputted into the program based on the amount of characters
	// It utilizes Console.ReadKey() to receive each character, then appends them into a string
	// This means the input size can be set arbitrarily, and can go beyond the 254 character limit of a Console.ReadLine()
	// Each method also further validates the characters, to only allow for specific characters to be entered
	public class LimitInput
	{
		private ConsoleKeyInfo currentCharInput;
		private int inputAscii, cursorX, cursorY;
		private bool validCharacter; // Flag that tells whether the current input is a valid character or not
		
		#region Meta Stuff
		// Stores the current cursor position. Used to always show the built input string in the same place
		private void GetCursorPosition()
		{
			cursorX = Console.CursorLeft;
			cursorY = Console.CursorTop;
		}
		
		// Method that checks whether the input is valid (using the validCharacter flag), and plays a beep sound if it's not
		private void BeepOnInvalidInput ()
		{
			if (!validCharacter)
			{
				SystemSounds.Beep.Play();
			}
			validCharacter = false;
		}
		#endregion
		
		#region Enter and Backspace
		// Tests whether the input character is the Enter key
		// Enter is used to exit the main loop and finish the input/validation process
		private bool TestEnter(string full, int minimum)
		{
			if (inputAscii == 13) // If input's ascii value is 13 (enter key)
			{
				if (full.Length >= minimum) // Checks whether the input string is bigger than the defined minimum input size. Enter will only be a valid input if the input string is equal or bigger than the minimum size.
				{
					validCharacter = true;
					return true; // Returns true to signal that enter was pressed
				}
			}
			return false;
		}
		
		// Tests whether the input character is the Backspace key
		// This method implements the normal backspace functionality of erasing the most recent character added to the input string
		private string TestBackspace(string full)
		{
			if (inputAscii == 8) // If input's ascii value is 8 (backspace key)
			{
				if (full.Length > 0) // Checks whether the input string has characters in it. If it's empty, then nothing can be removed from it
				{
					full = full.Substring(0, full.Length - 1); // Erases the last character of the input string
					Console.SetCursorPosition(cursorX, cursorY);
					Console.Write(new String(' ', full.Length + 1)); 
					validCharacter = true;
				}
			}
			
			return full; // Returns the new input string after removing the last character
		}
		#endregion
		
		#region Test Single Characters
		private string TestSpace(string full, int maximum)
		{
			if (inputAscii == 32 && full.Length < maximum)
			{
				full += currentCharInput.KeyChar;
				validCharacter = true;
			}
			return full;
		}
		
		private string TestZero (string full, int maximum)
		{
			if (inputAscii == 48 && full.Length < maximum)
			{
				full += currentCharInput.KeyChar;
				validCharacter = true;
			}
			return full;
		}
		#endregion
		
		#region Test Multiple Characters
		private string TestDigitsOneNine (string full, int maximum)
		{
			if ((inputAscii > 48 && inputAscii < 58) && (full.Length < maximum))
			{
				full += currentCharInput.KeyChar;
				validCharacter = true;
			}
			return full;
		}
		
		private string TestUppercaseLetters (string full, int maximum)
		{
			if ((inputAscii > 65 && inputAscii < 91) && (full.Length < maximum))
			{
				full += currentCharInput.KeyChar;
				validCharacter = true;
			}
			return full;
		}
		
		private string TestLowercaseLetters (string full, int maximum)
		{
			if ((inputAscii > 96 && inputAscii < 124) && (full.Length < maximum))
			{
				full += currentCharInput.KeyChar;
				validCharacter = true;
			}
			return full;
		}
		#endregion
		
		#region Limit Input Any Character
		// Method that limits the amount of characters that can be entered when receiving an input
		// The maximum and minimum parameters define the desired maximum and minimum sizes to accept for an input string
		// This method accepts any character as an input (as long as it's not a control character)
		public string LimitInputAll(int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			
			if (minInputSize > maxInputSize)
			{
				int auxSize = maxInputSize;
				maxInputSize = minInputSize;
				minInputSize = auxSize;
			}
			
			string fullInput = ""; // The full input string that will be returned by the method
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize); // Tests if enter key is pressed
				fullInput = TestBackspace(fullInput); // Tests if backspace key is pressed
				
				if (!Char.IsControl(currentCharInput.KeyChar) && (fullInput.Length < maxInputSize)) // Tests if any non-control character is pressed. Also checks if the input string size is already equal to the maximum accepted size (if it is, no more inputs can be accepted)
				{
					fullInput += currentCharInput.KeyChar; // If input is a valid character, append it into the input string
					validCharacter = true;
				}
				
				BeepOnInvalidInput(); 
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput); // Writes the input string on the screen, in the same position recorded at the start
			}
			while(!enterPressed);// Keep checking until enter key is pressed
			
			return fullInput;
		}
		
		// Overload of the above method that only takes one parameter (max input size)
		// This method defines the min input size as 0
		public string LimitInputAll (int maxInputSize)
		{
			return LimitInputAll(0, maxInputSize);
		}
		#endregion
		
		// Limits the amount of characters that can be entered
		// This method only accepts input if the character is a number
		public string LimitInputDigitsOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			
			if (minInputSize > maxInputSize)
			{
				int auxSize = maxInputSize;
				maxInputSize = minInputSize;
				minInputSize = auxSize;
			}
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true); // Converts the input character into an ascii value
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestZero(fullInput, maxInputSize);
				fullInput = TestDigitsOneNine(fullInput, maxInputSize);
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!enterPressed);
			
			if (fullInput.Length == 0) // If input string is empty, append '0' to it, to prevent a parsing error (since the return type is a double)
			{
				fullInput += "0";
			}
			
			return fullInput; // Returns the input string as a double value
		}
		
		// Overload of the above method that only takes one parameter (max input size)
		// This method defines the min input size as 0
		public string LimitInputDigitsOnly (int maxInputSize)
		{
			return LimitInputDigitsOnly(0, maxInputSize);
		}
		
		public double LimitInputDoubleNumber (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			bool isValidNumber = false;
			double number = 0;
			
			do
			{
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(new String(' ', maxInputSize));
				Console.SetCursorPosition(cursorX, cursorY);
				isValidNumber = double.TryParse(LimitInputDigitsOnly(minInputSize, maxInputSize), out number);
			}
			while (!isValidNumber);
			
			return number;
		}
		
		public double LimitInputDoubleNumber (int maxInputSize)
		{
			return LimitInputDoubleNumber(0, maxInputSize);
		}
		
		public string LimitInputDigitsOnlyNotZero (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			
			if (minInputSize > maxInputSize)
			{
				int auxSize = maxInputSize;
				maxInputSize = minInputSize;
				minInputSize = auxSize;
			}
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestDigitsOneNine(fullInput, maxInputSize);
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while(!enterPressed);
			
			return fullInput;
		}
		
		public string LimitInputDigitsOnlyNotZero (int maxInputSize)
		{
			return LimitInputDigitsOnlyNotZero(0, maxInputSize);
		}
		
		// Limits the amount of characters that can be entered
		// This method only accepts input if the character is an uppercase or lowercase letter 
		public string LimitInputLetterOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			
			if (minInputSize > maxInputSize)
			{
				int auxSize = maxInputSize;
				maxInputSize = minInputSize;
				minInputSize = auxSize;
			}
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar; // Converts the input character into an ascii value
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestUppercaseLetters(fullInput, maxInputSize);
				fullInput = TestLowercaseLetters(fullInput, maxInputSize);
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!enterPressed);
			
			return fullInput;
		}
		
		// Overload of the above method that only takes one parameter (max input size)
		// This method defines the min input size as 0
		public string LimitInputLetterOnly (int maxInputSize)
		{
			return LimitInputLetterOnly(0, maxInputSize);
		}
	}
}