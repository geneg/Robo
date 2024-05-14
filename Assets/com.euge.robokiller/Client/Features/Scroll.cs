using com.euge.minigame.Services;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features
{
	public class Scroll : BaseService
	{
		private readonly ScrollRect _scrollRect;
		private float _viewportHeight;
		private float _contentHeight;
		private float _normalizedViewportHeight;

		public Scroll(ScrollRect scrollRect) : base()
		{
			_scrollRect = scrollRect;
		}

		public void Initialize()
		{
			_viewportHeight = _scrollRect.viewport.rect.height;
			_contentHeight = _scrollRect.content.rect.height;
			_normalizedViewportHeight = _viewportHeight / _contentHeight;
		}
		
		public void MoveInstant(float normalizedPosition)
		{
			float adjustedPosition = normalizedPosition + _normalizedViewportHeight / (-2f);
			_scrollRect.verticalNormalizedPosition = adjustedPosition;
		}	
		
	}
}
