
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.minigame.Utils
{
	public class RaycastGameObject : MonoBehaviour
	{
		[SerializeField] private Graphic _graphics;
		
		public bool RaycastTarget
		{
			get => _graphics.raycastTarget;
			set => _graphics.raycastTarget = value;
		}
	}
}
