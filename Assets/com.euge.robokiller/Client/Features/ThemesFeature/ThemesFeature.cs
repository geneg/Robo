using System;
using System.Reflection;
using System.Threading.Tasks;
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
		
		public ThemesFeature(string configKey)
		{
			_themesConfigurationKey = configKey;
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
					HandleFieldInfo(fieldInfo, themeableElement);
				}
				else
				{
					HandlePointOfInterest(themeableElement);
				}
			}
		}

		private void HandleFieldInfo(FieldInfo fieldInfo, ThemeableElement themeableElement)
		{
			if (fieldInfo.FieldType == typeof(Sprite))
			{
				ApplySprite(fieldInfo, themeableElement);
			}
			else if (fieldInfo.FieldType == typeof(Sprite[]))
			{
				ApplySprites(fieldInfo, themeableElement, _theme);
			}
		}

		private void HandlePointOfInterest(ThemeableElement themeableElement)
		{
			foreach (PointOfInterest pointOfInterest in _theme.poi)
			{
				if (pointOfInterest.type.ToString() == themeableElement.ThemeProperty)
				{
					FieldInfo fieldInfo = pointOfInterest.GetType().GetField("sprites");

					if (fieldInfo.FieldType == typeof(Sprite[]))
					{
						ApplySprites(fieldInfo, themeableElement, pointOfInterest);
					}
					break;
				}
			}
		}

		private void ApplySprite(FieldInfo fieldInfo, ThemeableElement themeableElement)
		{
			Sprite sprite = fieldInfo.GetValue(_theme) as Sprite;
			foreach (Image image in themeableElement.ThemeableImage)
			{
				image.sprite = sprite;
			}
		}

		private void ApplySprites(FieldInfo fieldInfo, ThemeableElement themeableElement, object themeElement)
		{
			Sprite[] sprites = fieldInfo.GetValue(themeElement) as Sprite[];

			for (int i = 0; i < themeableElement.ThemeableImage.Length; i++)
			{
				if (sprites != null && sprites.Length > i)
				{
					themeableElement.ThemeableImage[i].sprite = sprites[i];
				}
			}
		}
	}
}
