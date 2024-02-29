/*
 * Date: 18/02/2024
 * Time: 17:24
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	/// <summary>
	/// A class that represents an arm of the Drone.
	/// </summary>
	public class DroneArms
	{
		/// <summary>
		/// The current state of the Drone's arm, which defines whether it's active, resting or occupied.
		/// </summary>
		protected ArmState State { get; set; }
		
		/// <summary>
		/// The current state of the arm's elbow, which can be either resting or contracted. 
		/// </summary>
		protected ElbowState Elbow { get; set; }
		
		/// <summary>
		/// The current rotation angle of the arm's wrist.
		/// </summary>
		public int WristAngle { get; private set; }
		
		/// <summary>
		/// The message tied to the last action performed by the arm, that describes whether it was successful or failed.
		/// </summary>
		public string Message { get; protected set; }
		
		/// <summary>
		/// Default constructor, sets the default values to the arm's states and angle.
		/// </summary>
		public DroneArms()
		{
			State = ArmState.Resting;
			Elbow = ElbowState.Resting;
			WristAngle = 0;
		}
		
		/// <summary>
		/// Clears the message value for this arm.
		/// </summary>
		public void ClearMessage()
		{
			Message = "";
		}
		
		/// <summary>
		/// Changes the arm state to Active. 
		/// </summary>
		public void ActivateArm()
		{
			State = ArmState.Active;
		}
		
		/// <summary>
		/// Changes the arm state to Resting. Can only be done if the arm isn't Occupied.
		/// </summary>
		/// <returns>Whether the arm was deactivated or not.</returns>
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
		
		/// <summary>
		/// Returns the current state of the arm.
		/// </summary>
		/// <returns>A string that represents the arm state.</returns>
		public string GetArmState()
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
		
		/// <summary>
		/// Changes the state of the arm's elbow.
		/// </summary>
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
		
		/// <summary>
		/// Returns the current state of the arm's elbow.
		/// </summary>
		/// <returns>A string that represents the elbow state.</returns>
		public string GetElbowState()
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
		
		/// <summary>
		/// Sets the angle of the arm's wrist. The value needs to be between 0 and 359.
		/// </summary>
		/// <param name="angle">The value to set the angle to.</param>
		/// <returns>Whether the value was successfully set or not.</returns>
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
		
		/// <summary>
		/// Changes the angle of the arm's wrist.
		/// </summary>
		/// <param name="angle">The value to set the angle to. It has to be between 0 and 359.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid.</returns>
		public bool ChangeWristAngle(int angle)
		{
			return SetWristAngle(angle);
		}
		 
		/// <summary>
		/// Changes the angle of the arm's wrist, by either incrementing or decrementing 5 degrees.
		/// </summary>
		/// <param name="clockwise">Whether to increment or decrement the angle.</param>
		public void ChangeWristAngle(bool clockwise)
		{
			int angle = WristAngle;
			if (clockwise)
			{
				angle += 5;
				angle = angle % 360; // Reduces the angle in case it goes over 360.
			}
			else
			{
				angle -= 5;
				if (angle < 0)
				{
					angle += 360; // Increases the angle in case it goes below 0.
				}
			}
			SetWristAngle(angle);
		}
		
		/// <summary>
		/// Simulates the drone arm collecting an object, holding it onto its claws, which changes the state to Occupied.
		/// </summary>
		/// <returns>Whether the arm successfully collected the object or not.</returns>
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
		
		/// <summary>
		/// Simulates the drone storing the object into a storing compartment, freeing the arm.
		/// </summary>
		/// <returns>Whether the arm sccessfully stored the object or not.</returns>
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
