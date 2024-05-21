using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;

namespace com.euge.robokiller.Client.Features.InventoryFeature
{
	public interface IInventory
	{
		void UpdatePlayerStats(PowerUpEffect effect);
		InventoryData ReadInventory();
		void AddPowerUpToView(PowerUpEffect effect);
		void RemovePowerUpFromView(PowerUpEffect effect);
	}
}
