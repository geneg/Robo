namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public delegate void PowerUpUpdateHandler();
	public interface IAnimatablePowerUp
	{
		event PowerUpUpdateHandler OnAnimate;
	}
}
