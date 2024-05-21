using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.ThemesFeature;
using com.euge.robokiller.Configs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public class PlayerFeature : BaseService, IThemeable, IPlayerFeature
	{
		public List<ThemeableElement> GetThemeableElements() => _player.GetThemeableElements();
		public float GetSpeed() => _playerConfig.Speed;
		
		private readonly string _playerConfigurationKey;
		private Player _player;
		private PlayerConfigugation _playerConfig;
		private readonly Transform _parent;
		private MovementFeature _movementFeature;
		private IInventory _inventory;
		private bool _isDead;
		private List<PowerUpEffect> _collection;
		
		public PlayerFeature(AppConfiguration appConfig, Transform parent)
		{
			_parent = parent;
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
		}

		public void SetCollection(List<PowerUpEffect> collection)
		{
			_collection = collection;
		}
		
		public override async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);
			_player = await Loaders.Instantiate<Player>(_playerConfig.AddressableKey, _parent);
			
			_inventory = GetServiceResolver.GetService<InventoryFeature.InventoryFeature>();
			_movementFeature = GetServiceResolver.GetService<MovementFeature>();
		}
		
		public void BeginPlayerMove(Vector2 position)
		{
			_player.OnItemInteracted += OnItemInteracted;
			_player.OnClicked += OnPlayerClicked;
			_player.Relax();
			_player.PlayerTransform.anchoredPosition = position;
		}

		public void ApplyDelayedPowerUp(PowerUpEffect effect)
		{
			if (_collection.All(e => e.PowerUpType != effect.PowerUpType))
			{
				_collection.Add(effect);
				_inventory.AddPowerUpToView(effect);
			}
		}
		
		public void ApplyPowerUp(PowerUpEffect effect)
		{
			_inventory.UpdatePlayerStats(effect);
			
			if (effect.HealthDelta < 0) // if health affected negatively, then check if player is dead
			{
				_player.Hit();
				InventoryData inventoryData = _inventory.ReadInventory();
				
				if (inventoryData.Health <= 0)
				{
					_isDead = true;
					effect.Stop();
					_player.Die();
				}
			}
		}
		
		private void OnPlayerClicked()
		{
			if (_isDead) return;
			_movementFeature.ResumeMove();
		}

		private void OnItemInteracted(BaseItem item)
		{
			item.Interact();
			_movementFeature.PauseMove();
		}

		//returns true if player is alive and can interact with the item
		public bool PlayerInteraction()
		{
			if (_isDead) return false;
			
			_player.Attack();
			return true;
		}
		
		public void MoveTo(Vector2 position)
		{
			_player.PlayerTransform.anchoredPosition = position;
		}
		
		
	}
}
