namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class Chest : BaseItem
	{
		private IPowerUp _powerUp;

		public Chest(IPowerUp powerUp)
		{
			_powerUp = powerUp;
		}

		public override void Interact()
		{
			_powerUp.Apply();
		}
	}
}
