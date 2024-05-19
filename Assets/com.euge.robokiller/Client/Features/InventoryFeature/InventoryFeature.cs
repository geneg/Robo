using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class InventoryFeature : BaseService, IInventory
	{
		private readonly string _playerConfigurationKey;
		private PlayerConfigugation _playerConfig;
		private readonly InventoryPanel _inventoryPanel;

		private InventoryData _inventoryData;

		public InventoryFeature(AppConfiguration appConfig, InventoryPanel inventoryPanel)
		{
			_inventoryData = new InventoryData();
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
			_inventoryPanel = inventoryPanel;
		}

		public override async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);

			_inventoryData.Health = _playerConfig.InitialHealth;
			_inventoryData.Rank = _playerConfig.InitialRank;
			_inventoryData.TotalHealth = _playerConfig.totalHealth;

			_inventoryPanel.Init(_inventoryData);
		}

		public void UpdateInventory(PowerUpEffect effect)
		{
			//health
			int oldValue = _inventoryData.Health;
			_inventoryData.Health += effect.HealthDelta;
			
			if (oldValue != _inventoryData.Health)
			{
				_inventoryPanel.SetHealth(_inventoryData.Health);
			}
			
			//rank
			oldValue = _inventoryData.Rank;
			_inventoryData.Rank += effect.Rank;
			
			if (oldValue != _inventoryData.Rank)
			{
				_inventoryPanel.SetRank(_inventoryData.Rank);
			}
			
			
		}

		public InventoryData ReadInventory()
		{
			return _inventoryData;
		}

	}

	public class InventoryData
	{
		public int Health { get; set; }
		public int Rank { get; set; }
		public int TotalHealth { get; set; }
	}
}
