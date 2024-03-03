/*
 * Date: 18/02/2024
 * Time: 19:59
 */
using System;
using System.Collections.Generic;
using Ex08_OrientacaoObjeto_Drone.Drone.Body;

namespace Ex08_OrientacaoObjeto_Drone
{
	public class DroneControlMenu
	{
		#region Drawing the Menu
		/// <summary>
		/// Draws all the relevant states for the Drone.
		/// </summary>
		/// <param name="drone">The drone.</param>
		private void DrawDroneStates(DroneBody drone)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- DRONE ---");
			Console.SetCursorPosition(15, 1);
			Console.Write("Altura: ");
			WriteColoredText(drone.Height.ToString(), ConsoleColor.Cyan);
			Console.SetCursorPosition(15, 2);
			Console.Write("Ângulo: ");
			WriteColoredText(drone.Angle.ToString(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 1);
			Console.Write("Velocidade: ");
			WriteColoredText(drone.Speed.ToString(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 2);
			Console.Write("Movimento: ");
			WriteColoredText(drone.GetMovementState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(25, 3);
			WriteColoredText(drone.GetApproachedObject(), ConsoleColor.Cyan);
		}
		
		/// <summary>
		/// Draws all the menu options on screen.
		/// </summary>
		private void DrawDroneOptions()
		{
			Console.SetCursorPosition(33, 5);
			Console.Write("--- CONTROLES ---");
			
			Console.SetCursorPosition(15, 6);
			Console.Write("Subir 0.5 metros");
			Console.SetCursorPosition(15, 7);
			Console.Write("Descer 0.5 metros");
			Console.SetCursorPosition(15, 8);
			Console.Write("Definir Altura");
			
			Console.SetCursorPosition(15, 9);
			Console.Write("Girar 5º horário");
			Console.SetCursorPosition(15, 10);
			Console.Write("Girar 5º antihorário");
			Console.SetCursorPosition(15, 11);
			Console.Write("Definir Ângulo");
			
			Console.SetCursorPosition(15, 12);
			Console.Write("Acelerar 0.5 m/s");
			Console.SetCursorPosition(15, 13);
			Console.Write("Desacelerar 0.5 m/s");
			Console.SetCursorPosition(15, 14);
			Console.Write("Definir Velocidade");
			
			Console.SetCursorPosition(15, 15);
			Console.Write("Aproximar de um objeto");
			Console.SetCursorPosition(15, 16);
			Console.Write("Distanciar do objeto");
			
			Console.SetCursorPosition(15, 17);
			Console.Write("Acessar os Braços");
			
			Console.SetCursorPosition(15, 23);
			Console.Write("Setas: Mover     Enter: Escolher     Esc: Sair");
		}
		
		/// <summary>
		/// Draws the Drone menu, which includes the drone states, options and the cursor.
		/// </summary>
		/// <param name="drone">The drone itself.</param>
		/// <param name="option">The currently selected option</param>
		private void DrawDroneMenu(DroneBody drone, int option)
		{
			Console.Clear();
			DrawDroneStates(drone);
			DrawDroneOptions();
			DrawSelectionCursor('>', option);
		}
		
		/// <summary>
		/// Draws the selection cursor in the currently selected option.
		/// </summary>
		/// <param name="cursor">The symbol to use for the cursor.</param>
		private void DrawSelectionCursor(char cursor, int option)
		{
			Console.SetCursorPosition(13, 6 + option);
			Console.Write(cursor);
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
			if (currentOption == 0)
			{
				return 0;
			}
			
			DrawSelectionCursor(' ', currentOption);
			currentOption--;
			DrawSelectionCursor('>', currentOption);
			return currentOption;
		}
		
		/// <summary>
		/// Moves the selected option to the one below.
		/// </summary>
		/// <param name="currentOption">The currently selected option.</param>
		/// <returns>The newly selected option.</returns>
		private int MoveSelectionDown(int currentOption)
		{
			if (currentOption == 11)
			{
				return 11;
			}
			
			DrawSelectionCursor(' ', currentOption);
			currentOption++;
			DrawSelectionCursor('>', currentOption);
			return currentOption;
		}
		#endregion
		
		/// <summary>
		/// Shows the message related to the Drone's last action.
		/// </summary>
		/// <param name="success">Whether the drone's action was successful or not, which defines the message color.</param>
		/// <param name="message">The message to show.</param>
		private void ShowMessage(bool success, string message)
		{
			Console.SetCursorPosition(15, 19);
			Console.Write(new String(' ', 200)); // Clears the screen of previous messages.
			
			Console.SetCursorPosition(15, 19);
			
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
		/// Receives the input for the drone's numeric properties.
		/// </summary>
		/// <param name="property">The name of the property, which will be displayed on the screen.</param>
		/// <returns>The value entered for the property, or -1 if the input is not a valid number.</returns>
		private double DroneValueInput(string property)
		{
			Console.SetCursorPosition(15, 19);
			Console.Write(new String(' ', 200));
			
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 19);
			Console.Write("Digite o novo valor para {0}: " , property);
			
			double value;
			bool successConvert = double.TryParse(Console.ReadLine(), out value);
			if (successConvert)
			{
				return value;
			}
			else
			{
				return -1;
			}
		}
		
		/// <summary>
		/// Handles the execution of all Enter related actions.
		/// </summary>
		/// <param name="drone">The drone.</param>
		/// <param name="menuOption">The currently selected menu option.</param>
		private void EnterKeySelection(DroneBody drone, int menuOption)
		{
			bool success = true;
			switch (menuOption)
			{
				case 0:
					success = drone.ChangeHeight(true);
					break;
				case 1:
					success = drone.ChangeHeight(false);
					break;
				case 2:
					success = drone.ChangeHeight(DroneValueInput("Altura"));
					break;
				case 3:
					success = drone.ChangeAngle(true);
					break;
				case 4:
					success = drone.ChangeAngle(false);
					break;
				case 5:
					success = drone.ChangeAngle((int)DroneValueInput("Ângulo"));
					break;
				case 6:
					success = drone.ChangeSpeed(true);
					break;
				case 7:
					success = drone.ChangeSpeed(false);
					break;
				case 8:
					success = drone.ChangeSpeed(DroneValueInput("Velocidade"));
					break;
				case 9:
					success = drone.ApproachObject();
					break;
				case 10:
					success = drone.DistanceFromObject();
					break;
				case 11:
					success = drone.AccessDroneArms();
					break;
			}
			DrawDroneMenu(drone, menuOption);
			ShowMessage(success, drone.GetMessage());
		}
		
		/// <summary>
		/// Handles the deactivation of the Drone, to close the application.
		/// </summary>
		private void DeactivateDrone()
		{
			Console.Clear();
			Console.SetCursorPosition(30, 10);
			Console.Write("Desligando Drone...");
			Console.SetCursorPosition(24, 11);
			Console.Write("Pressione Enter para encerrar...");
			Console.ReadLine();
		}
		
		/// <summary>
		/// Starts the menu.
		/// </summary>
		public void Start()
		{
			DroneBody drone = new DroneBody();
			
			int menuOption = 0;
			ConsoleKeyInfo menuInput;
			
			DrawDroneMenu(drone, menuOption);
			
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
					case ConsoleKey.Enter:
						EnterKeySelection(drone, menuOption);
						break;
					case ConsoleKey.Escape:
						DeactivateDrone();
						break;
				}
			}
			while(menuInput.Key != ConsoleKey.Escape);
		}
	}
}
