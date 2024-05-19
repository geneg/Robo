using System;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Chest : BaseItem
	{
		[SerializeField] private Image _item;
		[SerializeField] private GameObject _closedChest;
		[SerializeField] private GameObject _openChest;
		
		private void Awake()
		{
			CloseChest();
		}
		
		public override async void Interact()
		{
			await InvokeRequestPowerUp();
			
			OpenChest();
			_item.sprite = _powerUp.PowerUpSprite;
			
			_item.gameObject.SetActive(true);
			_item.transform.localScale = Vector3.zero;
			
			_item.transform.DOPunchScale(Vector3.one * 3, 1f, 0, 0).SetEase(Ease.OutBounce).OnComplete(() => {
				_powerUp.Stop();
				CloseChest();
				
				gameObject.SetActive(false);
				InvokeOnItemExhaust();
				
			});
			
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
			_item.gameObject.SetActive(false);
			_item.transform.localScale = Vector3.zero;
			_openChest.SetActive(false);
		}
	}
}
