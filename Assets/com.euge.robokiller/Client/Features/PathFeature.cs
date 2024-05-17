using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using DG.Tweening;
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
		private int _pathIndex;
		public bool IsLastSection => _pathIndex >= _gameLevel.MovementPath.positionCount - 1;
		
		public PathFeature(AppConfiguration appConfig, Transform parent) : base()
		{
			_levelsConfigurationKey = appConfig.LevelsConfigurationKey;
			_parent = parent;
			
		}

		public async Task Initialize()
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
		
		public float GetPoiNormalizedPos(int progress)
		{
			float yPos = _gameLevel.PointsOfInterest[progress].transform.position.y;
			return (yPos - _start) / (_end - _start);
		}

		public List<ThemeableElement> GetThemeableElements()
		{
			return _gameLevel.GetThemeableElements();	
		}
		
		public Vector2 GetNextPathPoint()
		{
			if (!IsLastSection)
			{
				return _gameLevel.MovementPath.GetPosition(_pathIndex++);
			}

			_pathIndex = 0;
			return _gameLevel.MovementPath.GetPosition(_gameLevel.MovementPath.positionCount - 1);
		}
		
		public void MovePlayerToStartPosition(RectTransform playerTransform)
		{
			_pathIndex = 0;
			playerTransform.anchoredPosition = _gameLevel.MovementPath.GetPosition(_pathIndex++);
		}
		
		public void BeginPlayerMove(RectTransform player)
		{
			Vector2 currentPoint= _gameLevel.MovementPath.GetPosition(_pathIndex - 1);
			Vector2 nextPoint = GetNextPathPoint();
			
			float distance = Vector2.Distance(currentPoint, nextPoint);
			float speed = 200f; // Define your speed here
			
			float duration = distance / speed;
			
			player.DOAnchorPos(nextPoint, duration, true)
				.SetEase(IsLastSection ? Ease.OutCubic : Ease.Linear)
				.OnComplete(() =>
				{
					if (!IsLastSection)
					{
						BeginPlayerMove(player);
					}
				});

		}
	}
}
