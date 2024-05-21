using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Shield : BasePowerUp, IPowerUp
	{
		public Shield(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
			_effect = new PowerUpEffect
			{
				PowerUpType = data.powerUpType,
				IsInvertoryItem = true,
				Defense = (int) data.EffectValue,
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
