using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class HealthUp : IPowerUp
	{
		public event PowerUpUpdateHandler OnAnimate;
		private PowerUpEffect _effect;
		private readonly IInventory _inventory;

		public HealthUp(PowerUpData data, IInventory inventory)
		{
			_inventory = inventory;
			PowerUpSprite = data.powerUpSprite;
			
			_effect = new PowerUpEffect
			{
				HealthDelta = (int) data.EffectValue,
			};
		}

		public void Apply()
		{
			_inventory.UpdateInventory(_effect);
		}
		
		public Sprite PowerUpSprite { get; }
		
		public void Stop()
		{
			// do clean job if needed, stop animations, etc 
		}
	}
}
