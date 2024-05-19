using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class DamagePowerUp : IPowerUp
	{
		private float _attackFrequency;
		private Inventory _inventory;
		private Sequence _damageSequence;

		public DamagePowerUp(PowerUpData data) {
			_attackFrequency = data.EffectFrequency;
			PowerUpSprite = data.powerUpSprite;
			_inventory = data.Inventory;
		}

		public void Apply()
		{
			_damageSequence = DOTween.Sequence()
				.AppendInterval(_attackFrequency)
				.AppendCallback(() => _inventory.RemoveHealth(1)).SetLoops(-1);
		}
		
		public void StopEffect()
		{
			if (_damageSequence != null)
			{
				_damageSequence.Kill();
				_damageSequence = null;
			}
		}
		
		public Sprite PowerUpSprite { get; }


	}
}
