using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.euge.robokiller.Client.Features
{
	public class LevelsFeature : BaseService, IThemeable
	{
		private readonly string _levelsConfigurationKey;
		private int _currentLevelIndex;
		private readonly Transform _parent;
		private GameLevel _level;
		private float _start;
		private float _end;
		private int _pathIndex;

		public LevelsFeature(AppConfiguration appConfig, Transform parent) : base()
		{
			_levelsConfigurationKey = appConfig.LevelsConfigurationKey;
			_parent = parent;
		}

		public async Task Initialize()
		{
			LevelsConfigugation levelsConfig = await Loaders.LoadAsset<LevelsConfigugation>(_levelsConfigurationKey);
			_level = await Loaders.Instantiate<GameLevel>(levelsConfig.Levels[_currentLevelIndex].addressableKey, _parent);

			if (_level.PointsOfInterest == null || _level.PointsOfInterest.Length == 0)
			{
				throw new System.Exception("PointsOfInterest is null or empty");
			}
			
			_start = _level.PointsOfInterest[0].transform.position.y;
			_end = _level.PointsOfInterest[^1].transform.position.y;
		}
		
		public float GetPoiNormalizedPos(int progress)
		{
			float yPos = _level.PointsOfInterest[progress].transform.position.y;
			return (yPos - _start) / (_end - _start);
		}

		public List<ThemeableElement> GetThemeableElements()
		{
			// another elements can be added to list here if needed
			return _level.GetThemeableElements();	
		}
		
		public Vector2 CurrentPathPosition()
		{
			return _level.MovementPath.GetPosition(_pathIndex);
		}
	}
}
