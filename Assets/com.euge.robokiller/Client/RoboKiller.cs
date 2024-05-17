using System;
using System.Threading.Tasks;
using com.euge.minigame;
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
        private ThemesFeature _themesFeatureFeature;
        private PathFeature _pathFeatureFeature;
        private ScrollFeature _scrollFeatureFeature;
        private PlayerFeature _playerFeature;

        private readonly VisualBridge _visualBridge;
        
        
        //todo: remove this
        private int progress = 0;
        
        public RoboKiller(VisualBridge visualBridge)
        {
            _visualBridge = visualBridge;
        }

        public override async Task Initialize() 
        {
            await base.Initialize();
            
            
            AppConfiguration appConfig = _serviceResolver.GetService<Config>().AppConfig;
            
            _themesFeatureFeature = new ThemesFeature(appConfig);
            _pathFeatureFeature = new PathFeature(appConfig, _visualBridge.GameContentParent);
            _playerFeature = new PlayerFeature(appConfig, _visualBridge.GameContentParent);
            _scrollFeatureFeature = new ScrollFeature(_visualBridge.ScrollRect);
            
            InitializeFeatures();
            
        }

        private async void InitializeFeatures()
        {
            await _themesFeatureFeature.Initialize();
            await _pathFeatureFeature.Initialize();
            await _playerFeature.Initialize();
            
            _scrollFeatureFeature.Initialize();
            
            _themesFeatureFeature.ApplyTheme(_pathFeatureFeature);
            _themesFeatureFeature.ApplyTheme(_playerFeature);
            
            float pos = _pathFeatureFeature.GetPoiNormalizedPos(progress);
            _scrollFeatureFeature.MoveInstant(pos);
            
            _pathFeatureFeature.MovePlayerToStartPosition(_playerFeature.PlayerTransform);
            _pathFeatureFeature.BeginPlayerMove(_playerFeature.PlayerTransform);
        }

        
        
    }
}
