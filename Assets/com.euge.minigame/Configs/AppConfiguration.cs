using UnityEngine;

namespace com.euge.minigame.Configs
{
	[CreateAssetMenu(fileName = "AppConfiguration", menuName = "Configs/AppConfiguration")]
	public class AppConfiguration : ScriptableObject
	{
		public int BuildVersion;
		public string LevelsConfigurationKey;
		public string ThemesConfigurationKey;
	}
}
