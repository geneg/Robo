using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features
{
	[Serializable]
	public class ThemeableElement
	{
		public string ThemeProperty;
		public Image ThemeableImage;
	}
	
	public class Themes : BaseService
	{
		private readonly string _themesConfigurationKey;
		
		public ThemeTemplate Theme => _theme;
		private ThemeTemplate _theme;
		
		public Themes(AppConfiguration appConfig) : base()
		{
			_themesConfigurationKey = appConfig.ThemesConfigurationKey;
		}

		public async Task Initialize()
		{
			ThemesConfigugation themesConfig = await Loaders.LoadAsset<ThemesConfigugation>(_themesConfigurationKey);
			_theme = await Loaders.LoadAsset<ThemeTemplate>(themesConfig.Themes[themesConfig.CurrentThemeIndex].addressableKey);
		}
		
		public void ApplyTheme(IThemeable themeable)
		{
			foreach (ThemeableElement themeableElement in themeable.GetThemeableElements())
			{
				FieldInfo fieldInfo = _theme.GetType().GetField(themeableElement.ThemeProperty);

				if (fieldInfo == null || fieldInfo.FieldType != typeof(Sprite)) continue;

				Sprite sprite = fieldInfo.GetValue(_theme) as Sprite;
				themeableElement.ThemeableImage.sprite = sprite;
			}
		}
		
	}
}
