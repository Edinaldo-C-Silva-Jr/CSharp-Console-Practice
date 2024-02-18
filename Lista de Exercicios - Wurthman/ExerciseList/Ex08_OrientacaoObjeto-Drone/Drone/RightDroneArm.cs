/*
 * Date: 18/02/2024
 * Time: 18:26
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class RightDroneArm : DroneArms
	{
		public RightDroneArm()
		{
		}
		
		public void CutObject()
		{
			if (State == ArmState.Occupied)
			{
				return;
			}
			
			if (Elbow == ElbowState.Resting)
			{
				return;
			}
			
			Console.WriteLine("Drone cortou objeto.");
		}
		
		public void DigObject()
		{
			if (State == ArmState.Occupied)
			{
				return;
			}
			
			if (Elbow == ElbowState.Contracted)
			{
				return;
			}
			
			Console.WriteLine("Drone coletou objeto.");
			State = ArmState.Occupied;
		}
	}
}
