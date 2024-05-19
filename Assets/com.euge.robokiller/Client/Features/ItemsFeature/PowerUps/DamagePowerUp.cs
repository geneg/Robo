using com.euge.minigame.Common;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class DamagePowerUp : IPowerUp
	{
		private float _attackFrequency;
		private IInventory _inventory;
		private Sequence _damageSequence;
		private readonly float _attackStrength;

		public DamagePowerUp(PowerUpData data, IInventory inventory)
		{
			_inventory = inventory;
			_attackFrequency = data.EffectFrequency;
			_attackStrength = data.EffectValue;
			PowerUpSprite = data.powerUpSprite;
		}

		public void Apply()
		{
			PowerUpEffect effect = new PowerUpEffect
			{
				HealthDelta = (int) _attackStrength * -1
			};

			_damageSequence = DOTween.Sequence()
				.AppendInterval(_attackFrequency)
				.AppendCallback(() => _inventory.UpdateInventory(effect))
				.SetLoops(loops:-1);
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
