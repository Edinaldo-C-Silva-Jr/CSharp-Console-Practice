/*
 * Date: 18/02/2024
 * Time: 19:59
 */
using System;
using System.Collections.Generic;
using Ex08_OrientacaoObjeto_Drone.Drone;

namespace Ex08_OrientacaoObjeto_Drone
{
	public class ControlMenu
	{
		public ControlMenu()
		{
			
		}
		
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
			Console.Write("Aumentar Altura");
			Console.SetCursorPosition(15, 7);
			Console.Write("Diminuir Altura");
			Console.SetCursorPosition(15, 8);
			Console.Write("Definir Altura");
			
			Console.SetCursorPosition(15, 9);
			Console.Write("Aumentar Ângulo");
			Console.SetCursorPosition(15, 10);
			Console.Write("Diminuir Ângulo");
			Console.SetCursorPosition(15, 11);
			Console.Write("Definir Ângulo");
			
			Console.SetCursorPosition(15, 12);
			Console.Write("Aumentar Velocidade");
			Console.SetCursorPosition(15, 13);
			Console.Write("Diminuir Velocidade");
			Console.SetCursorPosition(15, 14);
			Console.Write("Definir Velocidade");
			
			Console.SetCursorPosition(15, 15);
			Console.Write("Aproximar de um objeto");
			Console.SetCursorPosition(15, 16);
			Console.Write("Distanciar de um objeto");
			
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
		
		// Moves the "selection cursor" (the > that points at the current option) one option up
		private int MoveSelectionUp(int currentOption)
		{
			Console.SetCursorPosition(13, 5 + currentOption); // Draws the cursor on the option above the currently selected
			Console.Write(">");
			Console.SetCursorPosition(13, 6 + currentOption); // Erases the cursor on the current option
			Console.Write(" ");
			return currentOption - 1; // Returns the newly selected option
		}
		
		// Moves the "selection cursor" one option down
		private int MoveSelectionDown(int currentOption)
		{
			Console.SetCursorPosition(13, 6 + currentOption);
			Console.Write(" ");
			Console.SetCursorPosition(13, 7 + currentOption);
			Console.Write(">");
			return currentOption + 1;
		}
		
		private double DroneValueInput(string property)
		{
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 19);
			Console.Write("Digite o novo valor para {0}: ", property);
			
			int value;
			int.TryParse(Console.ReadLine(), out value);
			return value;
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
							if (menuOption > 0)
							{
								menuOption = MoveSelectionUp(menuOption);
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (menuOption < 11)
							{
								menuOption = MoveSelectionDown(menuOption);
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							switch (menuOption)
							{
								case 0:
									{
										drone.ChangeHeight(true);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 1:
									{
										drone.ChangeHeight(false);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 2:
									{
										double height = DroneValueInput("Altura");
										drone.ChangeHeight(height);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 3:
									{
										drone.ChangeAngle(true);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 4:
									{
										drone.ChangeAngle(false);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 5:
									{
										int angle = (int)DroneValueInput("Ângulo");
										drone.ChangeAngle(angle);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 6:
									{
										drone.ChangeSpeed(true);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 7:
									{
										drone.ChangeSpeed(false);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 8:
									{
										double speed = DroneValueInput("Velocidade");
										drone.ChangeSpeed(speed);
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 9:
									{
										drone.ApproachObject();
										DrawDroneMenu(drone, menuOption);
										break;
									}
								case 10:
									{
										drone.DistanceFromObject();
										DrawDroneMenu(drone, menuOption);
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
