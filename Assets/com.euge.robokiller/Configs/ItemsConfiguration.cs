using UnityEngine;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "ItemsConfigugation", menuName = "Configs/ItemsConfigugation")]
	public class ItemsConfiguration : ScriptableObject
	{
		public string ChestKey;
		public string EnemyKey;
		public string RankKey;
	}
}
