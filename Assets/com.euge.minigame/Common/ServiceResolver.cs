using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Services;

namespace com.euge.minigame.Common
{
	public class ServiceResolver
	{
		private readonly Dictionary<Type, BaseService> _services = new Dictionary<Type, BaseService>();

		public void RegisterService<T>(T service) where T : BaseService
		{
			service.InjectServiceResolver(this);
			_services[typeof(T)] = service;
		}

		public T GetService<T>() where T : BaseService
		{
			if (_services.TryGetValue(typeof(T), out BaseService service))
			{
				return service as T;
			}
			else
			{
				throw new InvalidOperationException("Service of type " + typeof(T) + " not found.");
			}
		}

		public async Task InitializeServices()
		{
			foreach (BaseService service in _services.Values)
			{
				await service.Initialize();
			}
		}
	}
}
