using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Shield : IPowerUp
	{
		private readonly IInventory _inventory;
		public event PowerUpUpdateHandler OnAnimate;
		public Shield(PowerUpData data, IInventory inventory)
		{
			_inventory = inventory;
			PowerUpSprite = data.powerUpSprite;
		}
		public void Apply()
		{
			// Apply shield powerup
		}
		
		public void Stop()
		{
			// do clean job if needed, stop animations, etc 
		}
		
		public Sprite PowerUpSprite { get; }
	}
}
