using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;


namespace com.euge.robokiller.Client.Features
{
	public class PathFeature : BaseService, IThemeable
	{
		private readonly string _levelsConfigurationKey;
		private int _currentLevelIndex;
		private readonly Transform _parent;
		private GameLevel _gameLevel;
		private float _start;
		private float _end;
		
		public PathFeature(AppConfiguration appConfig, Transform parent, ServiceResolver resolver) : base(resolver)
		{
			_levelsConfigurationKey = appConfig.LevelsConfigurationKey;
			_parent = parent;
		}

		public override async Task Initialize()
		{
			LevelsConfigugation levelsConfig = await Loaders.LoadAsset<LevelsConfigugation>(_levelsConfigurationKey);
			_gameLevel = await Loaders.Instantiate<GameLevel>(levelsConfig.Levels[_currentLevelIndex].addressableKey, _parent);

			if (_gameLevel.PointsOfInterest == null || _gameLevel.PointsOfInterest.Length == 0)
			{
				throw new System.Exception("PointsOfInterest is null or empty");
			}
			
			_start = _gameLevel.PointsOfInterest[0].transform.position.y;
			_end = _gameLevel.PointsOfInterest[^1].transform.position.y;
		}
		
		public bool IsLastSection(int pathIndex)
		{
			return pathIndex >= _gameLevel.MovementPath.positionCount - 1;
		}

		public float GetPoiNormalizedPos(int progress)
		{
			float yPos = _gameLevel.PointsOfInterest[progress].transform.position.y;
			return (yPos - _start) / (_end - _start);
		}

		public Vector2 StartPoint()
		{
			return GetPathPoint(0);
		}
		
		public Vector2 EndPoint()
		{
			return GetPathPoint(_gameLevel.MovementPath.positionCount - 1);
		}

		public List<ThemeableElement> GetThemeableElements()
		{
			return _gameLevel.GetThemeableElements();	
		}
		
		//encapsulate the path logic
		public Vector2 GetPathPoint(int index)
		{
			return _gameLevel.MovementPath.GetPosition(index);
		}
	}
}
