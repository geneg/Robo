using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.ThemesFeature;
using UnityEngine;


namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public abstract class BaseItem : MonoBehaviour
	{
		[SerializeField] private List<ThemeableElement> _themeableElements;
		public List<ThemeableElement> GetThemeableElements() => _themeableElements;
		
		protected IPowerUp _powerUp;
		
		public abstract void Interact();
		
		public void InjectPowerUp(IPowerUp powerUp)
		{
			_powerUp = powerUp;
		}
	}
}
