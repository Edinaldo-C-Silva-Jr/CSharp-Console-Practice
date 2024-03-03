/*
 * Date: 22/02/2024
 * Time: 23:14
 */
using System;
using Ex08_OrientacaoObjeto_Drone.Drone.Arms;

namespace Ex08_OrientacaoObjeto_Drone
{
	/// <summary>
	/// A menu to handle all the interactions with the Drone Arms. It provides a visual interface for using all functionalities of the Drone's arms.
	/// </summary>
	public class ArmControlMenu
	{
		/// <summary>
		/// The position of the currently selected option in the menu, relative to the other options.
		/// This is not the absolute screen position, but a way to keep track of which option is currently chosen.
		/// </summary>
		private int VerticalPosition { get; set; }
		
		/// <summary>
		/// Whether the currently chosen option is for the right arm (true) or left arm (false)
		/// </summary>
		private bool RightSide { get; set; }
		
		/// <summary>
		/// Default constructor, selects the default first option.
		/// </summary>
		public ArmControlMenu()
		{
			VerticalPosition = 0;
			RightSide = false;
		}
		
		#region Drawing the Menu
		/// <summary>
		/// Draws all the relevant states for the Drone arms.
		/// </summary>
		/// <param name="left">The Drone's Left Arm.</param>
		/// <param name="right">The Drone's Right Arm.</param>
		private void DrawArmStates(LeftDroneArm left, RightDroneArm right)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- BRAÇOS ---");
			
