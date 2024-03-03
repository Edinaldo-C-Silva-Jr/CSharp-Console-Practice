/*
 * Date: 13/02/2024
 * Time: 20:34
 */
using System;
using Ex08_OrientacaoObjeto_Drone.Drone.Arms;

namespace Ex08_OrientacaoObjeto_Drone.Drone.Body
{
	/// <summary>
	/// A class that represents the Drone that is being controlled by the application.
	/// </summary>
	public class DroneBody
	{
		#region Properties
		/// <summary>
		/// The current height of the drone.
		/// </summary>
		public double Height { get; private set; }
		
		/// <summary>
		/// The current rotation angle of the drone.
		/// </summary>
		public int Angle { get; private set; }
		
		/// <summary>
		/// The current speed of the drone.
		/// </summary>
		public double Speed { get; private set;	}
		
		/// <summary>
		/// The current movement state of the drone, which is based on its speed.
		/// </summary>
		private MovementState DroneMovement { get; set; }
		
		/// <summary>
		/// Whether the drone is currently approached to an object or not.
		/// </summary>
		private bool ApproachedObject { get; set; }
		
		/// <summary>
		/// The message tied to the last action performed by the drone, that describes whether it was successful or failed.
		/// </summary>
		private string Message { get; set; }
		
		/// <summary>
		/// The drone's left arm.
		/// </summary>
		public LeftDroneArm LeftArm { get; set; }
		
		/// <summary>
		/// The drone's right arm.
		/// </summary>
		public RightDroneArm RightArm { get; set; }
		#endregion
		
		/// <summary>
		/// Default constructor, sets the default values to all drone properties and instances the arms.
		/// </summary>
		public DroneBody()
		{
			Height = 0.5;
			Angle = 0;
			Speed = 0;
			DroneMovement = MovementState.Stopped;
			ApproachedObject = false;
			
			Message = "";
			
			LeftArm = new LeftDroneArm();
			RightArm = new RightDroneArm();
		}
		
		/// <summary>
		/// Returns the message relating to the drone's last action, and then clears it.
		/// </summary>
		public string GetMessage()
		{
			string text = Message;
			Message = "";
			return text;
		}
		
		/// <summary>
		/// Sets the height of the drone, which is a value between 0.5 and 25. The drone shouldn't be close to an object.
		/// </summary>
		/// <param name="height">The value to set the height to.</param>
		/// <returns>Whether the height was successfully set or not.</returns>
		private bool SetHeight(double height)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível mover o Drone próximo de um objeto.";
				return false;
			}
			
			if (height < 0.5 || height > 25)
			{
				Message = "Valor inválido. A Altura deve estar entre 0.5 e 25.";
				return false;
			}
			
