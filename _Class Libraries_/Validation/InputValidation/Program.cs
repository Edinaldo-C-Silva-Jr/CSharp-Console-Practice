/*
 * Date: 15/02/2023
 * Time: 01:17
*/
using System;
using System.Media;

namespace InputValidation
{
	// Class created to provide methods that validade inputs for console applications
	// These methods ensure the inputted value will be in the desired format in order to avoid parsing errors or unintended behaviors
	public class ValidateInput
	{
		private static int cursorX = 0, cursorY = 0; // Cursor position values - Used in the method ClearPreviousLine()
		
		private static string[] validStrings = new string[] {}; // String that contains the values which are considered valid - Used in the method ValidateString()
		private static char[] validChars = new char[] {}; // Array that contains the char values that are considered valid - Used in the method ValidateChar()
		private static string inputToTest = "";
		private static char charToTest = ' ';
		private static double numberToTest = 0;
		private static int integerToTest = 0;
		
		// Method that gets the current cursor position in the console window
		// Used to know the position the cursor should return to in the method below
		private static void GetCursorPosition()
		{
				cursorX = Console.CursorLeft;
				cursorY = Console.CursorTop;
		}
		
		// Method that clears the previous line of the console
		// Intended to be used with the validation methods to restore the cursor to its original position in case an input was invalid
		private static void ClearPreviousLine(int inputLength)
		{
			Console.SetCursorPosition(cursorX, cursorY); // Sets the cursor back to the position recorded before the input
 			Console.Write(new string(' ', inputLength)); // Builds a string of blank spaces to erase previous input
 			Console.SetCursorPosition(cursorX, cursorY);
 			SystemSounds.Beep.Play(); // Plays a sound to warn the user that the input is invalid
		}
		
		// Sets the valid values for the method ValidateString
		// Converts the received string to lowercase, so the ValidateString method works regardless of case
		public static void SetValidStrings(string[] valid)
		{
			validStrings = Array.ConvertAll(valid, individualValue => individualValue.ToLower());
		}
		
		// Method that repeatedly asks for an input until the inputted value is contained in the "validStrings" array. Intended to be used in situations where the program only accepts specific values
		// Example: The user has to answer a question with only "yes" or "no", thus the "validStrings" array would be set to {"yes", "no"}
		// Note: If ValidStrings is empty, the method will accept any input (essentially the same as just using a Console.ReadLine())
		public static string ValidateString()
		{	
			do
			{
				GetCursorPosition();
				
				inputToTest = Console.ReadLine(); 
				
				if (!(Array.Exists(validStrings, element => element == inputToTest.ToLower().Trim())) && (validStrings.Length > 0)) // Checks if the input exists within the array of validStrings and if the validStrings array is empty
				// Also makes sure the inputted string is set to lowercase and has no extra spaces in the beginning and end before checking
				{
					ClearPreviousLine(inputToTest.Length); // If the array has values and the input doesn't exist in it, clear input and go back
				}
				else
				{
					break; // If the input exists in the array, or if the array is empty (which means there's no value to compare to), get out of the loop
				}
			}
			while(true);
			
			return inputToTest.Trim(); // Returns the value without the spaces, but with the proper case
		}
		
		// Sets the valid values for the method ValidateChar
		// Converts the received chars to lowercase, so the ValidateChar method works regardless of case
		public static void SetValidChars(char[] valid)
		{
			validChars = Array.ConvertAll(valid, individualValue => Char.ToLower(individualValue));
		}
		
		// Method that repeatedly asks for a char input until the inputted value is contained in the "validChars" array. Intended to be used in situations where the program should only accept specific values in a single character input (Using a Console.ReadKey(), as opposed to a Console.ReadLine() used in the previous method)
		// Example: The user has to answer with 'y' or 'n', for "yes" and "no", thus the "validChars" array would be set to {'y', 'n'}
		// Note: If validChars is empty, the method will accept any input (essentially the same as just using a Console.ReadKey())
		public static char ValidateChar()
		{
			do
			{
				GetCursorPosition();
				
				charToTest = Console.ReadKey(true).KeyChar;
				
				if (!(Array.Exists(validChars, element => element == Char.ToLower(charToTest)) && (validChars.Length > 0))) // Checks if the input exists within the array of validChars and  if the validChars is empty
				// Also makes sure to convert the input to lowercase
				{
				    	ClearPreviousLine(1);
				}
				else
				{
					break; // If the input exists in the array, or if the array is empty (which means there's no value to compare to), get out of the loop
				}
			}
			while (true);
			
			return charToTest; // Returns the value with the proper case
		}
		
		// Method that repeatedly asks for an input until the inputted value is a 32-bit integer
		public static int ValidateInt()
		{
			bool isValid = false; // Variable that stores whether the input was valid or not (it receives the boolean result from the TryParse method)
			
			do
			{
				GetCursorPosition();
				
				inputToTest = Console.ReadLine();
				isValid = int.TryParse(inputToTest, out integerToTest); // Tests if the value is a 32-bit integer (also returns the value itself to the variable "integerToTest")
				
				if (!(isValid))
				{
					ClearPreviousLine(inputToTest.Length); // If input is not valid, clear input and goes back
				}
				else
				{
					break; // If input is valid, get out of the loop
				}
			}
			while(true);
			
			return integerToTest;
		}
		
