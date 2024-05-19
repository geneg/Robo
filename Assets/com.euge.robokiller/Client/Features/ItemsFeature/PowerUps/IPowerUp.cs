using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public delegate void PowerUpUpdateHandler();
	
	public interface IPowerUp
	{
		event PowerUpUpdateHandler OnAnimate;
		
		void Apply();
		Sprite PowerUpSprite { get; }
		void Stop();
	}
}
