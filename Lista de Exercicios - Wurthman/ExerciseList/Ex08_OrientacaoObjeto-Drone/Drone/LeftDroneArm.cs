/*
 * Date: 18/02/2024
 * Time: 18:25
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class LeftDroneArm : DroneArms
	{
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
