using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features
{
	public class PlayerFeature : BaseService, IThemeable
	{
		public List<ThemeableElement> GetThemeableElements() => _player.GetThemeableElements();

		private string _playerConfigurationKey;
		private Player _player;
		private PlayerConfigugation _playerConfig;
		private Transform _parent;
		
		public RectTransform PlayerTransform => _player.PlayerTransform;
		
		public PlayerFeature(AppConfiguration appConfig, Transform parent) : base()
		{
			_parent = parent;
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
		}
		
		public async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);
			_player = await Loaders.Instantiate<Player>(_playerConfig.AddressableKey, _parent);
		}

		
	}
}