			Console.SetCursorPosition(15, 1);
			Console.Write("- ESQUERDO -");
			Console.SetCursorPosition(15, 2);
			Console.Write("Estado: ");
			WriteColoredText(left.GetArmState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(15, 3);
			Console.Write("Cotovelo: ");
			WriteColoredText(left.GetElbowState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(15, 4);
			Console.Write("Ângulo do Pulso: ");
			WriteColoredText(left.WristAngle.ToString(), ConsoleColor.Cyan);
			
			Console.SetCursorPosition(45, 1);
			Console.Write("- DIREITO -");
			Console.SetCursorPosition(45, 2);
			Console.Write("Estado: ");
			WriteColoredText(right.GetArmState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 3);
			Console.Write("Cotovelo: ");
			WriteColoredText(right.GetElbowState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 4);
			Console.Write("Ângulo do Pulso: ");
			WriteColoredText(right.WristAngle.ToString(), ConsoleColor.Cyan);
		}
		
		/// <summary>
		/// Draws all the menu options on screen.
		/// </summary>
		private void DrawArmOptions()
		{
			Console.SetCursorPosition(33, 6);
			Console.Write("--- CONTROLES ---");
			
			Console.SetCursorPosition(15, 7);
			Console.Write("Mudar Estado Cotovelo");
			Console.SetCursorPosition(15, 8);
			Console.Write("Girar 5º horário");
			Console.SetCursorPosition(15, 9);
			Console.Write("Girar 5º antihorário");
			Console.SetCursorPosition(15, 10);
			Console.Write("Definir Ângulo");
			Console.SetCursorPosition(15, 11);
			Console.Write("Pegar / Soltar Objeto");
			Console.SetCursorPosition(15, 12);
			Console.Write("Armazenar Objeto");
			Console.SetCursorPosition(15, 13);
			Console.Write("Bater com Martelo");
			
			Console.SetCursorPosition(45, 7);
			Console.Write("Mudar Estado Cotovelo");
			Console.SetCursorPosition(45, 8);
			Console.Write("Girar 5º horário");
			Console.SetCursorPosition(45, 9);
			Console.Write("Girar 5º antihorário");
			Console.SetCursorPosition(45, 10);
			Console.Write("Definir Ângulo");
			Console.SetCursorPosition(45, 11);
			Console.Write("Pegar / Soltar Objeto");
			Console.SetCursorPosition(45, 12);
			Console.Write("Armazenar Objeto");
			Console.SetCursorPosition(45, 13);
			Console.Write("Cortar com tesoura");
			Console.SetCursorPosition(45, 14);
			Console.Write("Coletar com a Pá");
			
			Console.SetCursorPosition(15, 16);
			Console.Write("Desativar braços e voltar ao corpo do Drone");
			
			Console.SetCursorPosition(15, 23);
			Console.Write("Setas: Mover     Enter: Escolher");
		}
		
		/// <summary>
		/// Draws the Drone Arm Menu, which includes drawing the drone states, the options and the cursor.
		/// </summary>
		/// <param name="left">The Drone's Left Arm.</param>
		/// <param name="right">The Drone's Right Arm.</param>
		private void DrawArmsMenu(LeftDroneArm left, RightDroneArm right)
		{
			Console.Clear();
			DrawArmStates(left, right);
			DrawArmOptions();
			DrawSelectionCursor('>');
		}
		
		/// <summary>
		/// Draws the selection cursor in the currently selected option.
		/// </summary>
		/// <param name="cursor">The symbol to use for the cursor.</param>
		private void DrawSelectionCursor(char cursor)
		{
			if (VerticalPosition == 8)
			{
				// If the cursor is at the bottom, there's only one possible cursor position.
				Console.SetCursorPosition(13, 16);
				Console.Write(cursor);
			}
			else
			{
				// Otherwise, the cursor position depends on the current vertical position, as well as whether the option is on the left or right side.
				Console.SetCursorPosition(13 + (30 * Convert.ToInt32(RightSide)), 7 + VerticalPosition); 
				Console.Write(cursor);
			}
		}
		#endregion
		
		#region Menu Movement
		/// <summary>
		/// Moves the selected option to the one above.
		/// </summary>
		/// <param name="currentOption">The currently selected option.</param>
		/// <returns>The newly selected option.</returns>
		private int MoveSelectionUp(int currentOption)
		{
			if (VerticalPosition == 0)
			{
				return currentOption; // If already at the top, can't move up any further
			}
			
			DrawSelectionCursor(' '); // Erases the cursor on its current position.
			
			if (VerticalPosition == 8) // If the cursor is at the bottom...
			{
				if (RightSide) // And the selected option is on the right side...
				{
					VerticalPosition--; // Move to the last option on the right.
					currentOption = 14;
				}
				else // Otherwise, if the selected option is on the left side...
				{
					VerticalPosition -= 2; // Move to the last option on the left.
					currentOption = 6;
				}
			}
			else
			{
				currentOption--; // Otherwise just go up.
				VerticalPosition--;
			}
			
			DrawSelectionCursor('>'); // Then redraws the cursor.
			return currentOption;
		}
		
		/// <summary>
		/// Moves the selected option to the one below.
		/// </summary>
		/// <param name="currentOption">The currently selected option.</param>
		/// <returns>The newly selected option.</returns>
		private int MoveSelectionDown(int currentOption)
		{
			if (VerticalPosition == 8) // If already at the bottom, can't go down any further.
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (VerticalPosition == 6 && !RightSide) // If the current option is the last option of the left side...
			{
				VerticalPosition = 8; // Need to go down 2 options
				currentOption = 15;
			}
			else
			{
				VerticalPosition++; // Otherwise just go down.
				currentOption++;
			}
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		/// <summary>
		/// Moves the selected option to the left side.
		/// </summary>
		/// <param name="currentOption">The currently selected option.</param>
		/// <returns>The newly selected option.</returns>
		private int MoveSelectionLeft(int currentOption)
		{
			if (VerticalPosition == 8) // If at the bottom, there's no left or right option to go to.
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (RightSide) // Only move if currently on the right.
			{
				if (VerticalPosition == 7) // If currently at the last option of the right side...
				{
					currentOption -= 8; // Need to go up once, since there's less options on the left.
					VerticalPosition = 6;
				}
				else
				{
					currentOption -= 7; // Otherwise just go left.
				}
			}
			RightSide = false;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		/// <summary>
		/// Moves the selected option to the right side..
		/// </summary>
		/// <param name="currentOption">The currently selected option.</param>
		/// <returns>The newly selected option.</returns>
		private int MoveSelectionRight(int currentOption)
		{
			if (VerticalPosition == 8) // If at the bottom, there's no left or right option to go to.
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if(!RightSide) // Only go right if not already on the right.
			{
				currentOption += 7;
			}
			RightSide = true;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		#endregion
		
		/// <summary>
		/// Shows the message related to the Drone's last action.
		/// </summary>
		/// <param name="success">Whether the drone arm action was successful or not, which defines the message color.</param>
		/// <param name="message">The message to show.</param>
		private void ShowMessage(bool success, string message)
		{
			Console.SetCursorPosition(15, 18);
			Console.Write(new String(' ', 200)); // Clears the screen of previous messages.
			
			Console.SetCursorPosition(15, 18);
			
			if (success)
			{
				WriteColoredText(message, ConsoleColor.Green);
			}
			else
			{
				WriteColoredText(message, ConsoleColor.Red);
			}
		}
		
		/// <summary>
		/// Writes the desired text using a specific color, then restores the console's default color.
		/// </summary>
		/// <param name="text">The text to be written in color.</param>
		/// <param name="color">The color to write the text in.</param>
		private void WriteColoredText(string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		
		/// <summary>
		/// Receivs the input for the arm wrist angle.
		/// </summary>
		/// <returns>The value entered for the angle, or -1 if the input is not a valid number.</returns>
		private int ArmValueInput()
		{
			Console.SetCursorPosition(15, 18);
			Console.Write(new String(' ', 200)); // Clears the screen from any messages.
			
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 18);
			Console.Write("Digite o novo valor para o Ângulo: ");
			
			double value; // Uses a double as input so decimals aren't counted as invalid.
			bool successConvert = double.TryParse(Console.ReadLine(), out value);
			if (successConvert)
			{
				return (int)value; // Only return the integer part of the number.
			}
			else
			{
				return -1; // Returns -1 to represent an invalid angle value.
			}
		}
		
		/// <summary>
		/// Handles the execution of all Enter related actions.
		/// </summary>
		/// <param name="menuOption">The currently selected option in the menu.</param>
		/// <param name="leftArm">The Drone's Left Arm.</param>
		/// <param name="rightArm">The Drone's Right Arm.</param>
		private void EnterKeySelection(int menuOption, LeftDroneArm leftArm, RightDroneArm rightArm)
		{
			bool success = true;
			switch (menuOption)
			{
				case 0:
					leftArm.ChangeElbowState();
					break;
				case 1:
					leftArm.ChangeWristAngle(true);
					break;
				case 2:
					leftArm.ChangeWristAngle(false);
					break;
				case 3:
					success = leftArm.ChangeWristAngle(ArmValueInput());
					break;
				case 4:
					success = leftArm.TakeReleaseObject();
					break;
				case 5:
					success = leftArm.StoreObject();
					break;
				case 6:
					success = leftArm.HitObject();
					break;
				case 7:
					rightArm.ChangeElbowState();
					break;
				case 8:
					rightArm.ChangeWristAngle(true);
					break;
				case 9:
					rightArm.ChangeWristAngle(false);
					break;
				case 10:
					success = rightArm.ChangeWristAngle(ArmValueInput());
					break;
				case 11:
					success = rightArm.TakeReleaseObject();
					break;
				case 12:
					success = rightArm.StoreObject();
					break;
				case 13:
					success = rightArm.CutObject();
					break;
				case 14:
					success = rightArm.CollectObject();
					break;
				case 15:
					success = DeactivateArms(leftArm, rightArm);
					break;
			}
			
			DrawArmsMenu(leftArm, rightArm);
			
			if (RightSide)
			{
				ShowMessage(success, rightArm.GetMessage());
			}
			else
			{
				ShowMessage(success, leftArm.GetMessage());
			}
			
		}
		
		/// <summary>
		/// Handles the deactivation of the Drone Arms, which returns them to Resting state and finishes this menu.
		/// In order for this to succeed, both arms need to deactivate.
		/// </summary>
		/// <param name="left">The Drone's Left Arm.</param>
		/// <param name="right">The Drone's Right Arm.</param>
		/// <returns>Whether the arms were deactivated or not.</returns>
		private bool DeactivateArms(LeftDroneArm left, RightDroneArm right)
		{
			bool deactivated = true;
			
			if (!left.DeactivateArm()) // If the arm wasn't deactivated...
			{
				deactivated = false; // This methods fails...
				RightSide = false; // Give the selection to the side that failed to activate.
			}
			if (!right.DeactivateArm())
			{
				deactivated = false;
				RightSide = true; // Give the selection to the side that failed to activate.
			}
			
			if (!deactivated) // If any arm failed to deactivate, make sure they're both still active, otherwise one of them would become unusable.
			{
				left.ActivateArm();
				right.ActivateArm();
			}
			
			return deactivated;
		}
		
		/// <summary>
		/// Starts the menu.
		/// </summary>
		/// <param name="leftArm">The Drone's Left Arm.</param>
		/// <param name="rightArm">The Drone's Right Arm.</param>
		public void Start(LeftDroneArm leftArm, RightDroneArm rightArm)
		{
			leftArm.ActivateArm();
			rightArm.ActivateArm();
			
			int menuOption = 0;
			ConsoleKeyInfo menuInput;
			
			DrawArmsMenu(leftArm, rightArm);
			
			do
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0,0);
				menuInput = Console.ReadKey(true);
				
				switch(menuInput.Key)
				{
					case ConsoleKey.UpArrow:
						menuOption = MoveSelectionUp(menuOption);
						break;
					case ConsoleKey.DownArrow:
						menuOption = MoveSelectionDown(menuOption);
						break;
					case ConsoleKey.LeftArrow:
						menuOption = MoveSelectionLeft(menuOption);
						break;
					case ConsoleKey.RightArrow:
						menuOption = MoveSelectionRight(menuOption);
						break;
					case ConsoleKey.Enter:
						EnterKeySelection(menuOption, leftArm, rightArm);
						break;
				}
			}
			while(leftArm.GetArmState() != "Inativo" || rightArm.GetArmState() != "Inativo");
		}
	}
}
