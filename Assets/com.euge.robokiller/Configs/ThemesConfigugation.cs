using UnityEngine;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "ThemesConfigugation", menuName = "Configs/ThemesConfigugation")]
	public class ThemesConfigugation : ScriptableObject
	{
		[System.Serializable]
		public class ThemeData
		{
			public string themeName;
			public string addressableKey;
		}

		public ThemeData[] Themes;
		public int CurrentThemeIndex;
	}
}
