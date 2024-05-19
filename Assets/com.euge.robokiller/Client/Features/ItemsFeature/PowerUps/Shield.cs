using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class Shield : IPowerUp
	{
		public event PowerUpUpdateHandler OnAnimate;
		
		public void Apply()
		{
			// Apply shield powerup
		}
		public Sprite PowerUpSprite { get; }
	}
}
