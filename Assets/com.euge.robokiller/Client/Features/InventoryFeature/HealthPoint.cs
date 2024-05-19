using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public class HealthPoint : MonoBehaviour
	{
		[SerializeField] private Image _healthPoint;
		
		public void Off()
		{
			_healthPoint.gameObject.SetActive(false);
		}
		
		public void On()
		{
			_healthPoint.gameObject.SetActive(true);
		}
	}
}
