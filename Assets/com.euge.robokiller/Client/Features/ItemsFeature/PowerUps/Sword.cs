using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;


namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Sword : BasePowerUp, IPowerUp
	{
		private readonly PowerUpData _data;
		public Sword(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
			_data = data;
		}

		public void Apply()
		{
			_effect = new PowerUpEffect
			{
				PowerUpType = _data.powerUpType,
				IsInvertoryItem = true,
				Attack = (int) _data.EffectValue,
				PowerUpSprite = PowerUpSprite
			};
			
			_playerFeature.ApplyDelayedPowerUp(_effect);
		}

		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
	}
}
