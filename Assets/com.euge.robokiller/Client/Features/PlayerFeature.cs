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
		private Transform _parent;
		private Player _player;
		
		public PlayerFeature(AppConfiguration appConfig, Transform parent) : base()
		{
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
			_parent = parent;
		}

		
		public async Task Initialize()
		{
			PlayerConfigugation playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);
			_player = await Loaders.Instantiate<Player>(playerConfig.AddressableKey, _parent);
		}
		
		public void Move(Vector2[] position)
		{
			//_player.transform.localPosition = position;
		}
		
		public void MoveInstant(Vector2 position)
		{
			_player.transform.localPosition = position;
		}
	}
}
