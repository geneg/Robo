using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ThemesFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public class PlayerFeature : BaseService, IThemeable
	{
		public List<ThemeableElement> GetThemeableElements() => _player.GetThemeableElements();

		private readonly string _playerConfigurationKey;
		private Player _player;
		private PlayerConfigugation _playerConfig;
		private readonly Transform _parent;
		
		public PlayerFeature(AppConfiguration appConfig, Transform parent, ServiceResolver resolver) : base(resolver)
		{
			_parent = parent;
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
		}

		public override async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);
			_player = await Loaders.Instantiate<Player>(_playerConfig.AddressableKey, _parent);
		}

		public void BeginPlayerMove(Vector2 position)
		{
			_player.SetIdlePose();
			_player.PlayerTransform.anchoredPosition = position;
		}

		public void MoveTo(Vector2 position)
		{
			_player.PlayerTransform.anchoredPosition = position;
		}
	}
}
