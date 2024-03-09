/*
 * Date: 09/03/2024
 * Time: 13:08
*/
using System;
using Ex08_OrientacaoObjeto_Drone.Drone.Camera;

namespace Ex08_OrientacaoObjeto_Drone
{
	/// <summary>
	/// A menu to handle all the interactions with the Drone Camera. It provides a visual interface for using all functionalities of the Drone's camera.
	/// </summary>
	public class CameraControlMenu
	{
		#region Drawing the Menu
		/// <summary>
		/// Draws all the relevant states for the Camera.
		/// </summary>
		/// <param name="camera">The drone's camera.</param>
		private void DrawCameraStates(DroneCamera camera)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- CÂMERA ---");
			Console.SetCursorPosition(15, 1);
			Console.Write("Ângulo Horizontal: ");
			WriteColoredText(camera.HorizontalAngle.ToString(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 1);
			Console.Write("Ângulo Vertical: ");
			WriteColoredText(camera.VerticalAngle.ToString(), ConsoleColor.Cyan);
			Console.SetCursorPosition(25, 2);
			Console.Write("Modo Atual: ");
			WriteColoredText(camera.GetCameraMode(), ConsoleColor.Cyan);
		}
		
		/// <summary>
		/// Draws all the menu options on screen.
		/// </summary>
		private void DrawCameraOptions()
		{
			Console.SetCursorPosition(33, 4);
			Console.Write("--- CONTROLES ---");
			
			Console.SetCursorPosition(15, 5);
			Console.Write("Virar 5º horário");
			Console.SetCursorPosition(15, 6);
			Console.Write("Virar 5º antihorário");
			Console.SetCursorPosition(15, 7);
			Console.Write("Definir Ângulo Horizontal");
			
			Console.SetCursorPosition(15, 8);
			Console.Write("Inclinar 5º horário");
			Console.SetCursorPosition(15, 9);
			Console.Write("Inclinar 5º antihorário");
			Console.SetCursorPosition(15, 10);
			Console.Write("Definir Ângulo Vertical");
			
			Console.SetCursorPosition(15, 11);
			Console.Write("Mudar modo de câmera");
			Console.SetCursorPosition(15, 12);
			Console.Write("Tirar foto");
			Console.SetCursorPosition(15, 13);
			Console.Write("Gravar / Parar vídeo");
			
			Console.SetCursorPosition(15, 14);
			Console.Write("Desligar a câmera e voltar ao Drone");
			
			Console.SetCursorPosition(15, 23);
			Console.Write("Setas: Mover     Enter: Escolher     Esc: Sair");
		}
		
		/// <summary>
		/// Draws the Camera menu, which includes the camera states, options and the cursor.
		/// </summary>
		/// <param name="camera">The drone's camera.</param>
		/// <param name="option">The currently selected option</param>
		private void DrawCameraMenu(DroneCamera camera, int option)
		{
			Console.Clear();
			DrawCameraStates(camera);
			DrawCameraOptions();
			DrawSelectionCursor('>', option);
		}
		
		/// <summary>
		/// Draws the selection cursor in the currently selected option.
		/// </summary>
		/// <param name="cursor">The symbol to use for the cursor.</param>
		private void DrawSelectionCursor(char cursor, int option)
		{
			Console.SetCursorPosition(13, 5 + option);
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
			if (currentOption == 9)
			{
				return 9;
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
		/// <param name="success">Whether the drone camera action was successful or not, which defines the message color.</param>
		/// <param name="message">The message to show.</param>
		private void ShowMessage(bool success, string message)
		{
			Console.SetCursorPosition(15, 16);
			Console.Write(new String(' ', 200)); // Clears the screen of previous messages.
			
			Console.SetCursorPosition(15, 16);
			
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
		/// Receives the input for the camera's angle properties.
		/// </summary>
		/// <returns>The value entered for the angle, or -1 if the input is not a valid number.</returns>
		private int CameraValueInput()
		{
			Console.SetCursorPosition(15, 16);
			Console.Write(new String(' ', 200)); // Clears the screen from any messages.
			
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 16);
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
		/// <param name="camera">The drone's camera.</param>
		/// <param name="menuOption">The currently selected menu option.</param>
		private void EnterKeySelection(DroneCamera camera, int menuOption)
		{
			bool success = true;
			switch (menuOption)
			{
				case 0:
					camera.ChangeHorizontalAngle(true);
					break;
				case 1:
					camera.ChangeHorizontalAngle(false);
					break;
				case 2:
					success = camera.ChangeHorizontalAngle(CameraValueInput());
					break;
				case 3:
					camera.ChangeVerticalAngle(true);
					break;
				case 4:
					camera.ChangeVerticalAngle(false);
					break;
				case 5:
					success = camera.ChangeVerticalAngle(CameraValueInput());
					break;
				case 6:
					success = camera.ChangeCameraMode();
					break;
				case 7:
					success = camera.TakePicture();
					break;
				case 8:
					success = camera.ToggleRecordingVideo();
					break;
				case 9:
					success = camera.DeactivateCamera();
					break;
			}
			DrawCameraMenu(camera, menuOption);
			ShowMessage(success, camera.GetMessage());
		}
		
		/// <summary>
		/// Starts the menu.
		/// </summary>
		public void Start(DroneCamera camera)
		{
			camera.ActivateCamera();
			int menuOption = 0;
			ConsoleKeyInfo menuInput;
			
			DrawCameraMenu(camera, menuOption);
			
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
						EnterKeySelection(camera, menuOption);
						break;
				}
			}
			while(camera.GetCameraMode() != "Inativo.");
		}
	}
}
