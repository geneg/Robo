using UnityEngine;

namespace com.euge.robokiller.Client
{
	public class VisualBridge : MonoBehaviour
	{
		public Transform LevelParent => _levelParent;
		
		[Header("Game Level Container")]
		[SerializeField] private Transform _levelParent;
	}
}
