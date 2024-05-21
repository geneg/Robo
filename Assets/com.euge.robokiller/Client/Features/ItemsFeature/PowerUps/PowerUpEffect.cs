using System;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class PowerUpEffect
	{
		public event Action OnStopEffect;
		public PowerUpType PowerUpType { get; set; }
		public Sprite PowerUpSprite { get; set; }
		public bool IsInvertoryItem { get; set; }
		public int HealthDelta { get; set; }
		public int Rank { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int BlowUp { get; set; }
		public bool IsUsed => _isUsed;
		
		private bool _isUsed;
		
		public void Stop()
		{
			OnStopEffect?.Invoke();
		}

		public void MarkAsUsed()
		{
			_isUsed = true;
		}
	}
}
