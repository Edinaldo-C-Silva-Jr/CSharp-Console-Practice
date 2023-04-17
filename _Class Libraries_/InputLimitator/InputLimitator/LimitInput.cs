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
	public class LimitInput
	{
		private ConsoleKeyInfo currentCharInput;
		private int inputAscii, cursorX, cursorY, minimumInputSize, maximumInputSize;
		private bool validCharacter;
		
		private void GetCursorPosition()
		{
			cursorX = Console.CursorLeft;
			cursorY = Console.CursorTop;
		}
		
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
		
		private void BeepOnInvalidInput ()
		{
			if (!(validCharacter))
			{
				SystemSounds.Beep.Play();
			}
			validCharacter = false;
			
		}
		
		private bool TestEnter(string full)
		{
			if (inputAscii == 13)
			{
				if (full.Length >= minimumInputSize)
				{
					validCharacter = true;
					return true;
				}
			}
			return false;
		}
		
		private string TestBackspace(string full)
		{
			if (inputAscii == 8)
			{
				if (full.Length > 0)
				{
					full = full.Substring(0, full.Length - 1);
					Console.SetCursorPosition(cursorX, cursorY);
					Console.Write(new String(' ', full.Length + 1));
					validCharacter = true;
				}
			}
			
			return full;
		}
		
		public string LimitInputAll(int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput);
				fullInput = TestBackspace(fullInput);
				
				if ((inputAscii > 31 && inputAscii < 127) && (fullInput.Length < maximumInputSize))
				{
					fullInput += currentCharInput.KeyChar;
					validCharacter = true;
				}
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while(!(enterPressed));
			
			return fullInput;
		}
		
		public string LimitInputAll (int maxInputSize)
		{
			return LimitInputAll(0, maxInputSize);
		}
		
		public double LimitInputNumberOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput);
				fullInput = TestBackspace(fullInput);
				
				if ((inputAscii > 47 && inputAscii < 58) && (fullInput.Length < maximumInputSize))
				{
					fullInput += currentCharInput.KeyChar;
					validCharacter = true;
				}
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!(enterPressed));
			
			if (fullInput.Length == 0)
			{
				fullInput += "0";
			}
			
			return double.Parse(fullInput);
		}
		
		public double LimitInputNumberOnly (int maxInputSize)
		{
			return LimitInputNumberOnly(0, maxInputSize);
		}
		
		public string LimitInputLetterOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(minInputSize, maxInputSize);
			
			string fullInput = "";
			bool enterPressed = false;
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				enterPressed = TestEnter(fullInput);
				fullInput = TestBackspace(fullInput);
				
				if (((inputAscii > 64 && inputAscii < 91) || (inputAscii > 96 && inputAscii < 124)) && (fullInput.Length < maximumInputSize))
				{
					fullInput += currentCharInput.KeyChar;
					validCharacter = true;
				}
				
				BeepOnInvalidInput();
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!(enterPressed));
			
			return fullInput;
		}
		
		public string LimitInputLetterOnly (int maxInputSize)
		{
			return LimitInputLetterOnly(0, maxInputSize);
		}
	}
}