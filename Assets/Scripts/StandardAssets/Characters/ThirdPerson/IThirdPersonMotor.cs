﻿using UnityEngine;

namespace StandardAssets.Characters.ThirdPerson
{
	/// <summary>
	/// A mapping between movement values and values used in the animator
	/// </summary>
	public interface IThirdPersonMotor 
	{
		#region Properties
		/// <summary>
		/// The turning speed. Range =  -1 (rotate anticlockwise) to 1 (rotate clockwise). 0 is not turning.
		/// </summary>
		float turningSpeed { get; }
		
		/// <summary>
		/// The lateral speed. Range = - 1 (strafe left) to 1 (strafe). 0 is no strafing
		/// </summary>
		float lateralSpeed { get; }
		
		/// <summary>
		/// The forward speed. Range = -1 (run backwards) to 1 (run forwards). 0 is no forward movement 
		/// </summary>
		float forwardSpeed { get; }
		
		#endregion
	}
}
