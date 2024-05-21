using System;
using System.Threading.Tasks;
using com.euge.minigame;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.robokiller.Client.Features;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.ItemsFeature;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.PathFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Client.Features.ThemesFeature;

namespace com.euge.robokiller.Client
{
	public class RoboKiller : Minigame
	{
		private readonly ServiceResolver _clientServiceResolver = new ServiceResolver();
		private readonly VisualBridge _visualBridge;
		private ThemesFeature _themesFeatureFeature;
		private PathFeature _pathFeatureFeature;
		private PlayerFeature _playerFeature;
		private ScrollFeature _scrollFeature;
		private MovementFeature _movementFeature;
		private ItemsFeature _itemsFeature;
		private InventoryFeature _inventoryFeature;

		public RoboKiller(VisualBridge visualBridge)
		{
			_visualBridge = visualBridge;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			AppConfiguration appConfig = _serviceResolver.GetService<Config>().AppConfig;

			#region "Client Features Creation"
			_themesFeatureFeature = new ThemesFeature(appConfig);
			_clientServiceResolver.RegisterService(_themesFeatureFeature);

			_pathFeatureFeature = new PathFeature(appConfig, _visualBridge.GameContentParent);
			_clientServiceResolver.RegisterService(_pathFeatureFeature);

			_playerFeature = new PlayerFeature(appConfig, _visualBridge.GameContentParent);
			_clientServiceResolver.RegisterService(_playerFeature);

			_scrollFeature = new ScrollFeature(_visualBridge.ScrollRect);
			_clientServiceResolver.RegisterService(_scrollFeature);

			_movementFeature = new MovementFeature();
			_clientServiceResolver.RegisterService(_movementFeature);

			_itemsFeature = new ItemsFeature(appConfig);
			_clientServiceResolver.RegisterService(_itemsFeature);
			
			_inventoryFeature = new InventoryFeature(appConfig, _visualBridge.InventoryPanel);
			_clientServiceResolver.RegisterService(_inventoryFeature);
			#endregion
			
			//inject collection to some features to transfer items between them
			new HelperCollection(_clientServiceResolver).InjectCollection();
			
			await _clientServiceResolver.InitializeServices();
			
			_themesFeatureFeature.ApplyTheme(_pathFeatureFeature);
			_themesFeatureFeature.ApplyTheme(_playerFeature);
			_themesFeatureFeature.ApplyTheme(_itemsFeature);

			BeginGame();
		}

		private void BeginGame()
		{
			_movementFeature.BeginMove();
			_movementFeature.Move();
		}
		
	}
}
