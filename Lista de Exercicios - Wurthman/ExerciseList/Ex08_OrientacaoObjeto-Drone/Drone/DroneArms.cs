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
		
		public int WristAngle { get; private set; }
		public string Message { get; protected set; }
		
		public DroneArms()
		{
			State = ArmState.Resting;
			Elbow = ElbowState.Resting;
			WristAngle = 0;
		}
		
		public void ClearMessage()
		{
			Message = "";
		}
		
		public void ActivateArm()
		{
			if (State == ArmState.Occupied)
			{
				return;
			}
			
			State = ArmState.Active;
		}
		
		public bool DeactivateArm()
		{
			bool deactivated = true;
			
			if (State == ArmState.Occupied)
			{
				deactivated = false;
				Message = "Não é possível desativar um braço enquanto ele está ocupado!";
			}
			else
			{
				State = ArmState.Resting;
			}
			
			return deactivated;
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
			if (State != ArmState.Resting)
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
		
		private bool SetWristAngle(int angle)
		{
			if (angle < 0 || angle > 359)
			{
				Message = "Valor inválido. O ângulo deve star entre 0 e 359.";
				return false;
			}
			
			WristAngle = angle;
			return true;
		}
		
		public bool ChangeWristAngle(int angle)
		{
			return SetWristAngle(angle);
		}
		
		public bool ChangeWristAngle(bool clockwise)
		{
			int angle = WristAngle;
			if (clockwise)
			{
				angle += 5;
				angle = angle % 360;
			}
			else
			{
				angle -= 5;
				if (angle < 0)
				{
					angle += 360;
				}
				
			}
			return SetWristAngle(angle);
		}
		
		public bool TakeReleaseObject()
		{
			if (State == ArmState.Occupied) // If the arm is occupied, holding an object...
			{
				State = ArmState.Active; // Let go of the object to free it.
				Message = "O braço soltou o objeto.";
				return true;
			}
			else
			{
				if (Elbow == ElbowState.Contracted) // If the arm is free and the elbow contracted...
				{
					State = ArmState.Occupied; // Take an object, occupying the arm.
					Message = "O braço pegou o objeto.";
					return true;
				}
				else
				{
					Message = "O cotovelo deve estar contraído para pegar um objeto.";
					return false;
				}
			}
		}
		
		public bool StoreObject()
		{
			if (State == ArmState.Occupied) // If the arm is occupied holding an object...
			{
				if (Elbow == ElbowState.Resting) // And the elbow is resting...
				{
					State = ArmState.Active; // Store the object, freeing the arm.
					Message = "O braço armazenou o objeto.";
					return true;
				}
				else
				{
					Message = "O cotovelo deve estar em repouso para armazenar um objeto.";
					return false;
				}
			}
			else
			{
				Message = "O braço não possui nenhum objeto para armazenar.";
				return false;
			}
		}
	}
}
