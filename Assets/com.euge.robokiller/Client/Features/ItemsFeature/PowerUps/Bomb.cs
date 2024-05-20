using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Bomb : BasePowerUp, IPowerUp
	{
		public event PowerUpUpdateHandler OnAnimate;
		
		public Bomb(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
		}
		
		public void Apply()
		{
			// Apply bomb powerup
		}
		
		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
		
		

	}
}
