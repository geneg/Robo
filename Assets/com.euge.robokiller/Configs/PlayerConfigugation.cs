using UnityEngine;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "PlayerConfigugation", menuName = "Configs/PlayerConfigugation")]
	public class PlayerConfigugation : ScriptableObject
	{
		public string AddressableKey;
		public int InitialRank;
		public int InitialHealth;
		public int totalHealth;
	}
}
