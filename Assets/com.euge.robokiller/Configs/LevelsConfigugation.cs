using UnityEngine;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Configs/LevelsConfiguration")]
	public class LevelsConfigugation : ScriptableObject
	{
		[System.Serializable]
		public class LevelData
		{
			public string levelName;
			public string addressableKey;
		}

		public LevelData[] Levels;
	}
}
