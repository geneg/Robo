using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using TMPro;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class InventoryPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text _rankText;
		[SerializeField] private HealthBar _healthBar;
		[SerializeField] private PowerUpsPanel _powerUpsPanel;
		
		public void SetHealth(int health)
		{
			_healthBar.SetHealth(health);
		}
		
		public void SetRank(int rank)
		{
			_rankText.text = rank.ToString();
		}
		
		public void Init(InventoryData inventoryData)
		{
			_healthBar.Init(inventoryData.TotalHealth, inventoryData.Health);
			SetRank(inventoryData.Rank);
		}
		
		public void AddPowerUp(PowerUpEffect effect)
		{
			_powerUpsPanel.AddPowerUp(effect);
		}
	}
}
