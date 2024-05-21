using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public interface IPlayerFeature
	{
		void ApplyPowerUp(PowerUpEffect effect);
		void ApplyDelayedPowerUp(PowerUpEffect effect);
	}
}
