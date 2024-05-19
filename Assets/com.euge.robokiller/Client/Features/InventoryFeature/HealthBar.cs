using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField] private HealthPoint _prefab;

		private List<HealthPoint> _healthPoints = new List<HealthPoint>();
		
		public void Init(int maxHealth, int initialHealth)
		{
			_prefab.gameObject.SetActive(false);
			
			for (int i = 0; i < maxHealth; i++)
			{
				HealthPoint point = Instantiate(_prefab, transform).GetComponent<HealthPoint>();
				
				if(i < initialHealth)
					point.On();
				else
					point.Off();
				
				point.gameObject.SetActive(true);
				_healthPoints.Add(point);
			}
		}
		
		public void SetHealth(int health)
		{
			for (int i = 0; i < _healthPoints.Count; i++)
			{
				if(i < health)
					_healthPoints[i].On();
				else
					_healthPoints[i].Off();
			}
		}
	}
	
	
}

