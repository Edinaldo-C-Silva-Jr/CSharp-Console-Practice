/*
 * Date: 13/02/2024
 * Time: 20:34
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone
{
	public class DroneBody
	{
		public double Height { get; private set; }
		public int Angle { get; private set; }
		public double Speed { get; private set;	}
		private MovementState DroneMovement { get; set; }
		private bool ApproachedObject { get; set; }
		
		public string Message { get; private set; }
		
		public DroneArms LeftArm { get; set; }
		public DroneArms RightArm { get; set; }
		
		public DroneBody()
		{
			Height = 0.5;
			Angle = 0;
			Speed = 0;
			DroneMovement = MovementState.Stopped;
			ApproachedObject = false;
			
			Message = "";
			
			LeftArm = new DroneArms();
			RightArm = new DroneArms();
		}
		
		private bool SetHeight(double height)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível mover o Drone próximo de um objeto.";
				return false;
			}
			
			if (height < 0.5)
			{
				Message = "Valor de Altura abaixo do mínimo permitido.";
				return false;
			}
			
			if (height > 25)
			{
				Message = "Valor de Altura acima do máximo permitido.";
				return false;
			}
			
			Height = height;
			return true;
		}
		
		public bool ChangeHeight(double height)
		{
			return SetHeight(height);
		}
		
		public bool ChangeHeight(bool increment)
		{
			if (increment)
			{
				return SetHeight(Height + 0.5);
			}
			else
			{
				return SetHeight(Height - 0.5);
			}
		}
		
		private bool SetAngle(int angle)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível girar o Drone próximo de um objeto.";
				return false;
			}
			
			if (angle < 0 || angle > 359)
			{
				Message = "Valor de Ângulo inválido.";
				return false;
			}
			
			Angle = angle;
			return true;
		}
		
		public bool ChangeAngle(int angle)
		{
			return SetAngle(angle);
		}
		
		public bool ChangeAngle(bool clockwise)
		{
			int angle = Angle;
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
			return SetAngle(angle);
		}
		
		private bool SetSpeed(double speed)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível alterar a Velocidade próximo de um objeto.";
				return false;
			}
			
			if (speed < 0)
			{
				Message = "Valor de Velocidade abaixo do mínimo permitido.";
				return false;
			}
			
			if (speed > 15)
			{
				Message = "Valor de Velocidade acima do máximo permitido.";
				return false;
			}
			
			Speed = speed;
			DefineMovementState();
			return true;
		}
		
		public bool ChangeSpeed(double speed)
		{
			return SetSpeed(speed);
		}
		
		public bool ChangeSpeed(bool increment)
		{
			if (increment)
			{
				return SetSpeed(Speed + 0.5);
			}
			else
			{
				return SetSpeed(Speed - 0.5);
			}
		}
		
		private void DefineMovementState()
		{
			if (Speed == 0)
			{
				DroneMovement = MovementState.Stopped;
			}
			else
			{
				DroneMovement = MovementState.Moving;
			}
		}
		
		public string ShowMovementState()
		{
			if (DroneMovement == MovementState.Stopped)
			{
				return "Parado";
			}
			else
			{
				return "Em movimento.";
			}
		}
		
		public bool ApproachObject()
		{
			if (DroneMovement == MovementState.Moving)
			{
				Message = "Não é possível aproximar de um objeto com o drone em movimento!";
				return false;
			}
			
			if (ApproachedObject)
			{
				Message = "O drone já se aproximou de um objeto!";
				return false;
			}
			
			return ApproachedObject = true;
		}
		
		public bool DistanceFromObject()
		{
			if (!ApproachedObject)
			{
				Message = "O drone não está próximo de nenhum objeto!";
				return false;
			}
			
			return !(ApproachedObject = false);
		}
		
		public string ShowApproachedObject()
		{
			if (ApproachedObject)
			{
				return "Próximo de um Objeto.";
			}
			else
			{
				return "Distante de Objetos.";
			}
		}
		
		public bool AccessDroneArms()
		{
			if (!ApproachedObject)
			{
				Message = "Os braços só podem ser usados próximo a um objeto.";
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
