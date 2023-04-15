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
		private int inputAscii, cursorX, cursorY, maximumInputSize, minimumInputSize;
		
		private void GetCursorPosition()
		{
			cursorX = Console.CursorLeft;
			cursorY = Console.CursorTop;
		}
		
		private void AssignInputSizes(int max, int min)
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
		
		private bool TestEnter(string full)
		{
			if (inputAscii == 13)
			{
				if (full.Length > minimumInputSize)
				{
					return true;
				}
				else
				{
					SystemSounds.Beep.Play();
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
				}
				else
				{
					SystemSounds.Beep.Play();
				}
			}
			
			return full;
		}
		
		public string LimitInputAll(int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(maxInputSize, minInputSize);
			
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
				}
				
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while(!(enterPressed));
			
			return fullInput;
		}
		
		public double LimitInputNumberOnly (int minInputSize, int maxInputSize)
		{
			GetCursorPosition();
			AssignInputSizes(maxInputSize, minInputSize);
			
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
				}
				
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while (!(enterPressed));
			
			return double.Parse(fullInput);
		}
		
		public double LimitInputNumberOnly (int maxInputSize)
		{
			return LimitInputNumberOnly(maxInputSize, 0);
		}
	}
}