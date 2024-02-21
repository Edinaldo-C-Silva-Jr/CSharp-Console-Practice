﻿/*
 * Date: 13/02/2024
 * Time: 20:34
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class DroneBody
	{
		public double Height { get; private set; }
		
		private int _angle;
		public int Angle
		{
			get { return _angle; }
			private set
			{
				if (value < 0) { _angle = value + 360; }
				else if (value > 359) { _angle = value - 360; }
				else { _angle = value; }
			}
		}
		
		private double _speed;
		public double Speed
		{
			get { return _speed; }
			private set
			{
				if (value >= 0 && value <= 15) { _speed = value; }
			}
		}
		
		private MovementState DroneMovement { get; set; }
		
		private bool ApproachedObject { get; set; }
		
		public string Message { get; private set; }
		
		public DroneArms LeftArm { get; set; }
		public DroneArms RightArm { get; set; }
		
		public DroneBody()
		{
			Height = 0.5;
			Angle = 0;
			Speed = 0;
			DroneMovement = MovementState.Stopped;
			ApproachedObject = false;
			
			LeftArm = new DroneArms();
			RightArm = new DroneArms();
		}
		
		private bool SetHeight(double height)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível mover o Drone ao estar próximo de um objeto.";
				return false;
			}
			
			if (height < 0.5)
			{
				Message = "Valor de Altura abaixo do mínimo permitido.";
				return false;
			}
			
			if (height > 25)
			{
				Message = "Valor de Altura acima do máximo permitido.";
				return false;
			}
			
			Height = height;
			return true;
		}
		
		public bool ChangeHeight(double height)
		{
			return SetHeight(height);
		}
		
		public bool ChangeHeight(bool increment)
		{
			if (increment)
			{
				return SetHeight(Height + 0.5);
			}
			else
			{
				return SetHeight(Height - 0.5);
			}
		}
		
		public void ChangeAngle(int angle)
		{
			if (ApproachedObject)
			{
				return;
			}
			
			if (angle >= 0 && angle <= 359)
			{
				Angle = angle;
			}
		}
		
		public void ChangeAngle(bool clockwise)
		{
			if (ApproachedObject)
			{
				return;
			}
			
			if (clockwise)
			{
				Angle += 5;
			}
			else
			{
				Angle -= 5;
			}
		}
		
		public void ChangeSpeed(double speed)
		{
			if (ApproachedObject)
			{
				return;
			}
			
			Speed = speed;
			DefineMovementState();
		}
		
		public void ChangeSpeed(bool increment)
		{
			if (ApproachedObject)
			{
				return;
			}
			
			if (increment)
			{
				Speed += 0.5;
			}
			else
			{
				Speed -= 0.5;
			}
			DefineMovementState();
		}
		
		private void DefineMovementState()
		{
			if (Speed == 0)
			{
				DroneMovement = MovementState.Stopped;
			}
			else
			{
				DroneMovement = MovementState.Moving;
			}
		}
		
		public string ShowMovementState()
		{
			if (DroneMovement == MovementState.Stopped)
			{
				return "Parado";
			}
			return "Em movimento.";
		}
		
		public void ApproachObject()
		{
			if (DroneMovement == MovementState.Moving)
			{
				Console.WriteLine("Não é possível aproximar-se de um objeto com o drone em movimento!");
				return;
			}
			
			if (ApproachedObject)
			{
				Console.WriteLine("O drone já se aproximou de um objeto!");
				return;
			}
			
			ApproachedObject = true;
			Console.WriteLine("O drone se aproximou do objeto.");
		}
		
		public void DistanceFromObject()
		{
			if (!ApproachedObject)
			{
				Console.WriteLine("O drone não está próximo de nenhum objeto!");
				return;
			}
			
			ApproachedObject = false;
			Console.WriteLine("O drone se distanciou do objeto.");
		}
		
		public string ShowApproachedObject()
		{
			if (ApproachedObject)
			{
				return "Próximo de um Objeto.";
			}
			return "Distante de Objetos.";
		}
	}
}
