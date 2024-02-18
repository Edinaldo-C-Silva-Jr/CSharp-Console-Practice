/*
 * Date: 18/02/2024
 * Time: 18:25
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class LeftDroneArm : DroneArms
	{
		public LeftDroneArm()
		{
		}
		
		public void HitObject()
		{
			if (State == ArmState.Occupied)
			{
				return;
			}
			
			if (Elbow == ElbowState.Resting)
			{
				return;
			}
			
			Console.WriteLine("Drone martelou objeto.");
		}
	}
}
