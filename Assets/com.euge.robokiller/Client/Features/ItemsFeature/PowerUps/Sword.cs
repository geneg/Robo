using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Sword : IPowerUp
	{
		public event PowerUpUpdateHandler OnAnimate;

		public void Apply()
		{
			// Apply bomb powerup
		}
		
		public Sprite PowerUpSprite { get; }

	}
}
