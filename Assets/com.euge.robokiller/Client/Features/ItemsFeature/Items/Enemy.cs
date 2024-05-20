using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Enemy : BaseItem, IPointerClickHandler
	{
		[SerializeField] private GameObject _idle;
		[SerializeField] private GameObject _attack;
		[SerializeField] private HpBar _hpBar;
		[SerializeField] private Image _additionalGraphicsImage;
		private bool _isAttacking;
		private EnemyData _additionalData;
		private int _hitPoints;
		private Tween _currentTween;

		private void Awake()
		{
			IdleState();
			_hpBar.gameObject.SetActive(false);
		}
		
		public override void Interact()
		{
			//deal random hit points
			_hitPoints = UnityEngine.Random.Range(_additionalData.HitPointsFrom, _additionalData.HitPointsTo + 1);
			_hpBar.gameObject.SetActive(true);
			_hpBar.SetTotal(_hitPoints);
			_hpBar.SetValue(_hitPoints);
			_isAttacking = true;
			_additionalGraphicsImage.sprite = _powerUp.PowerUpSprite;
			_powerUp.OnAnimate += AttackAnimation;
			_powerUp.Apply();
		}
		
		private void AttackAnimation()
		{
			AttackState();
			AdditionalGraphicsAnimation();
			_currentTween = DOVirtual.DelayedCall(0.2f, IdleState);
		}
		
		private void AdditionalGraphicsAnimation()
		{
			_additionalGraphicsImage.gameObject.SetActive(true);
			_additionalGraphicsImage.transform.localScale = Vector3.zero;
			_additionalGraphicsImage.transform.DOPunchScale(Vector3.one, 0.5f, 5, 0.1f)
				.OnComplete(() => _additionalGraphicsImage.gameObject.SetActive(false));
		}
		
		private void IdleState()
		{
			_additionalGraphicsImage.gameObject.SetActive(false);
			_idle.SetActive(true);
			_attack.SetActive(false);
		}

		private void AttackState()
		{
			_idle.SetActive(false);
			_attack.SetActive(true);
		}
		
		public void OnPointerClick(PointerEventData eventData)
		{
			if (_isAttacking)
			{
				InvokeOnClickItem();
			}
		}

		public override void Hit(int rank)
		{
			_hitPoints -= rank;
			_hpBar.SetValue(_hitPoints);
			AdditionalGraphicsAnimation();
			if (_hitPoints > 0) return;
			
			_powerUp.StopEffect();
			_powerUp.OnAnimate -= AttackAnimation;
			_currentTween.Kill();
			
			_hpBar.gameObject.SetActive(false);
			gameObject.SetActive(false);
			InvokeOnItemExhaust();
		}
		
		public void SetAdditionalData(string json)
		{
			_additionalData = JsonUtility.FromJson<EnemyData>(json);
		}
	}
	
	[Serializable]
	internal class EnemyData
	{
		public int HitPointsFrom;
		public int HitPointsTo;
	}
}
