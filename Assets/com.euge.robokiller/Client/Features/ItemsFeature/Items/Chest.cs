using System;
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

		private void Awake()
		{
			CloseChest();
		}
		
		public override void Interact()
		{
			_powerUp.Apply();
		}
		
		private void OpenChest()
		{
			_closedChest.SetActive(false);
			_openChest.SetActive(true);
		}
		
		private void CloseChest()
		{
			_closedChest.SetActive(true);
			_openChest.SetActive(false);
		}
	}
}
