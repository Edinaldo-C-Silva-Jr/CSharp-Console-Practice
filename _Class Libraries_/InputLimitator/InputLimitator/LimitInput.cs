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
		private int currentInputAscii, cursorX, cursorY;
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
			if (currentInputAscii == 13) // If input's ascii value is 13 (enter key)
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
			if (currentInputAscii == 8) // If input's ascii value is 8 (backspace key)
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
		
		#region Test Characters
		// Method that tests the validity of a single character
		// It receives an accepted ascii value as a parameter, and then compares the current input to that ascii value
		private string TestSingleCharacter(string full, int maximum, int validAscii)
		{
			if (currentInputAscii == validAscii && full.Length < maximum) // Checks if the current input is the same as the defined ascii value (Also checks if the string already has the maximum value, as then no more inputs would be accepted)
			{
				full += currentCharInput.KeyChar; // If it is valid, append the input into the string
				validCharacter = true;
			}
			return full;
		}
		
		// Method that tests the validity of multiple characters. Used to check many consecutive ascii values at once
		// It receives a lower and an upper bound of ascii values, then checks if the current input is anywhere between these bounds
		private string TestMultipleCharacters (string full, int maximum, int lowerValidAscii, int higherValidAscii)
		{
			if ((currentInputAscii > lowerValidAscii && currentInputAscii < higherValidAscii) && (full.Length < maximum)) // Tests if the current input is within the defined ascii boundaries (and if the string is full)
			{
				full += currentCharInput.KeyChar; // If it's valid, append the input into the string
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
			
			if (minInputSize > maxInputSize) // Swaps the sizes in case the minimum value is higher than the maixmum value
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
				currentInputAscii = (int)currentCharInput.KeyChar;
				
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
		
		#region Limit Input 0 to 9
		// Limits the amount of characters that can be entered
		// This method only accepts input if the character is a number, but returns the input as a text
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
				currentInputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestMultipleCharacters(fullInput, maxInputSize, 47, 58); // Checks whether the input is between the passed parameters (47 and 58). The values correspond to the numbers from 0 to 9
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!enterPressed);
			
			if (fullInput.Length == 0) // If input string is empty, append '0' to it, to return that as an "empty input"
			{
				fullInput += "0";
			}
			
			return fullInput;
		}
		
		// Overload of the above method that only takes one parameter 
		public string LimitInputDigitsOnly (int maxInputSize)
		{
			return LimitInputDigitsOnly(0, maxInputSize);
		}
		
		// Method that implements the same method above (limits inputs to only numbers), but returns the input as a double value instead of a string value
		// This uses a TryParse because, even if the result of a limitInputDigitsOnly is always a number, it can overflow a double in case it has over 307 characters
		public double LimitInputDoubleNumber (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			bool isValidNumber = false;
			double number = 0;
			
			do
			{
				Console.SetCursorPosition(cursorX, cursorY); // Erases the previous input in case the number is not valid
				Console.Write(new String(' ', maxInputSize));
				Console.SetCursorPosition(cursorX, cursorY); // Goes back in position to accept a new input
				isValidNumber = double.TryParse(LimitInputDigitsOnly(minInputSize, maxInputSize), out number); 
			}
			while (!isValidNumber); // Keep going until the parsing is successful
			
			return number;
		}
		
		// Overload of the above method that only takes one parameter
		public double LimitInputDoubleNumber (int maxInputSize)
		{
			return LimitInputDoubleNumber(0, maxInputSize);
		}
		#endregion
		
		#region Limit Input 1 to 9
		// Limits the amount of characters that can be entered
		// This method only accepts digit characters from 1 to 9 (so it doesn't accept 0)
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
				currentInputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestMultipleCharacters(fullInput, maxInputSize, 48, 58); // Checks whether the input is between the passed parameters (48 and 58). The values correspond to the numbers from 1 to 9
				
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
		#endregion
		
		#region Limit Input Letters A-Z
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
				currentInputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput, minInputSize);
				fullInput = TestBackspace(fullInput);
				
				fullInput = TestMultipleCharacters(fullInput, maxInputSize, 64, 91); // Checks whether the input is between the passed parameters (64 and 91). The values correspond to the uppercase letters from A to Z
				fullInput = TestMultipleCharacters(fullInput, maxInputSize, 96, 123); // Checks whether the input is between the passed parameters (96 and 123). The values correspond to the lowercase letters from a to z
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!enterPressed);
			
			return fullInput;
		}
		
		// Overload of the above method that only takes one parameter
		public string LimitInputLetterOnly (int maxInputSize)
		{
			return LimitInputLetterOnly(0, maxInputSize);
		}
		#endregion
	}
}