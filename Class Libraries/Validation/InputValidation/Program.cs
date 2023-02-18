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
		private static string[] validValues = new string[] {}; // String that contains the values which are considered valid - Used in the method ValidInput()
		private static int cursorX, cursorY; 
		private static string inputToTest; 
		
		// Method that clears the previous line of the console.
		// Intended to be used with the validation methods to keep the cursor in place while repeatedly asking for inputs
		public static void ClearPreviousLine(int inputLength)
		{
			Console.SetCursorPosition(cursorX, cursorY); // Sets the cursor back to the position recorded before the input
 			Console.Write(new string(' ', inputLength)); // Builds a string of blank spaces to erase previous input
 			Console.SetCursorPosition(cursorX, cursorY);
		}
		
		// Method that repeatedly asks for an input until the inputted value is an int
		public static int ValidInt()
		{
			int valid = 0; // Value to be returned as a valid int
			bool isValid = false;
			
			do
			{
				cursorX = Console.CursorLeft; // Records cursor's current position
				cursorY = Console.CursorTop;
				
				inputToTest = Console.ReadLine();
				isValid = int.TryParse(inputToTest, out valid); // Tests if the value is an int (also returns the value itself to the variable "valid")
				
				if (!(isValid))
				{
					ClearPreviousLine(inputToTest.Length); // If value is not valid, clear input and goes back
				}
				else
				{
					break; // If valid, get out of the loop
				}
			}
			while(true);
			
			return valid;
		}
		
		// Method that repeatedly asks for an input until the inputted value is a double
		public static double ValidDouble()
		{
			double valid = 0; // Value to be returned as a valid double
			bool isValid = false;
			
			do
			{
				cursorX = Console.CursorLeft; // Records cursor's current position
				cursorY = Console.CursorTop;
				
				inputToTest = Console.ReadLine();
				isValid = double.TryParse(inputToTest, out valid); // Tests if the value is a double (and returns the value into the variale "valid")
				
				if (!(isValid))
				{
					ClearPreviousLine(inputToTest.Length); // If value is not valid, clear input and go back
				}
				else
				{
					break; // If value is valid, get out of the loop
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
				cursorX = Console.CursorLeft; // Records cursor's current position
				cursorY = Console.CursorTop;
				
				inputToTest = Console.ReadLine(); 
				
				if (!(Array.Exists(validValues, element => element == inputToTest.ToLower().Trim())) && (validValues.Length > 0)) // Checks if the input exists within the array of ValidValues and if the array has values
				// Also makes sure the inputted string is set to lowercase and has no extra spaces in the beginning and end before checking
				{
					ClearPreviousLine(inputToTest.Length); // If input is not valid, clear input and go back
				}
				else
				{
					break; // If input is valid or if ValidValues is empty, get out of the loop
				}
			}
			while(true);
			
			return inputToTest.Trim(); // Returns the value without the spaces, but with the proper case
		}
		
		// Sets the valid value for the above method
		// Note: Since ValidInput sets the inputted value to lowercase, the values inserted into this should also be lowercase, otherwise the comparison will fail
		public static void SetValidValues(string[] valid)
		{
			validValues = valid;
		}
	}
}