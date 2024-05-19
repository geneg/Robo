using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.euge.minigame.Utils
{
	public static class Loaders
	{
		private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
		
		public static async Task<T> LoadAsset<T>(string configFileKey)
		{
			if (_cache.TryGetValue(configFileKey, out object cachedAsset))
			{
				return (T)cachedAsset;
			}
			
			AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(configFileKey);
			await handle.Task;
					
			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				 // Store the loaded asset in the cache
				_cache[configFileKey] = handle.Result;
				return handle.Result;
			}
			else
			{
				throw new System.Exception("Failed to load config");
			}
		}
		
		public static async Task<T> Instantiate<T>(string prfabKey, Transform parent) where T : class
		{
			AsyncOperationHandle<GameObject> loadHandle = Addressables.LoadAssetAsync<GameObject>(prfabKey);
			await loadHandle.Task;

			if (loadHandle.Status == AsyncOperationStatus.Succeeded)
			{
				AsyncOperationHandle<GameObject> instantiateHandle = Addressables.InstantiateAsync(prfabKey, parent);

				await instantiateHandle.Task;
				if (instantiateHandle.Status == AsyncOperationStatus.Succeeded)
				{
					GameObject instantiatedPrefab = instantiateHandle.Result;
					
					T result = instantiatedPrefab.GetComponent<T>();
					if (result != null)
					{
						return result;
					}
					else
					{
						throw new System.Exception("The instantiated prefab does not contain a component of type " + typeof(T).Name);
					}
				}
				else
				{
					throw new System.Exception("Failed to instantiate prefab");
				}
			}
			else
			{
				throw new System.Exception("Failed to load config");
			}
		}
	}
}
