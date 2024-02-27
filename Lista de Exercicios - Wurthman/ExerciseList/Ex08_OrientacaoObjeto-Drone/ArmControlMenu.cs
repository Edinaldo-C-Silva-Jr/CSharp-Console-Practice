﻿/*
 * Date: 22/02/2024
 * Time: 23:14
 */
using System;
using Ex08_OrientacaoObjeto_Drone.Drone;

namespace Ex08_OrientacaoObjeto_Drone
{
	public class ArmControlMenu
	{
		private int VerticalPosition { get; set; }
		private bool RightSide { get; set; }
		
		public ArmControlMenu()
		{
			VerticalPosition = 0;
			RightSide = false;
		}
		
		private void DrawArmStates(LeftDroneArm left, RightDroneArm right)
		{
			Console.SetCursorPosition(33, 0);
			Console.Write("--- BRAÇOS ---");
			
			Console.SetCursorPosition(15, 1);
			Console.Write("- ESQUERDO -");
			Console.SetCursorPosition(15, 2);
			Console.Write("Estado: ");
			WriteColoredText(left.ShowArmState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(15, 3);
			Console.Write("Cotovelo: ");
			WriteColoredText(left.ShowElbowState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(15, 4);
			Console.Write("Ângulo do Pulso: " + left.WristAngle);
			
			Console.SetCursorPosition(45, 1);
			Console.Write("- DIREITO -");
			Console.SetCursorPosition(45, 2);
			Console.Write("Estado: ");
			WriteColoredText(right.ShowArmState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 3);
			Console.Write("Cotovelo: ");
			WriteColoredText(right.ShowElbowState(), ConsoleColor.Cyan);
			Console.SetCursorPosition(45, 4);
			Console.Write("Ângulo do Pulso: " + right.WristAngle);
		}
		
		private void DrawArmOptions(int currentOption)
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
		
		private void DrawArmsMenu(LeftDroneArm left, RightDroneArm right, int option)
		{
			Console.Clear();
			DrawArmStates(left, right);
			DrawArmOptions(option);
			DrawSelectionCursor('>');
		}
		
		private void DrawSelectionCursor(char cursor)
		{
			if (VerticalPosition == 8)
			{
				Console.SetCursorPosition(13, 16);
				Console.Write(cursor);
			}
			else
			{
				Console.SetCursorPosition(13 + (30 * Convert.ToInt32(RightSide)), 7 + VerticalPosition);
				Console.Write(cursor);
			}
		}
		
		private int MoveSelectionUp(int currentOption)
		{
			if (VerticalPosition == 0)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (VerticalPosition == 8)
			{
				if (RightSide)
				{
					VerticalPosition--;
					currentOption = 14;
				}
				else
				{
					VerticalPosition -= 2;
					currentOption = 6;
				}
			}
			else
			{
				currentOption--;
				VerticalPosition--;
			}
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionDown(int currentOption)
		{
			if (VerticalPosition == 8)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (VerticalPosition == 6 && !RightSide)
			{
				VerticalPosition = 8;
				currentOption = 15;
			}
			else
			{
				VerticalPosition++;
				currentOption++;
			}
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionLeft(int currentOption)
		{
			if (VerticalPosition == 8)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if (RightSide)
			{
				if (VerticalPosition == 7)
				{
					currentOption -= 8;
					VerticalPosition = 6;
				}
				else
				{
					currentOption -= 7;
				}
			}
			RightSide = false;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int MoveSelectionRight(int currentOption)
		{
			if (VerticalPosition == 8)
			{
				return currentOption;
			}
			
			DrawSelectionCursor(' ');
			
			if(!RightSide)
			{
				currentOption += 7;
			}
			RightSide = true;
			
			DrawSelectionCursor('>');
			return currentOption;
		}
		
		private int ArmValueInput()
		{
			Console.SetCursorPosition(15, 18);
			Console.Write(new String(' ', 200));
			
			Console.CursorVisible = true;
			Console.SetCursorPosition(15, 18);
			Console.Write("Digite o novo valor para o Ângulo: ");
			
			double value;
			bool successConvert = double.TryParse(Console.ReadLine(), out value);
			if (successConvert)
			{
				return (int)value;
			}
			else
			{
				return -1;
			}
		}
		
		private void ShowMessage(bool success, string message)
		{
			Console.SetCursorPosition(15, 18);
			Console.Write(new String(' ', 200));
			
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
		
		private void WriteColoredText(string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		
		private void EnterKeySelection(int menuOption, LeftDroneArm leftArm, RightDroneArm rightArm)
		{
			bool success = true;
			switch (menuOption)
			{
				case 0:
					leftArm.ChangeElbowState();
					break;
				case 1:
					success = leftArm.ChangeWristAngle(true);
					break;
				case 2:
					success = leftArm.ChangeWristAngle(false);
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
					success = rightArm.ChangeWristAngle(true);
					break;
				case 9:
					success = rightArm.ChangeWristAngle(false);
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
			
			DrawArmsMenu(leftArm, rightArm, menuOption);
			
			if (RightSide)
			{
				ShowMessage(success, rightArm.Message);
				rightArm.ClearMessage();
			}
			else
			{
				ShowMessage(success, leftArm.Message);
				leftArm.ClearMessage();
			}
			
		}
		
		private bool DeactivateArms(LeftDroneArm left, RightDroneArm right)
		{
			bool deactivated = true;
			
			if (!left.DeactivateArm())
			{
				deactivated = false;
				RightSide = false;
			}
			if (!right.DeactivateArm())
			{
				deactivated = false;
				RightSide = true;
			}
			
			if (!deactivated)
			{
				left.ActivateArm();
				right.ActivateArm();
			}
			
			return deactivated;
		}
		
		public void Start(LeftDroneArm leftArm, RightDroneArm rightArm)
		{
			leftArm.ActivateArm();
			rightArm.ActivateArm();
			
			int menuOption = 0;
			ConsoleKeyInfo menuInput;
			
			DrawArmsMenu(leftArm, rightArm, menuOption);
			
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
			while(leftArm.ShowArmState() != "Inativo" || rightArm.ShowArmState() != "Inativo");
		}
	}
}
