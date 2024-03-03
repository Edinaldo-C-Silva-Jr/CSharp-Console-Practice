/*
 * Date: 18/02/2024
 * Time: 18:26
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone.Arms
{
	/// <summary>
	/// A class that represents the Drone's right arm, which works like a standard drone arm, but with some unique tools.
	/// </summary>
	public class RightDroneArm : DroneArms
	{	
		/// <summary>
		/// Simulates the drone cutting an object with scissors.
		/// </summary>
		/// <returns>Whether the drone successfully cut the object or not.</returns>
		public bool CutObject()
		{
			if (State == ArmState.Occupied)
			{
				Message = "O braço não pode usar a tesoura enquanto segura um objeto.";
				return false;
			}
			
			if (Elbow == ElbowState.Resting)
			{
				Message = "O cotovelo deve estar contraído para usar a tesoura.";
				return false;
			}
			
			Message = "O braço cortou o objeto com a tesoura.";
			return true;
		}
		
		/// <summary>
		/// Simulates the drone collecting an object with a shovel, which changes the arm state to Occupied. 
		/// </summary>
		/// <returns>Whether the drone successfully collected the object or not.</returns>
		public bool CollectObject()
		{
			if (State == ArmState.Occupied)
			{
				Message = "O braço não pode usar a pá enquanto segura um objeto.";
				return false;
			}
			
			if (Elbow == ElbowState.Resting)
			{
				Message = "O cotovelo deve estar contraído para usar a pá.";
				return false;
			}
			
			Message = "O braço coletou o objeto com a pá.";
			State = ArmState.Occupied;
			return true;
		}
	}
}
