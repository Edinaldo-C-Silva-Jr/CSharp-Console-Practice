/*
 * Date: 18/02/2024
 * Time: 17:24
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class DroneArms
	{
		protected ArmState State { get; set; }
		protected ElbowState Elbow { get; set; }
		
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
		public string Message { get; private set; }
		
		public DroneArms()
		{
			State = ArmState.Resting;
			Elbow = ElbowState.Resting;
			WristAngle = 0;
		}
		
		public bool ChangeArmState()
		{
			bool changed = true;
			switch(State)
			{
				case ArmState.Resting:
					State = ArmState.Active;
					break;
				case ArmState.Active:
					State = ArmState.Resting;
					break;
				case ArmState.Occupied:
					Message = "Não é possível desativar um braço enquanto ele está ocupado!";
					changed = false;
					break;
			}
			return changed;
		}
		
		public string ShowArmState()
		{
			switch(State)
			{
				case ArmState.Resting:
					return "Inativo";
				case ArmState.Active:
					return "Ativo";
				default:
					return "Ocupado";
			}
		}
		
		public void ChangeElbowState()
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
		
		public string ShowElbowState()
		{
			if (Elbow == ElbowState.Resting)
			{
				return "Em Repouso";
			}
			else
			{
				return "Contraído";
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
