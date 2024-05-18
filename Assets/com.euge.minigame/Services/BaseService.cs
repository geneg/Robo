using System.Threading.Tasks;
using com.euge.minigame.Common;

namespace com.euge.minigame.Services
{
	public abstract class BaseService
	{
		private ServiceResolver _resolver;
		protected BaseService()
		{
		}

		public void InjectServiceResolver(ServiceResolver resolver)
		{
			_resolver = resolver;
		}
		
		public abstract Task Initialize();
		
		public ServiceResolver GetServiceResolver => _resolver;
	}
}
