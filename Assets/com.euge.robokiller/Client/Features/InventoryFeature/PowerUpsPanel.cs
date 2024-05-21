using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class PowerUpsPanel : MonoBehaviour
	{
		[SerializeField] private PowerUpSlot _powerUpSlotPrefab;
		private List<PowerUpSlot> _powerUpSlots = new List<PowerUpSlot>();
		public void AddPowerUp(PowerUpEffect effect)
		{
			PowerUpSlot newSlot = Instantiate(_powerUpSlotPrefab, transform);
			newSlot.SetPowerUp(effect);
			_powerUpSlots.Add(newSlot);
		}
		
		public void RemovePowerUp(PowerUpEffect effect)
		{
			foreach (PowerUpSlot powerUpSlot in _powerUpSlots)
			{
				if (powerUpSlot.PowerUpEffect == effect)
				{
					Destroy(powerUpSlot.gameObject);
					_powerUpSlots.Remove(powerUpSlot);
					break;
				}
			}
		}
	}
}
