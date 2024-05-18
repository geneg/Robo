using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Chest : BaseItem
	{
		[SerializeField] private GameObject _closedChest;
		[SerializeField] private GameObject _openChest;
		
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
