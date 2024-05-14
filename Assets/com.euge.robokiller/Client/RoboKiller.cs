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
        private Themes _themesFeature;
        private Levels _levelsFeature;
        private Scroll _scrollFeature;
        
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
            
            _themesFeature = new Themes(appConfig);
            _levelsFeature = new Levels(appConfig, _visualBridge.LevelParent);
            _scrollFeature = new Scroll(_visualBridge.ScrollRect);
            
            InitializeFeatures();
            
        }

        private async void InitializeFeatures()
        {
            await _themesFeature.Initialize();
            await _levelsFeature.Initialize();
            _scrollFeature.Initialize();
            
            _themesFeature.ApplyTheme(_levelsFeature);
            
            float pos = _levelsFeature.GetPoiNormalizedPos(progress);
            _scrollFeature.MoveInstant(pos);
        }
        
    }
}
