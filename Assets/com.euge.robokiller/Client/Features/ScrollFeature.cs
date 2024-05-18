using System;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Services;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features
{
	public class ScrollFeature : BaseService
	{
		public event Action OnDrag;
		private readonly ScrollRect _scrollRect;
		private float _viewportHeight;

		private int _playerPathIndex;
		private float _start;
		private float _delta;

		public ScrollFeature(ScrollRect scrollRect, ServiceResolver resolver) : base(resolver)
		{
			_scrollRect = scrollRect;
		}

		public override Task Initialize()
		{
			_viewportHeight = _scrollRect.viewport.rect.height;

			EventTrigger trigger = _scrollRect.gameObject.AddComponent<EventTrigger>();
			EventTrigger.Entry entry = new EventTrigger.Entry
			{
				eventID = EventTriggerType.BeginDrag
			};

			entry.callback.AddListener(data => { OnScrollBeginDrag((PointerEventData)data); });
			trigger.triggers.Add(entry);

			return Task.CompletedTask;
		}

		private void OnScrollBeginDrag(PointerEventData eventData)
		{
			OnDrag?.Invoke();
		}

		private void MoveInstant(float normalizedPosition)
		{
			_scrollRect.verticalNormalizedPosition = normalizedPosition;
		}

		public void BeginScroll(float start, float end)
		{
			_start = start;
			_delta = end - _start - _viewportHeight * 0.5f;
			MoveInstant(0);
		}

		public void MoveTo(float y)
		{
			float normalizedY = (y - _start) / _delta;
			_scrollRect.verticalNormalizedPosition = normalizedY;
		}
	}
}
