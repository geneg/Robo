using System.Threading.Tasks;
using com.euge.minigame.Common;

namespace com.euge.minigame.Services
{
	public abstract class BaseService
	{

		protected BaseService(ServiceResolver resolver)
		{
			GetServiceResolver = resolver;
		}

		public abstract Task Initialize();
		
		public ServiceResolver GetServiceResolver { get; }
	}
}
