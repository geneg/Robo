using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Services;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features
{
	public class ScrollFeature : BaseService
	{
		private readonly ScrollRect _scrollRect;
		private float _viewportHeight;
		private float _contentHeight;
		private float _normalizedViewportHeight;

		public ScrollFeature(ScrollRect scrollRect, ServiceResolver resolver) : base(resolver)
		{
			_scrollRect = scrollRect;
		}

		public override Task Initialize()
		{
			_viewportHeight = _scrollRect.viewport.rect.height;
			_contentHeight = _scrollRect.content.rect.height;
			_normalizedViewportHeight = _viewportHeight / _contentHeight;
			
			return Task.CompletedTask;
		}
		
		public void MoveInstant(float normalizedPosition)
		{
			float adjustedPosition = normalizedPosition + _normalizedViewportHeight / (-2f);
			_scrollRect.verticalNormalizedPosition = adjustedPosition;
		}
		
	}
}
