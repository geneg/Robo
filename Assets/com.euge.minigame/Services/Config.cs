
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Utils;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace com.euge.minigame.Services
{
	public class Config : BaseService
	{
		private const string APP_CONFIG_ADDRESS = "AppConfig";
		private AppConfiguration _appConfiguration;

		public AppConfiguration AppConfig => _appConfiguration;

		public async Task Initialize()
		{
			_appConfiguration = await Loaders.LoadAsset<AppConfiguration>(APP_CONFIG_ADDRESS);
		}
	}
}
