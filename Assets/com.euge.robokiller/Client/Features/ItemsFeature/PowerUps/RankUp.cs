using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class RankUp : BasePowerUp, IPowerUp
	{
		public RankUp(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
			_effect = new PowerUpEffect
			{
				PowerUpType = data.powerUpType,
				Rank = (int) data.EffectValue,
			};
		}
		public void Apply()
		{
			_playerFeature.ApplyPowerUp(_effect);
		}
		
		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
		
	}
}
