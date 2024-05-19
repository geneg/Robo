using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class RankUp : IPowerUp
	{
		private readonly IInventory _inventory;
		private readonly PowerUpEffect _effect;
		public event PowerUpUpdateHandler OnAnimate;

		public RankUp(PowerUpData data, IInventory inventory)
		{
			_inventory = inventory;
			PowerUpSprite = data.powerUpSprite;
			
			_effect = new PowerUpEffect
			{
				Rank = (int) data.EffectValue,
			};
		}
		public void Apply()
		{
			_inventory.UpdateInventory(_effect);
		}
		
		public void Stop()
		{
			// do clean job if needed, stop animations, etc 
		}
		
		public Sprite PowerUpSprite { get; }
	}
}
