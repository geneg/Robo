using System.Collections.Generic;
using UnityEngine;

namespace com.euge.robokiller.Client.Features
{
	public class Player : MonoBehaviour,IThemeable
	{
		[SerializeField] private List<ThemeableElement> _themeableElements;

		public List<ThemeableElement> GetThemeableElements() => _themeableElements;
	}
}
