using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Bomb : BasePowerUp, IPowerUp
	{
		public Bomb(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
			_effect = new PowerUpEffect
			{
				PowerUpType = data.powerUpType,
				IsInvertoryItem = true,
				PowerUpSprite = PowerUpSprite
			};
		}
		
		public void Apply()
		{
			
			
			_playerFeature.ApplyDelayedPowerUp(_effect);
		}
		
		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
		
		

	}
}
