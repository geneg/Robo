using System;
using System.Reflection;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.ThemesFeature
{
	[Serializable]
	public class ThemeableElement
	{
		public string ThemeProperty;
		public Image[] ThemeableImage;
	}
	
	public class ThemesFeature : BaseService
	{
		private readonly string _themesConfigurationKey;
		
		public ThemeTemplate Theme => _theme;
		private ThemeTemplate _theme;
		
		public ThemesFeature(AppConfiguration appConfig, ServiceResolver resolver) : base(resolver)
		{
			_themesConfigurationKey = appConfig.ThemesConfigurationKey;
		}

		public override async Task Initialize()
		{
			ThemesConfigugation themesConfig = await Loaders.LoadAsset<ThemesConfigugation>(_themesConfigurationKey);
			_theme = await Loaders.LoadAsset<ThemeTemplate>(themesConfig.Themes[themesConfig.CurrentThemeIndex].addressableKey);
		}
		
		public void ApplyTheme(IThemeable themeable)
		{
			foreach (ThemeableElement themeableElement in themeable.GetThemeableElements())
			{
				FieldInfo fieldInfo = _theme.GetType().GetField(themeableElement.ThemeProperty);

				if (fieldInfo != null)
				{
					if(fieldInfo.FieldType == typeof(Sprite))
					{
						Sprite sprite = fieldInfo.GetValue(_theme) as Sprite;
						foreach (Image image in themeableElement.ThemeableImage)
						{
							image.sprite = sprite;
						}
					}
					
					if(fieldInfo.FieldType == typeof(Sprite[]))
					{
						Sprite[] sprites = fieldInfo.GetValue(_theme) as Sprite[];
						
						for(int i = 0; i < themeableElement.ThemeableImage.Length; i++)
						{
							if (sprites != null && sprites.Length > i)
							{
								themeableElement.ThemeableImage[i].sprite = sprites[i];
							}
						}
					}
				}

			}
		}
		
	}
}
