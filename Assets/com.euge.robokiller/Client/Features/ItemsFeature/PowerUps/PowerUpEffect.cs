using System;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class PowerUpEffect
	{
		public event Action OnStopEffect;
		
		public int HealthDelta { get; set; }
		public int Rank { get; set; }
		
		public void Stop()
		{
			OnStopEffect?.Invoke();
		}
		
	}
}
