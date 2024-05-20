using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Rank : BaseItem
	{
		[SerializeField] private GameObject _rankIcon;
		
		public override void Interact()
		{
			transform.DOPunchScale(Vector3.one * 1.5f, 0.8f, 0).SetEase(Ease.OutBounce).OnComplete(() => {
				_powerUp.StopEffect();
				gameObject.SetActive(false);
				InvokeOnItemExhaust();
			});
			
			_powerUp.Apply();
		}
	}
}
