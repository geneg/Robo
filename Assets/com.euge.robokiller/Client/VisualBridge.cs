using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.euge.robokiller.Client
{
	public class VisualBridge : MonoBehaviour
	{
		public Transform GameContentParent => _gameContentParent;
		public ScrollRect ScrollRect => _scrollRect;
		
		[FormerlySerializedAs("_levelParent")]
		[Header("Game Content Container")]
		[SerializeField] private Transform _gameContentParent;
		
		[SerializeField] private ScrollRect _scrollRect;
	}
}
