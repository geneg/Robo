using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Sword : BasePowerUp, IPowerUp
	{
		private readonly IInventory _inventory;
		public event PowerUpUpdateHandler OnAnimate;
		
		public Sword(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
		}
		
		public void Apply()
		{
			// Apply bomb powerup
		}
		
		public void Stop()
		{
			// do clean job if needed, stop animations, etc 
		}
	}
}
