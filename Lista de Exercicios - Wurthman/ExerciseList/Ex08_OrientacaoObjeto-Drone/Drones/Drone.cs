/*
 * Date: 13/02/2024
 * Time: 20:34
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drones
{
	public class Drone
	{
		private double _height;
		public double Height
		{
			get { return _height; }
			private set
			{
				if (value >= 0.5 && value <= 25) { _height = value; }
				else { Console.WriteLine("Altura inválida!"); }
			}
		}
		
		private double _angle;
		public double Angle
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
				else { Console.WriteLine("Velocidade inválida!"); }
			}
		}
		
		private MovementState DroneMovement { get; private set; }
		
		public bool ApproachedObject { get; private set; }
		
		public Drone()
		{
			Height = 0.5;
			Angle = 0;
			Speed = 0;
			DroneMovement = MovementState.Stopped;
			ApproachObject = false;
		}
		
		public void ChangeHeight(double height)
		{
			Height = height;
		}
		
		public void ChangeHeight(bool increment)
		{
			if (increment)
			{
				Height += 0.5;
			}
			else
			{
				Height -= 0.5;
			}
		}
		
		public void ChangeAngle(int angle)
		{
			if (angle >= 0 && angle <= 359)
			{
				Angle = angle;
			}
			else
			{
				Console.WriteLine("Ângulo inválido!");
			}
		}
		
		public void ChangeAngle(bool clockwise)
		{
			if (clockwise)
			{
				Angle += 5;
			}
			else
			{
				Angle -= 5;
			}
		}
		
		public void ChangeSpeed(bool increment)
		{
			if (increment)
			{
				Speed += 0.5;
			}
			else
			{
				Speed -= 0.5;
			}
		}
		
		public void DefineMovementState()
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
		
		public void ShowMovementState()
		{
			if (DroneMovement == MovementState.Stopped)
			{
				Console.WriteLine("O Drone está parado.");
			}
			else
			{
				Console.WriteLine("O drone esta em movimento.");
			}
		}
	}
}
