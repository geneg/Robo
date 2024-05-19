using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class HpBar : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private TMP_Text _text;
		public void SetTotal(int hitPoints)
		{
			_slider.minValue = 0;
			_slider.maxValue = hitPoints;
			_text.text = hitPoints.ToString();
		}
		
		public void SetValue(int hitPoints)
		{
			_slider.value = hitPoints;
			_text.text = hitPoints.ToString();
		}
	}
}
