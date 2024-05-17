using System;
using System.Threading.Tasks;
using com.euge.minigame;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features;
using DG.Tweening;
using UnityEngine;


namespace com.euge.robokiller.Client
{
	public class RoboKiller : Minigame
	{
		private readonly ServiceResolver _clientServiceResolver = new ServiceResolver();
		private readonly VisualBridge _visualBridge;
		private ThemesFeature _themesFeatureFeature;
		private PathFeature _pathFeatureFeature;
		private PlayerFeature _playerFeature;

		public RoboKiller(VisualBridge visualBridge)
		{
			_visualBridge = visualBridge;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			AppConfiguration appConfig = _serviceResolver.GetService<Config>().AppConfig;

			_themesFeatureFeature = new ThemesFeature(appConfig, _clientServiceResolver);
			_clientServiceResolver.RegisterService(_themesFeatureFeature);

			_pathFeatureFeature = new PathFeature(appConfig, _visualBridge.GameContentParent, _clientServiceResolver);
			_clientServiceResolver.RegisterService(_pathFeatureFeature);

			_playerFeature = new PlayerFeature(appConfig, _visualBridge.GameContentParent, _clientServiceResolver);
			_clientServiceResolver.RegisterService(_playerFeature);

			_clientServiceResolver.RegisterService(new ScrollFeature(_visualBridge.ScrollRect, _clientServiceResolver));

			await _clientServiceResolver.InitializeServices();

			_themesFeatureFeature.ApplyTheme(_pathFeatureFeature);
			_themesFeatureFeature.ApplyTheme(_playerFeature);

			BeginGame();
		}

		private void BeginGame()
		{
			_playerFeature.BeginPlayerMove();
			// float pos = _pathFeatureFeature.GetPoiNormalizedPos(progress);
			// _scrollFeatureFeature.MoveInstant(pos);

			//_pathFeatureFeature.MovePlayerToStartPosition(_playerFeature.PlayerTransform);
			//_pathFeatureFeature.BeginPlayerMove(_playerFeature.PlayerTransform);
		}


	}
}
