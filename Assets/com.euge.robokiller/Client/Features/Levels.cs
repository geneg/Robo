using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.euge.robokiller.Client.Features
{
	public class Levels : BaseService
	{
		private readonly string _levelsConfigurationKey;
		private int _currentLevelIndex;
		private readonly Transform _parent;

		public Levels(AppConfiguration appConfig, Transform parent) : base()
		{
			_levelsConfigurationKey = appConfig.LevelsConfigurationKey;
			_parent = parent;
		}

		public async Task Initialize()
		{
			LevelsConfigugation levelsConfig = await Loaders.LoadAsset<LevelsConfigugation>(_levelsConfigurationKey);
			GameLevel level = await Loaders.Instantiate<GameLevel>(levelsConfig.Levels[_currentLevelIndex].addressableKey, _parent);
			
			Debug.Log($"Level loaded: {level}");
			
		}
	}
}
