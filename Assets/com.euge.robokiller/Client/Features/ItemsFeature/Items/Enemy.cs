using System;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Enemy : BaseItem
	{
		[SerializeField] private GameObject _idle;
		[SerializeField] private GameObject _attack;

		public Enemy()
		{
		
		}

		private void Awake()
		{
			IdleState();
		}
		
		public override void Interact()
		{
			// Apply damage every 1.5 seconds
		}
		
		private void IdleState()
		{
			_idle.SetActive(true);
			_attack.SetActive(false);
		}

		private void AttackState()
		{
			_idle.SetActive(false);
			_attack.SetActive(true);
		}
	}
}
