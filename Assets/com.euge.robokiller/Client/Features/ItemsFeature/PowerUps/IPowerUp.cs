using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	
	
	public interface IPowerUp
	{
		void Apply();
		Sprite PowerUpSprite { get; }
		void StopEffect();
	}
}
