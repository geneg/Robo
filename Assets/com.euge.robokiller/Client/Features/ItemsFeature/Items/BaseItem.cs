using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ThemesFeature;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public abstract class BaseItem : MonoBehaviour
	{
		[SerializeField] private List<ThemeableElement> _themeableElements;
		public List<ThemeableElement> GetThemeableElements() => _themeableElements;

		public Vector2 Position { get; set; }
		public abstract void Interact();
	}
}