			Height = height;
			return true;
		}
		
		/// <summary>
		/// Changes the height of the drone.
		/// </summary>
		/// <param name="height">The value to set the height to. It has t be between 0.5 and 25.</param>
		/// <returns>Whether the height was successfully set or not. It fails if the value is invalid or if the drone is close to an object.</returns>
		public bool ChangeHeight(double height)
		{
			return SetHeight(height);
		}
		
		/// <summary>
		/// Changes the height of the drone, by either incrementing or decrementing it by 0.5.
		/// </summary>
		/// <param name="increment">Whether to increment or decrement the height.</param>
		/// <returns>Whether the height was successfully set or not. It fails if the value is invalid or if the drone is close to an object.</returns>
		public bool ChangeHeight(bool increment)
		{
			if (increment)
			{
				if (Height > 24.5 && Height < 25)
				{
					return SetHeight(25);
				}
				else
				{
					return SetHeight(Height + 0.5);
				}
			}
			else
			{
				if (Height > 0.5 && Height < 1)
				{
					return SetHeight(0.5);
				}
				else
				{
					return SetHeight(Height - 0.5);
				}
			}
		}
		
		/// <summary>
		/// Sets the angle of rotation of the drone. The value needs to be between 0 and 359. The drone shouldn't be close to an object.
		/// </summary>
		/// <param name="angle">The value to set the angle to.</param>
		/// <returns>Whether the value was successfully set or not.</returns>
		private bool SetAngle(int angle)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível girar o Drone próximo de um objeto.";
				return false;
			}
			
			if (angle < 0 || angle > 359)
			{
				Message = "Valor inválido. O ângulo deve star entre 0 e 359.";
				return false;
			}
			
			Angle = angle;
			return true;
		}
		
		/// <summary>
		/// Changes the angle of rotation of the drone.
		/// </summary>
		/// <param name="angle">The value to set the angle to. It has to be between 0 and 359.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid or if the drone is close to an object.</returns>
		public bool ChangeAngle(int angle)
		{
			return SetAngle(angle);
		}
		
		/// <summary>
		/// Changes the angle of rotation of the drone, by either incrementing or decrementing 5 degrees. The angle rolls over if past 0 or 359.
		/// </summary>
		/// <param name="clockwise">Whether to increment or decrement the angle.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the drone is close to an object.</returns>
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
		
		/// <summary>
		/// Sets the movement speed of the drone. The value needs to be between 0 and 15. The drone shouldn't be close to an object.
		/// </summary>
		/// <param name="speed">The value to set the speed to.</param>
		/// <returns>Whether the value was successfully set or not.</returns>
		private bool SetSpeed(double speed)
		{
			if (ApproachedObject)
			{
				Message = "Não é possível alterar a Velocidade próximo de um objeto.";
				return false;
			}
			
			if (speed < 0 || speed > 15)
			{
				Message = "Valor inválido. A Velocidade deve estar entre 0 e 15.";
				return false;
			}
			
			Speed = speed;
			DefineMovementState();
			return true;
		}
		
		/// <summary>
		/// Changes the speed of the drone.
		/// </summary>
		/// <param name="speed">The value to set the speed to. It has to be between 0 and 15.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid or if the drone is close to an object.</returns>
		public bool ChangeSpeed(double speed)
		{
			return SetSpeed(speed);
		}
		
		/// <summary>
		/// Changes the speed of the drone by incrementing or decrementing it by 0.5.
		/// </summary>
		/// <param name="increment">Whether to increment or decrement the speed.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid or if the drone is close to an object.</returns>
		public bool ChangeSpeed(bool increment)
		{
			if (increment)
			{
				if (Speed > 14.5 && Speed < 15)
				{
					return SetSpeed(15);
				}
				else
				{
					return SetSpeed(Speed + 0.5);
				}
			}
			else
			{
				if (Speed > 0 && Speed < 0.5)
				{
					return SetSpeed(0);
				}
				else
				{
					return SetSpeed(Speed - 0.5);
				}
			}
		}
		
		/// <summary>
		/// Defines the movement state of the drone based on its current speed.
		/// </summary>
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
		
		/// <summary>
		/// Shows the current movement state of the drone as a string.
		/// </summary>
		/// <returns>A string describing the current movement state of the drone.</returns>
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
		
		/// <summary>
		/// Simulates the drone approaching an object to utilize its arms.
		/// </summary>
		/// <returns>Whether the drone successfully approached the object or not.</returns>
		public bool ApproachObject()
		{
			if (DroneMovement == MovementState.Moving)
			{
				Message = "Não é possível aproximar de um objeto com o drone em movimento.";
				return false;
			}
			
			if (ApproachedObject)
			{
				Message = "O drone já está próximo de um objeto.";
				return false;
			}
			
			Message = "O drone se aproximou do objeto.";
			return ApproachedObject = true;
		}
		
		/// <summary>
		/// Simulates the drone distancing itself from an object.
		/// </summary>
		/// <returns>Whether the drone successfully distanced from the object or not.</returns>
		public bool DistanceFromObject()
		{
			if (!ApproachedObject)
			{
				Message = "O drone não está próximo de nenhum objeto.";
				return false;
			}
			
			Message = "O drone se distanciou do objeto.";
			return !(ApproachedObject = false);
		}
		
		/// <summary>
		/// Shows whether the drone is close to an object or not, as a string.
		/// </summary>
		/// <returns>A string describing if the drone is close to an object.</returns>
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
		
		/// <summary>
		/// Gives access to the drone's arms, by instancing the arm menu and starting it.
		/// </summary>
		/// <returns>Whether the drone successfulyl accessed its arms or not.</returns>
		public bool AccessDroneArms()
		{
			if (!ApproachedObject)
			{
				Message = "Os braços só podem ser usados próximo a um objeto.";
				return false;
			}
			else
			{
				ArmControlMenu armsMenu = new ArmControlMenu();
				armsMenu.Start(LeftArm, RightArm);
				return true;
			}
		}
	}
}
