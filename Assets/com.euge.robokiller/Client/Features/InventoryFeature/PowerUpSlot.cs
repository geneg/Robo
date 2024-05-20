using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class PowerUpSlot : MonoBehaviour
	{
		[SerializeField] private Image _powerImage;
		public void SetPowerUp(PowerUpEffect effect)
		{
			_powerImage.sprite = effect.PowerUpSprite;
			gameObject.SetActive(true);
		}
	}
}
