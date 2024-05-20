using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class PowerUpsPanel : MonoBehaviour
	{
		[SerializeField] private PowerUpSlot _powerUpSlotPrefab;
		
		public void AddPowerUp(PowerUpEffect effect)
		{
			PowerUpSlot newSlot = Instantiate(_powerUpSlotPrefab, transform);
			newSlot.SetPowerUp(effect);
		}
		
		public void RemovePowerUp(int id)
		{
			
		}
	}
}
