using System.Collections.Generic;
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
		private readonly InventoryData _inventoryData;
		private readonly List<PowerUpEffect> _collection = new List<PowerUpEffect>();
		
		public InventoryFeature(AppConfiguration appConfig, InventoryPanel inventoryPanel)
		{
			
			_inventoryData = new InventoryData();
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
			_inventoryPanel = inventoryPanel;
		}
		
		public List<PowerUpEffect> GetCollection()
		{
			return _collection;
		}
		
		public override async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);

			_inventoryData.Health = _playerConfig.InitialHealth;
			_inventoryData.Rank = _playerConfig.InitialRank;
			_inventoryData.TotalHealth = _playerConfig.totalHealth;

			_inventoryPanel.Init(_inventoryData);
		}

		public void UpdatePlayerStats(PowerUpEffect effect)
		{
			if (effect.HealthDelta != 0)
			{
				_inventoryData.Health += effect.HealthDelta;
				_inventoryPanel.SetHealth(_inventoryData.Health);
			}
			
			if (effect.Rank != 0)
			{
				_inventoryData.Rank += effect.Rank;
				_inventoryPanel.SetRank(_inventoryData.Rank);
			}
		}

		public void AddPowerUpToView(PowerUpEffect effect)
		{
			_inventoryPanel.AddPowerUp(effect);
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

		public readonly Dictionary<PowerUpType, PowerUpEffect> PowerUps = new Dictionary<PowerUpType, PowerUpEffect>();
	}
}
