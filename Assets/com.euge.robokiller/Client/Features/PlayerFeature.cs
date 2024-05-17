using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features
{
	public class PlayerFeature : BaseService, IThemeable
	{
		public List<ThemeableElement> GetThemeableElements() => _player.GetThemeableElements();

		private readonly string _playerConfigurationKey;
		private Player _player;
		private PlayerConfigugation _playerConfig;
		private readonly Transform _parent;
		private int _playerPathIndex;
		private PathFeature _pathFeature;
		
		public PlayerFeature(AppConfiguration appConfig, Transform parent, ServiceResolver resolver) : base(resolver)
		{
			_parent = parent;
			_playerConfigurationKey = appConfig.PlayerConfigurationKey;
		}

		public override async Task Initialize()
		{
			_playerConfig = await Loaders.LoadAsset<PlayerConfigugation>(_playerConfigurationKey);
			_player = await Loaders.Instantiate<Player>(_playerConfig.AddressableKey, _parent);

			_pathFeature = GetServiceResolver.GetService<PathFeature>(); // Features can know about other features
		}

		public void BeginPlayerMove()
		{
			_playerPathIndex = 0;
			_player.PlayerTransform.anchoredPosition = _pathFeature.GetPathPoint(_playerPathIndex++);
			
			CyclicPlayerMove();
		}

		private void CyclicPlayerMove()
		{
			Vector2 currentPoint = _pathFeature.GetPathPoint(_playerPathIndex - 1);
			Vector2 nextPoint = GetNextPlayerPathPoint();

			float distance = Vector2.Distance(currentPoint, nextPoint);
			float speed = 200f; // Define your speed here

			float duration = distance / speed;

			_player.PlayerTransform.DOAnchorPos(nextPoint, duration, true)
				.SetEase(_pathFeature.IsLastSection ? Ease.OutCubic : Ease.Linear)
				.OnComplete(() => {
					if (!_pathFeature.IsLastSection)
					{
						CyclicPlayerMove();
					}
				});
		}

		private Vector2 GetNextPlayerPathPoint()
		{
			if (!_pathFeature.IsLastSection)
			{
				return _pathFeature.GetPathPoint(_playerPathIndex++);
			}

			_playerPathIndex = 0;
			return GetNextPlayerPathPoint();
		}

	}
}
