using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Services;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class ItemsFeature : BaseService
	{

		public ItemsFeature(ServiceResolver resolver) : base(resolver) { }
		public override Task Initialize()
		{
			return Task.CompletedTask;
		}
	}
}
