using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public interface IInventory
	{
		void UpdateInventory(PowerUpEffect effect);
		PowerUpEffect ReadInventory(PowerUpEffect effect);
	}
}
