using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client
{
	[RequireComponent(typeof(Image))]
	public class POI : MonoBehaviour
	{
		[SerializeField] private PoiType _type;
		
		private Image _image;
		
		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		private void Start()
		{
			_image.enabled = false;
		}
		
		#if UNITY_EDITOR
		private void OnValidate()
		{
			if (!_image)
			{
				_image = GetComponent<Image>();
			}

			switch (_type)
			{
				case PoiType.Enemy:
					_image.color = Color.red;
					break;
				case PoiType.Chest:
					_image.color = Color.yellow;
					break;
				case PoiType.Rank:
					_image.color = Color.green;
					break;
				case PoiType.StartPoint:
					_image.color = Color.blue;
					break;
				case PoiType.FinishPoint:
					_image.color = Color.magenta;
					break;
			}
		}
	#endif
	}
	
	
	
}
