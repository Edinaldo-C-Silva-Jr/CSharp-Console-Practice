/*
 * Date: 18/02/2024
 * Time: 18:25
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	/// <summary>
	/// A class that represents the Drone's left arm, which works like a standard drone arm, but with some unique tools.
	/// </summary>
	public class LeftDroneArm : DroneArms
	{
		/// <summary>
		/// Simulates the drone hitting an object with a hammer, to break it into smaller objects.
		/// </summary>
		/// <returns>Whether the drone successfully hit the object or not.</returns>
		public bool HitObject()
		{
			if (State == ArmState.Occupied)
			{
				Message = "O braço não pode usar o martelo enquanto segura um objeto.";
				return false;
			}
			
			if (Elbow == ElbowState.Resting)
			{
				Message = "O cotovelo deve estar contraído para usar o martelo.";
				return false;
			}
			
			Message = "O braço bateu com o martelo no objeto.";
			return true;
		}
	}
}
