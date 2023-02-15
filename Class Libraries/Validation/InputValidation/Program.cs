/*
 * Date: 15/02/2023
 * Time: 01:17
*/
using System;

namespace InputValidation
{
	// Class created to provide methods that validade inputs for console applications
	// These methods ensure the inputted value will be in the desired format in order to avoid parsing errors
	public class ValidateInput
	{
		// String that contains the values which are considered valid
		// Used in the method ValidInput()
		private static string[] validValues = new string[] {};
		private static int cursorX, cursorY;
		private static string input;
		
		// Method that clears the previous line of the console.
		// Intended to be used with the validation methods to keep the cursor in place while repeatedly asking for inputs
		public static void ClearPreviousLine(int inputLength)
		{
			Console.SetCursorPosition(cursorX, cursorY);
 			Console.Write(new string(' ', inputLength));
 			Console.SetCursorPosition(cursorX, cursorY);
		}
		
		// Method that repeatedly asks for an input until the inputted value is an int
		public static int ValidInt()
		{
			int valid = 0;
			bool isValid = false;
			
			do
			{
				cursorX = Console.CursorLeft;
				cursorY = Console.CursorTop;
				
				input = Console.ReadLine();
				isValid = int.TryParse(input, out valid);
				
				if (!(isValid))
				{
					ClearPreviousLine(input.Length);
				}
				else
				{
					break;
				}
			}
			while(true);
			
			return valid;
		}
		
		// Method that repeatedly asks for an input until the inputted value is a double
		public static double ValidDouble()
		{
			double valid = 0;
			bool isValid = false;
			
			do
			{
				cursorX = Console.CursorLeft;
				cursorY = Console.CursorTop;
				
				input = Console.ReadLine();
				isValid = double.TryParse(input, out valid);
				
				if (!(isValid))
				{
					ClearPreviousLine(input.Length);
				}
				else
				{
					break;
				}
			}
			while(true);
			
			return valid;
		}
		
		// Method that repeatedly asks for an input until the inputted value is contained in the "validValues" array
		// This is intended to use in specific situations that only accept specific values
		// Example: The user has to answer a question with only "yes" or "no", thus the "validValues" array would be set to {"yes", "no"}
		// Note: If ValidValues is empty, the method will consider any input to be valid (essentially the same as just using a Console.ReadLine())
		public static string ValidInput()
		{		
			do
			{
				cursorX = Console.CursorLeft;
				cursorY = Console.CursorTop;
				
				input = Console.ReadLine().ToLower();
				
				if (!(Array.Exists(validValues, element => element == input)) && (validValues.Length > 0))
				{
					ClearPreviousLine(input.Length);
				}
				else
				{
					break;
				}
			}
			while(true);
			
			return input;
		}
		
		// Sets the valid value for the above method
		public static void SetValidValues(string[] valid)
		{
			validValues = valid;
		}
	}
}