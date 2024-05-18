using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Services;
using UnityEngine;

namespace com.euge.minigame
{
	public abstract class Minigame
	{
		public Minigame() { }
		
		protected readonly ServiceResolver _serviceResolver = new ServiceResolver();
		
		public virtual async Task Initialize()
		{
			//create common services for generic minigame (Config, Analytics, Apple/Google Login/IAP, Logger, etc...) 
			_serviceResolver.RegisterService(new Config());
			
			//initialize services in specific order
			await _serviceResolver.InitializeServices();
		}
		
	}
}
