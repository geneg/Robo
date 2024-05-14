using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client
{
	public class VisualBridge : MonoBehaviour
	{
		public Transform LevelParent => _levelParent;
		public ScrollRect ScrollRect => _scrollRect;
		
		[Header("Game Level Container")]
		[SerializeField] private Transform _levelParent;

		[SerializeField] private ScrollRect _scrollRect;
	}
}
