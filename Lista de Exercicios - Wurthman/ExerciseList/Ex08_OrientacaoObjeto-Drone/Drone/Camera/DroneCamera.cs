/*
 * Date: 03/03/2024
 * Time: 16:03
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone.Camera
{
	public class DroneCamera
	{
		private int HorizontalAngle { get; set; }
		private int VerticalAngle { get; set; }
		
		private string Message { get; set; }
		
		public DroneCamera()
		{
			HorizontalAngle = 0;
			VerticalAngle = 0;
			Message = "";
		}
		
		#region Horizontal Angle
		/// <summary>
		/// Sets the horizontal angle of rotation of the camera. The value needs to be between 0 and 359.
		/// </summary>
		/// <param name="angle">The value to set the angle to.</param>
		/// <returns>Whether the value was successfully set or not.</returns>
		private bool SetHorizontalAngle(int angle)
		{
			if (angle < 0 || angle > 359)
			{
				Message = "Valor inválido. O ângulo deve star entre 0 e 359.";
				return false;
			}
			
			HorizontalAngle = angle;
			return true;
		}
		
		/// <summary>
		/// Changes the horizontal angle of rotation of the camera.
		/// </summary>
		/// <param name="angle">The value to set the angle to. It has to be between 0 and 359.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid.</returns>
		public bool ChangeHorizontalAngle(int angle)
		{
			return SetHorizontalAngle(angle);
		}
		
		/// <summary>
		/// Changes the horizontal angle of rotation of the camera, by either incrementing or decrementing 5 degrees. The angle rolls over if past 0 or 359.
		/// </summary>
		/// <param name="clockwise">Whether to increment or decrement the angle.</param>
		public void ChangeHorizontalAngle(bool clockwise)
		{
			int angle = HorizontalAngle;
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
			SetHorizontalAngle(angle);
		}
		#endregion
		
		#region Vertical Angle
		/// <summary>
		/// Sets the vertical angle of rotation of the camera. The value needs to be between 0 and 359.
		/// </summary>
		/// <param name="angle">The value to set the angle to.</param>
		/// <returns>Whether the value was successfully set or not.</returns>
		private bool SetVerticalAngle(int angle)
		{
			if (angle < 0 || angle > 359)
			{
				Message = "Valor inválido. O ângulo deve star entre 0 e 359.";
				return false;
			}
			
			VerticalAngle = angle;
			return true;
		}
		
		/// <summary>
		/// Changes the vertical angle of rotation of the camera.
		/// </summary>
		/// <param name="angle">The value to set the angle to. It has to be between 0 and 359.</param>
		/// <returns>Whether the value was successfully set or not. It fails if the value is invalid.</returns>
		public bool ChangeVerticalAngle(int angle)
		{
			return SetVerticalAngle(angle);
		}
		
		/// <summary>
		/// Changes the horizontal angle of rotation of the camera, by either incrementing or decrementing 5 degrees. The angle rolls over if past 0 or 359.
		/// </summary>
		/// <param name="clockwise">Whether to increment or decrement the angle.</param>
		public void ChangeVerticalAngle(bool clockwise)
		{
			int angle = VerticalAngle;
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
			SetVerticalAngle(angle);
		}
		#endregion
		
		
	}
}
