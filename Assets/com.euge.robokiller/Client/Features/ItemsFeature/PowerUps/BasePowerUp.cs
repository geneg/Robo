using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public abstract class BasePowerUp
	{
		public Sprite PowerUpSprite { get; }
		protected readonly IPlayerFeature _playerFeature;
		
		protected BasePowerUp(PowerUpData data, IPlayerFeature playerFeature)
		{
			_playerFeature = playerFeature;
			PowerUpSprite = data.powerUpSprite;
		}
	}
}
