using System.Collections.Generic;

namespace com.euge.robokiller.Client.Features.ThemesFeature
{
	public interface IThemeable
	{

		List<ThemeableElement> GetThemeableElements();
	}
}
