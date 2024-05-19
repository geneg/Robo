using System;
using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.ThemesFeature;
using UnityEngine;


namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public abstract class BaseItem : MonoBehaviour
	{
		public delegate void ClickHandler(BaseItem item);
		public event ClickHandler OnClickItem;
		public event Action OnItemExhaust;
		
		[SerializeField] private List<ThemeableElement> _themeableElements;
		public List<ThemeableElement> GetThemeableElements() => _themeableElements;
		
		protected IPowerUp _powerUp;
		
		public abstract void Interact();
		
		public void InjectPowerUp(IPowerUp powerUp)
		{
			_powerUp = powerUp;
		}
		
		protected void InvokeOnClickItem()
		{
			OnClickItem?.Invoke(this);
		}

		protected void InvokeOnItemExhaust()
		{
			OnItemExhaust?.Invoke();
		}
		
		public virtual void Hit(int rank)
		{
		}
	}
}
