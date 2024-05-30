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
using Unity.VisualScripting;
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
		private PopupFeature.PopupFeature _popupFeature;

		//public event Action OnRestart;
		
		public PlayerFeature(string configKey, Transform parent)
		{
			_parent = parent;
			_playerConfigurationKey = configKey;
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
			_popupFeature = GetServiceResolver.GetService<PopupFeature.PopupFeature>();
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
				Debug.Log("add " + effect.PowerUpType + " to collection");
				_collection.Add(effect);
				_inventory.AddPowerUpToView(effect);
			}
		}
		
		public void ApplyPowerUp(PowerUpEffect effect)
		{
			int idx;
			for (idx=0; idx<_collection.Count; idx++)
			{
				if (_collection[idx].Defense <= 0) continue;
				break;
			}
			
			if (effect.HealthDelta < 0 && _collection.Count > idx  && _collection[idx].Defense > 0)
			{
				_collection[idx].Defense--;
				
				if(_collection[idx].Defense == 0)
				{
					_collection[idx].MarkAsUsed();
					_inventory.RemovePowerUpFromView(_collection[idx]);
					_collection.RemoveAt(idx);
				}
				
				PowerUpEffect defenseEffect = new PowerUpEffect
				{
					PowerUpType = effect.PowerUpType,
					HealthDelta = 0,
				};
				
				_inventory.UpdatePlayerStats(defenseEffect);
			}
			else
			{
				_inventory.UpdatePlayerStats(effect);
			}
			
			// if shield is active then the update to inventory was not done,
			// so the part of code below will play hit animation but will not affect the player health
			if (effect.HealthDelta < 0) 
			{
				_player.Hit();
				InventoryData inventoryData = _inventory.ReadInventory();
				
				if (inventoryData.Health <= 0)
				{
					_isDead = true;
					effect.Stop();
					_player.Die();
					
					_popupFeature.ShowPopup(false, () =>
					{
						//TODO: add logic to restart the game
						
						
						
					});
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
