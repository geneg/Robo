using System;
using System.Collections.Generic;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.ThemesFeature;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public class Player : MonoBehaviour,IThemeable, IPointerClickHandler
	{
		[SerializeField] private RaycastGameObject _regularPose;
		[SerializeField] private RaycastGameObject _attackPose;
		
		[SerializeField] private List<ThemeableElement> _themeableElements;
		[SerializeField] RectTransform _playerTransform;
		private Tween _currentTween;
		private bool _isPlayerWalking = true;

		public RectTransform PlayerTransform => _playerTransform;
		public Action OnClicked { get; set; }

		public List<ThemeableElement> GetThemeableElements() => _themeableElements;
		public event Action<BaseItem> OnItemInteracted;
		
		public void Relax()
		{
			_regularPose.gameObject.SetActive(true);
			_attackPose.gameObject.SetActive(false);
		}
		
		public void Attack()
		{
			SetAttackPose();
			_currentTween = DOVirtual.DelayedCall(0.2f, Relax);
		}
		
		private void SetAttackPose()
		{
			_regularPose.gameObject.SetActive(false);
			_attackPose.gameObject.SetActive(true);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			_isPlayerWalking = true;
			_regularPose.RaycastTarget = true;
			_attackPose.RaycastTarget = true;
			
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			BaseItem item = other.GetComponent<BaseItem>();
			if (item == null) return;

			//switch off the raycast target to prevent clicking on the player while interacting with an item
			_regularPose.RaycastTarget = false;
			_attackPose.RaycastTarget = false;
			
			_isPlayerWalking = false;
			OnItemInteracted?.Invoke(item);
		}
		
		//resume scrolling and movement of the player only if the player is not busy with an interaction
		public void OnPointerClick(PointerEventData eventData)
		{
			if (!_isPlayerWalking) return;
			OnClicked?.Invoke();
		}
	}
}
