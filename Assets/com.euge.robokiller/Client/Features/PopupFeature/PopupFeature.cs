
using System;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.PopupFeature
{
	public class PopupFeature : BaseService
	{
		private readonly string _popupConfigurationKey;
		private readonly Transform _parent;
		private PopupConfigugation _popupConfig;
		
		public PopupFeature(string configKey, Transform parent)
		{
			_parent = parent;
			_popupConfigurationKey = configKey;
		}
		
		public override async Task Initialize()
		{
			_popupConfig = await Loaders.LoadAsset<PopupConfigugation>(_popupConfigurationKey);
		}
		
		public async void ShowPopup(bool win, Action onReplay)
		{
			Popup popup = await Loaders.Instantiate<Popup>(_popupConfig.AddressableKey, _parent);
			popup.OnReplay += onReplay;
			popup.Show(win? _popupConfig.winner_text : _popupConfig.loser_text);
		}
		
	}
	
	
	
	
}
