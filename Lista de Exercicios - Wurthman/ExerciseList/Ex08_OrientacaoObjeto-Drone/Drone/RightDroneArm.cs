﻿/*
 * Date: 18/02/2024
 * Time: 18:26
*/
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class RightDroneArm : DroneArms
	{	
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