		// Method that repeatedly asks for an input until the inputted value is a 32-bit integer and is not 0
		public static int ValidateIntNotZero()
		{
			do
			{
				integerToTest = ValidateInt(); // Uses the ValidateInt method to check if the input is a 32-bit integer
				
				if (integerToTest == 0) // After confirming the input is a 32-bit integer, checks if it's equal to 0
				{
					ClearPreviousLine(inputToTest.Length); // If value is 0, clear input and goes back
				}
				else
				{
					break; // If value is a number and not 0, get out of the loop
				}
			}
			while (true);
				
			return integerToTest;
		}
		
		// Method that repeatedly asks for an input until the inputted value is a number (double variable)
		public static double ValidateDouble()
		{
			bool isValid = false; // Variable that stores whether the input was valid or not (it receives the boolean result of the TryParse method)
			
			do
			{
				GetCursorPosition();
				
				inputToTest = Console.ReadLine();
				isValid = double.TryParse(inputToTest, out numberToTest); // Tests if the value is a double (and returns the value itself into the variale "numberToTest")
				
				if (!(isValid))
				{
					ClearPreviousLine(inputToTest.Length); // If input is not valid, clear input and go back
				}
				else
				{
					break; // If input is valid, get out of the loop
				}
			}
			while(true);
			
			return numberToTest;
		}
		
		// Method that repeatedly asks for an input until the inputted value is a number (double variable) and is not 0
		public static double ValidateDoubleNotZero()
		{
			do
			{
				numberToTest = ValidateDouble(); // Uses the ValidateDouble method to check if the input is a number
				
				if (numberToTest == 0) // After confirming the input is a number, checks if it's equal to 0
				{
					ClearPreviousLine(inputToTest.Length); // If value is 0, clear input and go back
				}
				else
				{
					break; // If value is a number and is not 0, get out of the loop
				}
			}
			while(true);
			
			return numberToTest;
		}
		
		// Method that repeatedly asks for input until the inputted value has the desired length, which is defined by the parameters minBound and maxBound
		// The method is set to swap the bounds in case the minBound is bigger than the maxBound, to prevent getting stuck in an impossible validation
		// It also has a limit to the bounds, maxBound cannot be lower than 1 and minBound cannot be higher than 253
		public static string ValidateInputSize (int minBound, int maxBound)
		{
			if (minBound > maxBound) // Checks if the minBound is bigger than the maxBound. If it is, swap them around to prevent the method from breaking (since it's impossible for a number to be within the range if the minimum is higher than the maximum)
			{
				int auxBound = minBound;
				minBound = maxBound;
				maxBound = auxBound;
			}
			
			if (minBound > 253) // Makes sure the minimum accepted input size isn't higher than 253. This value was chosen because a Console.ReadLine() only accepts up to 254 characters by default, so if the minimum value was higher than 254, it would prevent any input from being made
			{
				minBound = 253;
			}
			
			if (maxBound < 1) // Makes sure the maximum accepted input size isn't lower than 1, as if it was, that would prevent any input from being made
			{
				maxBound = 1;
			}
			
			do
			{
				GetCursorPosition();
				
				inputToTest = Console.ReadLine().Trim(); // Removes spaces on the beginning and end before validation
				
				if ((inputToTest.Length < minBound) || (inputToTest.Length > maxBound)) // Checks if the length of the input is within the defined boundaries
				{
					ClearPreviousLine(inputToTest.Length); // If input length is outside of the defined boundaries, clear input and go back
				}
				else
				{
					break; // If input length is within the defined boundaries, get out of the loop
				}
				
			}
			while (true);
			
			return inputToTest.Trim(); // Returns the input without extra spaces on the beginning and end
		}
		
		// Method that repeatedly asks for numeric inputs until the inputted number is within a specified range of values, defined by the parameters minValue and maxValue
		// The method is set to swap the values in case the minValue is bigger than the maxValue, to prevent getting stuck in an impossible validation
		public static double ValidateNumericValue(double minValue, double maxValue)
		{	
			if (minValue > maxValue) // Checks if the minValue is actually bigger than the maxValue. If it is, swap them around to prevent the method from breaking (since it's impossible for a number to be within the range if the minimum is bigger than the maximum)
			{
				double auxValue = minValue;
				minValue = maxValue;
				maxValue = auxValue;
			}
			
			do
			{
				numberToTest = ValidateDouble(); // First checks if the inputted value is a numeric value
				
				if ((numberToTest < minValue) || (numberToTest > maxValue)) // Checks if the value is within the defined boundaries
				{
					ClearPreviousLine(inputToTest.Length); // If the value is outside of the defined ranges, clear input and go back
				}
				else
				{
					break; // If the value is within the defined boundaries, get out of the loop
				}
			}
			while (true);
			
			return numberToTest; 
		}
		
		// Method that repeatedly asks for input until the number entered has the correct sign
		// The bool parameter controls the sign required. If the parameter is true, only positive numbers are accepted, if it's false, only negative numbers are accepted
		public static double ValidateNumberSign (bool positiveNumber)
		{
			do
			{
				numberToTest = ValidateDouble(); // First checks if the inputted value is a numeric value
				
				if (positiveNumber) // Checks if the validation should be made for positive numbers (true) or negative numbers (false)
				{
					if (numberToTest < 0) // Checks for negative numbers, note that it includes 0
					{
						ClearPreviousLine(inputToTest.Length); // If value is negative (not valid), clear input and go back
					}
					else
					{
						break; // If value is positive (valid), get out of the loop
					}
				}
				else
				{
					if (numberToTest > 0) // Checks for positive numbers, inote that it includes 0
					{
						ClearPreviousLine(inputToTest.Length); // If value is positive (not valid), clear input and go back
					}
					else
					{
						break; // If value is negative (valid), get out of the loop
					}
				}
			}
			while (true);
			
			return numberToTest;
		}
	}
}