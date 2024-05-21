using System;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace com.euge.robokiller.Client.Features.PopupFeature
{
	public class Popup : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;
		[SerializeField] private Button _replayButton;
		
		public event Action OnReplay; 
		public void Show(string text)
		{
			_text.text = text;
			_replayButton.onClick.AddListener(OnClick);
		}
		
		private void OnClick()
		{
			OnReplay?.Invoke();
			DestroyPopup();
		}
		
		private void DestroyPopup()
		{
			_replayButton.onClick.RemoveListener(OnClick);
			Destroy(gameObject);
		}
	}
}
