
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Services;
using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features
{
	public class MovementFeature : BaseService
	{
		private int _pathIndex;
		private PlayerFeature.PlayerFeature _player;
		private PathFeature.PathFeature _path;
		private ScrollFeature _scroll;
		private GameObject _movementGameObject;
		private bool _isPaused;
		private PopupFeature.PopupFeature _popupFeature;

		public override Task Initialize()
		{
			_path = GetServiceResolver.GetService<PathFeature.PathFeature>();
			_player = GetServiceResolver.GetService<PlayerFeature.PlayerFeature>();
			_scroll = GetServiceResolver.GetService<ScrollFeature>();
			_popupFeature = GetServiceResolver.GetService<PopupFeature.PopupFeature>();
			
			_movementGameObject = new GameObject("MovementGameObject");
			
			_scroll.OnDrag += OnBeginDrag;
			
			return Task.CompletedTask;
		}
		
		private void OnBeginDrag()
		{
			PauseMove();
		}

		public void BeginMove()
		{
			Vector2 startPoint = _path.GetPathPoint(_pathIndex++);
			_movementGameObject.transform.position = startPoint;
			
			_player.BeginPlayerMove(startPoint);
			_scroll.BeginScroll(_path.StartPoint().y, _path.EndPoint().y);
		}
		
		public void Move()
		{
			Vector2 currentPoint = _path.GetPathPoint(_pathIndex - 1);
			Vector2 nextPoint = _path.GetPathPoint(_pathIndex);
			
			float distance = Vector2.Distance(currentPoint, nextPoint);
			float speed = _player.GetSpeed();
			float duration = distance / speed;
			
			_movementGameObject.transform.DOMove(nextPoint, duration)
				.SetEase(_path.IsLastSection(_pathIndex) ? Ease.OutCubic : Ease.Linear)
				.OnUpdate(() => {
					Vector2 position = _movementGameObject.transform.position;
					_player.MoveTo(position);
					_scroll.MoveTo(position.y);
				})
				.OnComplete(() => {
					if (_path.IsLastSection(_pathIndex))
					{
						GameDone();
						return;
					}
					
					_pathIndex++;
					Move();
				});
		}

		private void GameDone()
		{
			_popupFeature.ShowPopup(true, () => {
				//todo: restart game logic
				//load another level
			});
		}
		
		public void PauseMove()
		{
			if (_isPaused) return;
			
			_isPaused = true;
			_movementGameObject.transform.DOPause();
		}
		
		public void ResumeMove()
		{
			if (!_isPaused) return;
			
			_isPaused = false;
			_movementGameObject.transform.DOPlay();
		}
	}
}
