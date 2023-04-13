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
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class LimitInput
	{
		private string fullInput = "";
		private ConsoleKeyInfo currentCharInput;
		private int inputAscii, cursorX, cursorY;
		
		public double LimitInputNumberOnly (int maxInputSize, int minInputSize)
		{	
			cursorX = Console.CursorLeft;
			cursorY = Console.CursorTop;
			
			if (maxInputSize < minInputSize)
			{
				int auxInput = minInputSize;
				minInputSize = maxInputSize;
				maxInputSize = auxInput;
			}
			
			do
			{
				currentCharInput = Console.ReadKey(true);
				inputAscii = (int)currentCharInput.KeyChar;
				
				if (inputAscii == 13)
				{
					if (fullInput.Length < minInputSize)
					{
						SystemSounds.Beep.Play();
					}
				}
				else
				{
					if (inputAscii == 8)
					{
						if (fullInput.Length > 0)
						{
							fullInput = fullInput.Substring(0, fullInput.Length - 1);
							Console.SetCursorPosition(cursorX, cursorY);
							Console.Write(new String(' ', fullInput.Length + 1));
						}
						else
						{
							SystemSounds.Beep.Play();
						}
					}
					else
					{
						if ((inputAscii > 47 && inputAscii < 58) && (fullInput.Length < maxInputSize))
						{
							fullInput += currentCharInput.KeyChar;
						}
						else
						{
							SystemSounds.Beep.Play();
						}
					}
				}
				
				Console.SetCursorPosition(cursorX, cursorY);
				Console.Write(fullInput);
			}
			while ((currentCharInput.Key != ConsoleKey.Enter) || (fullInput.Length < minInputSize));
			
			return double.Parse(fullInput);
		}
		
	}
}