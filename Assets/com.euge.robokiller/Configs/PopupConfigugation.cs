using UnityEngine;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "PopupConfigugation", menuName = "Configs/PopupConfigugation")]
	public class PopupConfigugation : ScriptableObject
	{
		public string AddressableKey;
		public string winner_text;
		public string loser_text;
	}
}
