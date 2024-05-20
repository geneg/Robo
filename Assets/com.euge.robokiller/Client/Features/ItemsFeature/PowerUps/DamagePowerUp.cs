using System.Collections.Generic;
using com.euge.minigame.Common;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using DG.Tweening;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.PowerUps
{
	public class DamagePowerUp : BasePowerUp, IPowerUp, IAnimatablePowerUp
	{
		private readonly float _attackFrequency;
		private Sequence _damageSequence;
		private readonly float _attackStrength;
		public event PowerUpUpdateHandler OnAnimate;

		public DamagePowerUp(PowerUpData data, IPlayerFeature playerFeature) : base(data, playerFeature)
		{
			_attackFrequency = data.EffectFrequency;
			_attackStrength = data.EffectValue;
		}

		public void Apply()
		{
			_effect = new PowerUpEffect
			{
				HealthDelta = (int) _attackStrength * -1,
			};

			_effect.OnStopEffect += StopEffect;

			_damageSequence = DOTween.Sequence()
				.AppendInterval(_attackFrequency)
				.AppendCallback(() => {
					OnAnimate?.Invoke();
					_playerFeature.ApplyPowerUp(_effect);
				})
				.SetLoops(loops: -1);
		}

		public void StopEffect()
		{
			_effect.OnStopEffect -= StopEffect;
			if (_damageSequence != null)
			{
				_damageSequence.Kill();
				_damageSequence = null;
			}
		}
	}
}
