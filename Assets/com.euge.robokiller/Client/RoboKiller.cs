using System;
using System.Threading.Tasks;
using com.euge.minigame;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features;
using UnityEngine;


namespace com.euge.robokiller.Client
{
    public class RoboKiller : Minigame
    {
        private ThemesFeature _themesFeatureFeature;
        private LevelsFeature _levelsFeatureFeature;
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
            _levelsFeatureFeature = new LevelsFeature(appConfig, _visualBridge.GameContentParent);
            _playerFeature = new PlayerFeature(appConfig, _visualBridge.GameContentParent);
            _scrollFeatureFeature = new ScrollFeature(_visualBridge.ScrollRect);
            
            InitializeFeatures();
            
        }

        private async void InitializeFeatures()
        {
            await _themesFeatureFeature.Initialize();
            await _levelsFeatureFeature.Initialize();
            await _playerFeature.Initialize();
            
            _scrollFeatureFeature.Initialize();
            
            _themesFeatureFeature.ApplyTheme(_levelsFeatureFeature);
            _themesFeatureFeature.ApplyTheme(_playerFeature);
            
            float pos = _levelsFeatureFeature.GetPoiNormalizedPos(progress);
            _scrollFeatureFeature.MoveInstant(pos);
        }
        
    }
}
