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
		private int inputAscii, cursorX, cursorY, minimumInputSize, maximumInputSize;
		private bool validCharacter; // Flag that tells whether the current input is a valid character or not
		
		// Stores the current cursor position. Used to always show the built input string in the same place
		private void GetCursorPosition()
		{
			cursorX = Console.CursorLeft;
			cursorY = Console.CursorTop;
		}
		
		// Assigns the maximum and minimum input sizes passed to the method.
		// Also checks whether the minimum value is actually bigger than the maximum. If so, it swaps the values to make sure the maximum is always bigger
		private void AssignInputSizes(int min, int max)
		{
			if (max < min)
			{
				maximumInputSize = min;
				minimumInputSize = max;
			}
			else
			{
				maximumInputSize = max;
				minimumInputSize = min;
			}
		}
		
		// Method that checks whether the input is valid (using the validCharacter flag), and plays a beep sound if it's not
		private void BeepOnInvalidInput ()
		{
			if (!(validCharacter))
			{
				SystemSounds.Beep.Play();
			}
			validCharacter = false;
		}
		
		// Tests whether the input character is the Enter key
		// Enter is used to exit the main loop and finish the input/validation process
		private bool TestEnter(string full)
		{
			if (inputAscii == 13) // If input's ascii value is 13 (enter key)
			{
				if (full.Length >= minimumInputSize) // Checks whether the input string is bigger than the defined minimum input size. Enter will only be a valid input if the input string is equal or bigger than the minimum size.
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
		
		// Method that limits the amount of characters that can be entered when receiving an input
		// The maximum and minimum parameters define the desired maximum and minimum sizes to accept for an input string
		// This method accepts any character as an input (as long as it's not a control character)
		// Note that this only includes base ASCII characters
		public string LimitInputAll(int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = ""; // The full input string that will be returned by the method
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar; // Converts the input character into an ascii value
				
				enterPressed = TestEnter(fullInput); // Tests if enter key is pressed
				fullInput = TestBackspace(fullInput); // Tests if backspace key is pressed
				
				if ((inputAscii > 31 && inputAscii < 127) && (fullInput.Length < maximumInputSize)) // Tests if any non-control character is pressed. Also checks if the input string size is already equal to the maximum accepted size (if it is, no more inputs can be accepted)
				{
					fullInput += currentCharInput.KeyChar; // If input is a valid character, append it into the input string
					validCharacter = true;
				}
				
				BeepOnInvalidInput(); 
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput); // Writes the input string on the screen, in the same position recorded at the start
			}
			while(!(enterPressed));// Keep checking until enter key is pressed
			
			return fullInput;
		}
		
		// Overload of the above method that only takes one parameter (max input size)
		// This method defines the min input size as 0
		public string LimitInputAll (int maxInputSize)
		{
			return LimitInputAll(0, maxInputSize);
		}
		
		// Limits the amount of characters that can be entered
		// This method only accepts input if the character is a number
		public double LimitInputNumberOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true); // Converts the input character into an ascii value
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput);
				fullInput = TestBackspace(fullInput);
				
				if ((inputAscii > 47 && inputAscii < 58) && (fullInput.Length < maximumInputSize)) // Tests if the character entered is a number. Also checks if the input string size is already equal to the maximum accepted size (if it is, no more inputs can be accepted)
				{
					fullInput += currentCharInput.KeyChar; // If input is a number, append it into the string
					validCharacter = true;
				}
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!(enterPressed));
			
			if (fullInput.Length == 0) // If input string is empty, append '0' to it, to prevent a parsing error (since the return type is a double)
			{
				fullInput += "0";
			}
			
			return double.Parse(fullInput); // Returns the input string as a double value
		}
		
		// Overload of the above method that only takes one parameter (max input size)
		// This method defines the min input size as 0
		public double LimitInputNumberOnly (int maxInputSize)
		{
			return LimitInputNumberOnly(0, maxInputSize);
		}
		
		// Limits the amount of characters that can be entered
		// This method only accepts input if the character is an uppercase or lowercase letter 
		public string LimitInputLetterOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar; // Converts the input character into an ascii value
				
				enterPressed = TestEnter(fullInput);
				fullInput = TestBackspace(fullInput);
				
				if (((inputAscii > 64 && inputAscii < 91) || (inputAscii > 96 && inputAscii < 124)) && (fullInput.Length < maximumInputSize)) // Tests if the character entered is an uppercase or lowercase letter. Also checks if the input string size is already equal to the maximum accepted size (if it is, no more inputs can be accepted)
				{
					fullInput += currentCharInput.KeyChar; // If input is a letter, append it into the string
					validCharacter = true;
				}
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!(enterPressed));
			
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