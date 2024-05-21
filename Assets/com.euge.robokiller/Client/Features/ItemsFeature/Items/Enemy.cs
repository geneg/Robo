using System;
using System.Collections;
using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
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
		private List<PowerUpEffect> _collection;

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
			
			if (_powerUp is IAnimatablePowerUp animatablePowerUp)
			{
				animatablePowerUp.OnAnimate += AttackAnimation;
			}
			
			_powerUp.Apply();
			
			//add bomb animation
			DOVirtual.DelayedCall(0.5f, FindBomb);
			
		}
		
		private void FindBomb()
		{
			foreach (PowerUpEffect powerUpEffect in _collection)
			{
				if (powerUpEffect.BlowUp <= 0) continue;
				powerUpEffect.MarkAsUsed();
				Hit(powerUpEffect.BlowUp); //using standard Hit-ItemExhaust mechanism
				break;
			}
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
			
			Kill();
		}
		
		private void Kill()
		{
			_powerUp.StopEffect();
			
			if (_powerUp is IAnimatablePowerUp animatablePowerUp)
			{
				animatablePowerUp.OnAnimate -= AttackAnimation;
			}
			
			_currentTween.Kill();
			
			_hpBar.gameObject.SetActive(false);
			gameObject.SetActive(false);
			InvokeOnItemExhaust();
		}

		public void SetAdditionalData(string json)
		{
			_additionalData = JsonUtility.FromJson<EnemyData>(json);
		}
		
		public void SetCollection(List<PowerUpEffect> collection)
		{
			_collection = collection;
		}
	}
	
	[Serializable]
	internal class EnemyData
	{
		public int HitPointsFrom;
		public int HitPointsTo;
	}
}
