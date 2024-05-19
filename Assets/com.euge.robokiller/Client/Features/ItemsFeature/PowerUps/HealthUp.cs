using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class HealthUp : IPowerUp
	{
		public HealthUp()
		{
			//_player = player;
		}

		public void Apply()
		{
			//_player.IncreaseHealth();
		}
		public Sprite PowerUpSprite { get; }
	}
}
