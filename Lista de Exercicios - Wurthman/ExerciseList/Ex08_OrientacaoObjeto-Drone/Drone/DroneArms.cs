/*
 * Date: 18/02/2024
 * Time: 17:24
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class DroneArms
	{
		public ArmState State { get; private set; }
		public ElbowState Elbow { get; private set; }
		
		private int _wristAngle;
		public int WristAngle
		{
			get { return _wristAngle; }
			private set
			{
				if (value < 0) { _wristAngle = value + 360; }
				else if (value > 359) { _wristAngle = value - 360; }
				else { _wristAngle = value; }
			}
		}
		
		public DroneArms()
		{
			State = ArmState.Resting;
			Elbow = ElbowState.Resting;
			WristAngle = 0;
		}
		
		public void ChangeState(bool approached)
		{
			if (approached)
			{
				switch(State)
				{
					case ArmState.Resting:
						State = ArmState.Active;
						break;
					case ArmState.Active:
						State = ArmState.Resting;
						break;
					case ArmState.Occupied:
						Console.WriteLine("Mão é possível desativar o braço enquanto ele está ocupado!");
						break;
				}
			}
		}
		
		public void ChangeElbow()
		{
			if (State == ArmState.Active)
			{
				if (Elbow == ElbowState.Resting)
				{
					Elbow = ElbowState.Contracted;
				}
				else
				{
					Elbow = ElbowState.Resting;
				}
			}
		}
		
		public void ChangeWristAngle(int angle)
		{
			if (angle >= 0 && angle <= 359)
			{
				WristAngle = angle;
			}
			else
			{
				Console.WriteLine("Ângulo inválido!");
			}
		}
		
		public void ChangeWristAngle(bool clockwise)
		{
			if (clockwise)
			{
				WristAngle += 5;
			}
			else
			{
				WristAngle -= 5;
			}
		}
		
		public void TakeReleaseObject()
		{
			if (State == ArmState.Occupied) // If the arm is occupied, holding an object...
			{
				State = ArmState.Active; // Let go of the object to free it.
			}
			else
			{
				if (Elbow == ElbowState.Contracted) // If the arm is free and the elbow contracted...
				{
					State = ArmState.Occupied; // Take an object, occupying the arm.
				}
				else
				{
					Console.WriteLine("O cotovelo deve estar contraído para pegar um objeto.");
				}
			}
		}
		
		public void StoreObject()
		{
			if (State == ArmState.Occupied) // If the arm is occupied holding an object...
			{
				if (Elbow == ElbowState.Resting) // And the elbow is resting...
				{
					State = ArmState.Active; // Store the object, freeing the arm. 
				}
			}
			else
			{
				Console.WriteLine("O braço não possui nenhum objeto para armazenar.");
			}
		}
	}
}
