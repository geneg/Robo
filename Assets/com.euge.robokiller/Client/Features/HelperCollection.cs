using com.euge.minigame.Common;

namespace com.euge.robokiller.Client.Features
{
	public class HelperCollection
	{
		private readonly ServiceResolver _resolver;
		public HelperCollection(ServiceResolver resolver)
		{
			_resolver = resolver;
		}

		public void InjectCollection()
		{
			InventoryFeature.InventoryFeature feature = _resolver.GetService<InventoryFeature.InventoryFeature>();
			_resolver.GetService<ItemsFeature.ItemsFeature>().SetCollection(feature.GetCollection());
			_resolver.GetService<PlayerFeature.PlayerFeature>().SetCollection(feature.GetCollection());
		}
	}
}
