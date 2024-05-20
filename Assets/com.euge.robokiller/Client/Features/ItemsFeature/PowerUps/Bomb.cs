using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Bomb : BasePowerUp, IPowerUp
	{
		private PowerUpEffect _effect;
		
		public event PowerUpUpdateHandler OnAnimate;
		
		public Bomb(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
		}
		
		public void Apply()
		{
			_effect = new PowerUpEffect
			{
				EnemyDamage = 1000,
				UseCount = 1,
				PowerUpSprite = PowerUpSprite
			};
		}
		
		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
		
		

	}
}
