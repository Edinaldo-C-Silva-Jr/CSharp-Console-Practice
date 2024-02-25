/*
 * Date: 18/02/2024
 * Time: 19:59
 */
using System;
using System.Collections.Generic;
using Ex08_OrientacaoObjeto_Drone.Drone;

namespace Ex08_OrientacaoObjeto_Drone
{
	public class DroneControlMenu
	{
		private void DrawDroneStates(DroneBody drone)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- DRONE ---");
			Console.SetCursorPosition(15, 1);
			Console.Write("Altura: " + drone.Height);
			Console.SetCursorPosition(15, 2);
			Console.Write("Ângulo: " + drone.Angle);
			Console.SetCursorPosition(45, 1);
			Console.Write("Velocidade: " + drone.Speed);
			Console.SetCursorPosition(45, 2);
			Console.Write("Movimento: " + drone.ShowMovementState());
			Console.SetCursorPosition(25, 3);
			Console.Write(drone.ShowApproachedObject());
		}
		
		private void DrawDroneOptions(int currentOption)
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
			
			Console.SetCursorPosition(13, 6 + currentOption);
			Console.Write(">");
			
			Console.SetCursorPosition(15, 23);
			Console.Write("Setas: Mover     Enter: Escolher     Esc: Sair");
		}
		
		private void DrawDroneMenu(DroneBody drone, int option)
		{
			Console.Clear();
			DrawDroneStates(drone);
			DrawDroneOptions(option);
		}
		
		private void DrawSelectionCursor(char cursor, int option)
		{
			Console.SetCursorPosition(13, 6 + option);
			Console.Write(cursor);
		}
		
		// Moves the "selection cursor" (the > that points at the current option) one option up
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
		
		// Moves the "selection cursor" one option down
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
		
		private double DroneValueInput(string property)
		{
			Console.SetCursorPosition(15, 19);
			Console.Write(new String(' ', 200));
			
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 19);
			Console.Write("Digite o novo valor para {0}: " , property);
			
			int value;
			bool successConvert = int.TryParse(Console.ReadLine(), out value);
			if (successConvert)
			{
				return value;
			}
			else
			{
				return -1;
			}
		}
		
		private void ShowMenuAndVerifySuccess(DroneBody drone, int menuOption, bool success)
		{
			DrawDroneMenu(drone, menuOption);
			if (!success)
			{
				Console.SetCursorPosition(15, 19);
				Console.Write(drone.Message);
			}
		}
		
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
						{
							menuOption = MoveSelectionUp(menuOption);
							break;
						}
					case ConsoleKey.DownArrow:
						{
							menuOption = MoveSelectionDown(menuOption);
							break;
						}
					case ConsoleKey.Enter:
						{
							switch (menuOption)
							{
								case 0:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeHeight(true));
										break;
									}
								case 1:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeHeight(false));
										break;
									}
								case 2:
									{
										double height = DroneValueInput("Altura");
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeHeight(height));
										break;
									}
								case 3:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeAngle(true));
										break;
									}
								case 4:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeAngle(false));
										break;
									}
								case 5:
									{
										int angle = (int)DroneValueInput("Ângulo");
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeAngle(angle));
										break;
									}
								case 6:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeSpeed(true));
										break;
									}
								case 7:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeSpeed(false));
										break;
									}
								case 8:
									{
										double speed = DroneValueInput("Velocidade");
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ChangeSpeed(speed));
										break;
									}
								case 9:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.ApproachObject());
										break;
									}
								case 10:
									{
										ShowMenuAndVerifySuccess(drone, menuOption, drone.DistanceFromObject());
										break;
									}
								case 11:
									{
										bool success = drone.AccessDroneArms();
										ShowMenuAndVerifySuccess(drone, menuOption, success);
										break;
									}
							}
							break;
						}
					case ConsoleKey.Escape:
						{
							Console.Clear();
							Console.SetCursorPosition(30, 10);
							Console.Write("Desligando Drone...");
							Console.SetCursorPosition(24, 11);
							Console.Write("Pressione Enter para encerrar...");
							Console.ReadLine();
							break;
						}
				}
			}
			while(menuInput.Key != ConsoleKey.Escape);
		}
	}
}
