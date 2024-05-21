using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class PowerUpSlot : MonoBehaviour
	{
		[SerializeField] private Image _powerImage;
		private PowerUpEffect _powerUpEffect;
		public PowerUpEffect PowerUpEffect => _powerUpEffect;
		public void SetPowerUp(PowerUpEffect effect)
		{
			_powerUpEffect = effect;
			_powerImage.sprite = _powerUpEffect.PowerUpSprite;
			gameObject.SetActive(true);
		}
	}
}
