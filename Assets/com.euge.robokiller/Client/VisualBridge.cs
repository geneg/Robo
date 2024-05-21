using com.euge.robokiller.Client.Features.InventoryFeature;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.euge.robokiller.Client
{
	public class VisualBridge : MonoBehaviour
	{
		public Transform GameContentParent => _gameContentParent;
		public ScrollRect ScrollRect => _scrollRect;
		public InventoryPanel InventoryPanel => _inventoryPanel;
		public Transform PopupParent => _popupParent;
		
		[FormerlySerializedAs("_levelParent")]
		[Header("Game Content Container")]
		[SerializeField] private Transform _gameContentParent;
		[SerializeField] private Transform _popupParent;
		
		[SerializeField] private ScrollRect _scrollRect;
		[SerializeField] private InventoryPanel _inventoryPanel;
	}
}
