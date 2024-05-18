using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ThemesFeature;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.PlayerFeature
{
	public class Player : MonoBehaviour,IThemeable
	{
		
		[SerializeField] private GameObject _regularPose;
		[SerializeField] private GameObject _attackPose;
		
		[SerializeField] private List<ThemeableElement> _themeableElements;
		[SerializeField] RectTransform _playerTransform;

		public RectTransform PlayerTransform => _playerTransform;
		public List<ThemeableElement> GetThemeableElements() => _themeableElements;
		
		public void SetIdlePose()
		{
			_regularPose.SetActive(true);
			_attackPose.SetActive(false);
		}
		
		public void SetAttackPose()
		{
			_regularPose.SetActive(false);
			_attackPose.SetActive(true);
		}
	}
}
