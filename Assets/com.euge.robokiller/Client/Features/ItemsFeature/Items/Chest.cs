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
		
		public override void Interact()
		{
			OpenChest();
		}
		
		private void OpenChest()
		{
			_closedChest.SetActive(false);
			_openChest.SetActive(true);
			//_item.gameObject.SetActive(true);
			//_item.transform.localScale = Vector3.zero;
			//_item.transform.DOPunchScale(Vector3.one, 0.5f);
		}
		
		private void CloseChest()
		{
			_closedChest.SetActive(true);
			//_item.gameObject.SetActive(false);
			//_item.transform.localScale = Vector3.zero;
			_openChest.SetActive(false);
		}
	}
}
