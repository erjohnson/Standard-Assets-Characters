﻿using System;
using StandardAssets.Characters.Attributes;
using StandardAssets.Characters.Common;
using UnityEngine;

namespace StandardAssets.Characters.Effects
{
	/// <summary>
	/// Abstract class for handling MovementEvents
	/// </summary>
	[Serializable]
	public abstract class MovementEventHandler
	{
		[SerializeField, Tooltip("Use the level default movement event library instead of the character library")]
		protected bool useLevelDefaultMovementEventLibrary;
		
		[VisibleIf("useLevelDefaultMovementEventLibrary", false), SerializeField, Tooltip("This is default event library that used")]
		protected MovementEventLibrary defaultMovementEventLibrary;

		[SerializeField, Tooltip("List of movement event libraries for different movement zones")]
		protected MovementEventZoneDefinitionList zonesDefinition;

		protected MovementEventLibrary currentMovementEventLibrary;

		protected MovementEventLibrary defaultLibrary
		{
			get
			{
				if (useLevelDefaultMovementEventLibrary)
				{
					LevelMovementZoneConfiguration configuration = LevelMovementZoneManager.config;
					if (configuration != null)
					{
						return configuration.defaultLibrary;
					}
				}

				return defaultMovementEventLibrary;
			}
		}

		protected CharacterBrain brain;
		
		/// <summary>
		/// Sets the current <see cref="MovementEventLibrary"/>
		/// </summary>
		/// <param name="newMovementEventLibrary">Movement event library data</param>
		public void SetCurrentMovementEventLibrary(MovementEventLibrary newMovementEventLibrary)
		{
			currentMovementEventLibrary = newMovementEventLibrary;
		}
		

		/// <summary>
		/// Sets the current event library to the starting event library
		/// </summary>
		public virtual void Init(CharacterBrain brainToUse)
		{
			brain = brainToUse;
			brain.changeMovementZone += ChangeMovementZone;
			SetCurrentMovementEventLibrary(defaultLibrary);
		}

		private void ChangeMovementZone(string zoneId)
		{
			MovementEventLibrary library = zonesDefinition[zoneId];

			if (library != null)
			{
				SetCurrentMovementEventLibrary(library);
				return;
			}

			LevelMovementZoneConfiguration configuration = LevelMovementZoneManager.config;

			if (configuration != null)
			{
				library = configuration[zoneId];
				if (library != null)
				{
					SetCurrentMovementEventLibrary(library);
					return;
				}
			}
			
			SetCurrentMovementEventLibrary(defaultLibrary);
		}

		protected virtual void PlayLeftFoot(MovementEventData data)
		{
			currentMovementEventLibrary.PlayLeftFoot(data);
		}
		
		protected virtual void PlayRightFoot(MovementEventData data)
		{
			currentMovementEventLibrary.PlayRightFoot(data);
		}
		
		protected virtual void PlayLanding(MovementEventData data)
		{
			currentMovementEventLibrary.PlayLanding(data);
		}
		
		protected virtual void PlayJumping(MovementEventData data)
		{
			currentMovementEventLibrary.PlayJumping(data);
		}
	}
}