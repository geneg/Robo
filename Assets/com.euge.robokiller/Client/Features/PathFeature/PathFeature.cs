using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ThemesFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.PathFeature
{
	public class PathFeature : BaseService, IThemeable
	{
		private readonly string _levelsConfigurationKey;
		private int _currentLevelIndex;
		private readonly Transform _parent;
		private GameLevel _gameLevel;
		
		public PathFeature(AppConfiguration appConfig, Transform parent)
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
		}
		
		public bool IsLastSection(int pathIndex)
		{
			return pathIndex >= _gameLevel.MovementPath.positionCount - 1;
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
		
		public ItemLayout[] GetPathItemsLayout()
		{
			return _gameLevel.PointsOfInterest;
		}
		
		public Transform GetItemsParent()
		{
			return _gameLevel.ItemsParent;
		}
	}
}
