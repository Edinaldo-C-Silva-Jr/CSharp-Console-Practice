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
			private set { if (value >= 0.5 && value <= 25) { _height = value; } }
		}
		
		private double _direction;
		public double Direction
		{ 
			get { return _direction; }
			private set 
			{
				if (value < 0) { _direction = value + 360; }
				if (value > 360) { _direction = value - 360; }
			}
		}
		
		private double _speed;
		public double Speed 
		{ 
			get { return _speed; }
			private set { if (value >= 0 && value <= 15) { _speed = value; } }
		}
		
		public bool ApproachObject { get; private set; }
		public MovementState DroneMovement { get; private set; }
		
		public Drone()
		{
			Height = 0.5;
			Direction = 0;
			Speed = 0;
			DroneMovement = MovementState.Stopped;
			ApproachObject = false;
		}
		
		public void ChangeHeight(double value)
		{
			Height = value;
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
	}
}
