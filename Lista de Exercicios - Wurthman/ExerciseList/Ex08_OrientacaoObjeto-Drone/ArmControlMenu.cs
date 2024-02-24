/*
 * Date: 22/02/2024
 * Time: 23:14
 */
using System;
using Ex08_OrientacaoObjeto_Drone.Drone;

namespace Ex08_OrientacaoObjeto_Drone
{
	public class ArmControlMenu
	{
		private int verticalPosition { get; set; }
		private bool RightSide { get; set; }
		
		public ArmControlMenu()
		{
			verticalPosition = 0;
			RightSide = false;
		}
		
		private void DrawArmStates(LeftDroneArm left, RightDroneArm right)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- BRAÇOS ---");
			
			Console.SetCursorPosition(15, 1);
			Console.Write("- ESQUERDO -");
			Console.SetCursorPosition(15, 2);
			Console.Write("Estado: " + left.State);
			Console.SetCursorPosition(15, 3);
			Console.Write("Cotovelo: " + left.Elbow);
			Console.SetCursorPosition(15, 4);
			Console.Write("Ângulo do Pulso: " + left.WristAngle);
			
			Console.SetCursorPosition(45, 1);
			Console.Write("- DIREITO -");
			Console.SetCursorPosition(45, 2);
			Console.Write("Estado: " + right.State);
			Console.SetCursorPosition(45, 3);
			Console.Write("Cotovelo: " + right.Elbow);
			Console.SetCursorPosition(45, 4);
			Console.Write("Ângulo do Pulso: " + right.WristAngle);
		}
		
		private void DrawArmOptions(int currentOption)
		{
			Console.SetCursorPosition(33, 6);
			Console.Write("--- CONTROLES ---");
			
			Console.SetCursorPosition(15, 7);
			Console.Write("Girar 5º horário");
			Console.SetCursorPosition(15, 8);
			Console.Write("Girar 5º antihorário");
			Console.SetCursorPosition(15, 9);
			Console.Write("Definir Ângulo");
			Console.SetCursorPosition(15, 10);
			Console.Write("Pegar / Soltar Objeto");
			Console.SetCursorPosition(15, 11);
			Console.Write("Armazenar Objeto");
			Console.SetCursorPosition(15, 12);
			Console.Write("Bater com Martelo");
			
			Console.SetCursorPosition(45, 7);
			Console.Write("Girar 5º horário");
			Console.SetCursorPosition(45, 8);
			Console.Write("Girar 5º antihorário");
			Console.SetCursorPosition(45, 9);
			Console.Write("Definir Ângulo");
			Console.SetCursorPosition(45, 10);
			Console.Write("Pegar / Soltar Objeto");
			Console.SetCursorPosition(45, 11);
			Console.Write("Armazenar Objeto");
			Console.SetCursorPosition(45, 12);
			Console.Write("Cortar Objeto");
			Console.SetCursorPosition(45, 13);
			Console.Write("Coletar com a Pá");
			
			Console.SetCursorPosition(15, 15);
			Console.Write("Desativar braços e voltar ao corpo do Drone");
			
			Console.SetCursorPosition(15, 23);
			Console.Write("Setas: Mover     Enter: Escolher     Esc: Sair");
		}
		
		private void DrawArmsMenu(LeftDroneArm left, RightDroneArm right, int option)
		{
			Console.Clear();
			DrawArmStates(left, right);
			DrawArmOptions(option);
			DrawSelectionCursor('>');
		}
		
		private void DrawSelectionCursor(char cursor)
		{
			if (verticalPosition == 7)
			{
				Console.SetCursorPosition(13, 15);
				Console.Write(cursor);
			}
			else
			{
				Console.SetCursorPosition(13 + (30 * Convert.ToInt32(RightSide)), 7 + verticalPosition);
				Console.Write(cursor);
			}
		}
		
		private int MoveSelectionUp(int currentOption)
		{
			if (verticalPosition == 0)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (verticalPosition == 7)
			{
				if (RightSide)
				{
					verticalPosition--;
					currentOption = 12;
				}
				else
				{
					verticalPosition -= 2;
					currentOption = 5;
				}
			}
			else
			{
				currentOption--;
				verticalPosition--;
			}
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionDown(int currentOption)
		{
			if (verticalPosition == 7)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (verticalPosition == 5 && !RightSide)
			{
				verticalPosition = 7;
				currentOption = 13;
			}
			else
			{
				verticalPosition++;
				currentOption++;
			}
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionLeft(int currentOption)
		{
			if (verticalPosition == 7)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (RightSide)
			{
				if (verticalPosition == 6)
				{
					currentOption -= 7;
					verticalPosition = 5;
				}
				else
				{
					currentOption -= 6;
				}
			}
			RightSide = false;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionRight(int currentOption)
		{
			if (verticalPosition == 7)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if(!RightSide)
			{
				currentOption += 6;
			}
			RightSide = true;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		public void Start(DroneBody drone)
		{
			int menuOption = 0;
			ConsoleKeyInfo menuInput;
			
			DrawArmsMenu(drone.LeftArm, drone.RightArm, menuOption);
			
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
						{
							/*bool success;
							switch (menuOption)
							{
								case 0:
									{
										success = drone.ChangeHeight(true);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 1:
									{
										success = drone.ChangeHeight(false);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 2:
									{
										double height = DroneValueInput("Altura");
										success = drone.ChangeHeight(height);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 3:
									{
										success = drone.ChangeAngle(true);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 4:
									{
										success = drone.ChangeAngle(false);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 5:
									{
										int angle = (int)DroneValueInput("Ângulo");
										success = drone.ChangeAngle(angle);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 6:
									{
										success = drone.ChangeSpeed(true);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 7:
									{
										success = drone.ChangeSpeed(false);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 8:
									{
										double speed = DroneValueInput("Velocidade");
										success = drone.ChangeSpeed(speed);
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 9:
									{
										success = drone.ApproachObject();
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 10:
									{
										success = drone.DistanceFromObject();
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
								case 11:
									{
										success = drone.AccessDroneArms();
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
							}*/
							break;
						}
					case ConsoleKey.Escape:
						{
							break;
						}
				}
			}
			while(menuInput.Key != ConsoleKey.Escape);
		}
	}
}
