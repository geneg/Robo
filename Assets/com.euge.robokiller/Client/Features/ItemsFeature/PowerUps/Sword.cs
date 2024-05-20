using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;


namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Sword : BasePowerUp, IPowerUp
	{
		public Sword(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature) { }

		public void Apply()
		{
			_effect = new PowerUpEffect
			{
				IsInvertoryItem = true,
				PowerUpSprite = PowerUpSprite
			};
		}

		public void StopEffect()
		{
			// do clean job if needed, stop animations, etc 
		}
	}
}
