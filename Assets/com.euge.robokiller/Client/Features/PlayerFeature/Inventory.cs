using UnityEngine;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public class Inventory
	{
		private int _health;
		
		
		public void RemoveHealth(int amount)
		{
			Debug.Log("Health removed!");
			_health -= amount;
		}
	}
}
