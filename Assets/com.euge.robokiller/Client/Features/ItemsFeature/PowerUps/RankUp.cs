using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class RankUp : IPowerUp
	{
		public RankUp(PowerUpData data)
		{
			PowerUpSprite = data.powerUpSprite;
		}
		public void Apply()
		{
			// Apply rank powerup
		}
		
		public Sprite PowerUpSprite { get; }
	}
}
