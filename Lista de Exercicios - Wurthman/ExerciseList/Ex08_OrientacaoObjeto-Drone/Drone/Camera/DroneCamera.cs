/*
 * Date: 03/03/2024
 * Time: 16:03
 */
using System;

namespace Ex08_OrientacaoObjeto_Drone.Drone.Camera
{
	public class DroneCamera
	{
		#region Properties
		/// <summary>
		/// The camera's horizontal angle of rotation.
		/// </summary>
		public int HorizontalAngle { get; set; }
		
		/// <summary>
		/// The camera's vertical angle of rotation.
		/// </summary>
		public int VerticalAngle { get; set; }
		
		/// <summary>
		/// The current state of the camera.
		/// </summary>
		private CameraState State { get; set; }
		
		/// <summary>
		/// The message tied to the last action performed by the camera, that describes whether it was successful or failed.
		/// </summary>
		private string Message { get; set; }
		#endregion
		
		/// <summary>
		/// Default constructor, which sets the default values for all camera properties.
		/// </summary>
		public DroneCamera()
		{
			HorizontalAngle = 0;
			VerticalAngle = 0;
			Message = "";
			State = CameraState.PhotoMode;
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
		
		/// <summary>
		/// Changes the camera mode between Photo and Video modes.
		/// </summary>
		/// <returns>Whether the mode was changed or not. It fails if the camera is currently recording.</returns>
		public bool ChangeCameraMode()
		{
			if (State == CameraState.Recording)
			{
				Message = "Não é possível mudar o modo enquanto a câmera está gravando.";
				return false;
			}
			
			if (State == CameraState.PhotoMode)
			{
				State = CameraState.VideoMode;
				Message = "Modo da câmera: Gravar vídeos.";
			}
			else
			{
				State = CameraState.PhotoMode;
				Message = "Modo da câmera: Tirar fotos.";
			}
			return true;
		}
		
		/// <summary>
		/// Returns the current camera state as a string.
		/// </summary>
		/// <returns>A string describing the camera's current state.</returns>
		public string GetCameraMode()
		{
			switch(State)
			{
				case CameraState.Inactive:
					return "Inativo.";
				case CameraState.PhotoMode:
					return "Capturar Fotos.";
				case CameraState.VideoMode:
					return "Gravar Vídeos.";
				default:
					return "Gravando vídeo...";
			}
		}
		
		/// <summary>
		/// Simulates the camera taking a picture. The camera needs to be in Photo mode to be able to take pictures.
		/// </summary>
		/// <returns>Whether the camera successfully took a picture or not.</returns>
		public bool TakePicture()
		{
			if (State != CameraState.PhotoMode)
			{
				Message = "A câmera deve estar no modo Captura de Fotos para tirar fotos.";
				return false;
			}
			
			Message = "O drone capturou uma foto.";
			return true;
		}
		
		/// <summary>
		/// Simulates the camera recording a video. The camera needs to be in Video mode to be able to record.
		/// If the camera is already recording, this ends the recording and saves the video.
		/// </summary>
		/// <returns>Whether the camera successfully started recording a video.</returns>
		public bool ToggleRecordingVideo()
		{
			if (State == CameraState.PhotoMode)
			{
				Message = "A câmera deve estar no modo Gravar Vídeos para gravar um vídeo.";
				return false;
			}
			
			if (State == CameraState.VideoMode)
			{
				State = CameraState.Recording;
				Message = "O drone iniciou a gravação de um vídeo.";
			}
			else
			{
				State = CameraState.VideoMode;
				Message = "A grvação foi finalizada e o vídeo foi salvo.";
			}
			return true;
		}
		
		/// <summary>
		/// Activates the camera, setting it to Photo Mode by default.
		/// </summary>
		public void ActivateCamera()
		{
			State = CameraState.PhotoMode;
		}
		
		/// <summary>
		/// Deactivates the camera, setting it to Inactive mode.
		/// </summary>
		/// <returns>Whether the camera was deactivated or not. It can't be deactivated while recording a video.</returns>
		public bool DeactivateCamera()
		{
			if (State == CameraState.Recording)
			{
				Message = "Não é possível desligar a câmera durante a gravação de um vídeo.";
				return false;
			}
			else
			{
				State = CameraState.Inactive;
				return true;
			}
		}
	}
}
