using System;
using System.Threading.Tasks;
using com.euge.minigame;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features;


namespace com.euge.robokiller.Client
{
    public class RoboKiller : Minigame
    {
        private Levels _levelsFeature;
        private readonly VisualBridge _visualBridge;
        
        public RoboKiller(VisualBridge visualBridge)
        {
            _visualBridge = visualBridge;
        }

        public override async Task Initialize() 
        {
            await base.Initialize();
            
            
            AppConfiguration appConfig = _serviceResolver.GetService<Config>().AppConfig;
            
            _levelsFeature = new Levels(appConfig, _visualBridge.LevelParent);
            
            InitializeFeatures();
            
        }

        private async void InitializeFeatures()
        {
            await _levelsFeature.Initialize();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            //levels
            //configuration loader
        //load level
        //init level
        //init player
        //state machine
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
