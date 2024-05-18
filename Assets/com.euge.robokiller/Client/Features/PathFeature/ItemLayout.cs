using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.PathFeature
{
	[RequireComponent(typeof(Image), typeof(RectTransform))]
	public class ItemLayout : MonoBehaviour
	{
		public ItemType Type => _type;
		public Vector2 Position => transform.position;
		
		[SerializeField] private ItemType _type;
		[SerializeField] private RectTransform _rectTransform;
		
		private Image _image;
		
		private void Awake()
		{
			_image = GetComponent<Image>();
			_image.enabled = false;
			
			_rectTransform = GetComponent<RectTransform>();
		}
		
		#if UNITY_EDITOR
		private void OnValidate()
		{
			_image = GetComponent<Image>();
			_image.color = _type switch
			{
				ItemType.enemy => Color.red,
				ItemType.chest => Color.yellow,
				ItemType.rank => Color.green,
				_ => _image.color
			};
		}
		#endif
	}
	
	
	
}
