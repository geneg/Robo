using System;
using System.Collections.Generic;
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
		public event Action<BaseItem> OnItemInteracted;
		
		private readonly string _playerConfigurationKey;
		private Player _player;
		private PlayerConfigugation _playerConfig;
		private readonly Transform _parent;
		private BaseItem _interactibleItem;
		private MovementFeature _movementFeature;
		private IInventory _inventory;

		public PlayerFeature(AppConfiguration appConfig, Transform parent)
		{
			_parent = parent;
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
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
			_player.OnItemInteracted += OnItemInteractedInner;
			_player.OnClicked += OnPlayerClicked;
			_player.Relax();
			_player.PlayerTransform.anchoredPosition = position;
		}

		public void ApplyPowerUp(PowerUpEffect effect)
		{
			_inventory.UpdateInventory(effect);
		}
		
		private void OnPlayerClicked()
		{
			_movementFeature.ResumeMove();
		}

		private void OnItemInteractedInner(BaseItem item)
		{
			OnItemInteracted?.Invoke(item); // Forwarding the event
			_interactibleItem = item;
		}

		public void PlayerInteraction()
		{
			_player.Attack();
		}

		public void Hit()
		{
			
		}
		
		public void MoveTo(Vector2 position)
		{
			_player.PlayerTransform.anchoredPosition = position;
		}
		
		
	}
}
