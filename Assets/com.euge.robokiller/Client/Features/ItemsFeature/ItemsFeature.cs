using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.PathFeature;
using com.euge.robokiller.Client.Features.ThemesFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class ItemsFeature : BaseService, IThemeable
	{
		private readonly string _itemsConfigurationKey;
		private ItemsConfiguration _itemsConfig;
		private List<BaseItem> _items;
		private InventoryFeature.InventoryFeature _inventoryFeature;
		private MovementFeature _movementFeature;
		private PlayerFeature.PlayerFeature _playerFeature;
		private List<PowerUpEffect> _collection;
		
		
		public ItemsFeature(AppConfiguration appConfig)
		{
			_items = new List<BaseItem>();
			_itemsConfigurationKey = appConfig.ItemsConfigurationKey;
		}

		public void SetCollection(List<PowerUpEffect> collection)
		{
			_collection = collection;
		}
		
		public override async Task Initialize()
		{
			PathFeature.PathFeature pathFeature = GetServiceResolver.GetService<PathFeature.PathFeature>();
			_inventoryFeature = GetServiceResolver.GetService<InventoryFeature.InventoryFeature>();
			_movementFeature = GetServiceResolver.GetService<MovementFeature>();
			_playerFeature = GetServiceResolver.GetService<PlayerFeature.PlayerFeature>();

			ItemLayout[] pathItemsLayout = pathFeature.GetPathItemsLayout();
			Transform itemsParent = pathFeature.GetItemsParent();
			List<Task<BaseItem>> tasks = new List<Task<BaseItem>>();

			_itemsConfig = await Loaders.LoadAsset<ItemsConfiguration>(_itemsConfigurationKey);
			ItemFactory itemFactory = new ItemFactory(itemsParent, _itemsConfig);
			PowerUpFactory powerUpFactory = new PowerUpFactory(itemsParent, _playerFeature, _itemsConfig);

			foreach (ItemLayout itemMeta in pathItemsLayout)
			{
				BaseItem item = await itemFactory.Create(itemMeta);
				item.OnItemExhaust += OnItemExhaust;
				
				if (powerUpFactory.IsConstantPowerUp(itemMeta.Type))
				{
					IPowerUp powerUp = powerUpFactory.Create(itemMeta.Type);
					item.InjectPowerUp(powerUp);
					item.OnClickItem += OnItemClicked;
				}
				else
				{
					item.RequestPowerUp += () => {
						List<PowerUpType> exclude = new List<PowerUpType>();
						InventoryData read = _inventoryFeature.ReadInventory();

						if (read.TotalHealth == read.Health)
						{
							exclude.Add(PowerUpType.health);
						}

						IPowerUp powerUp = powerUpFactory.CreateDynamically(itemMeta.Type, exclude);
						item.InjectPowerUp(powerUp);
						return Task.CompletedTask;
					};
				}

				tasks.Add(Task.FromResult(item));
			}

			BaseItem[] items = await Task.WhenAll(tasks);

			_items.AddRange(items);
		}

		private void OnItemExhaust()
		{
			_movementFeature.ResumeMove();
		}

		private void OnItemClicked(BaseItem item)
		{
			if (_playerFeature.PlayerInteraction())
			{
				// if clicked it means fight so sword is used if available
				
				_collection.ForEach(e => e.Stop());
				
				item.Hit(_inventoryFeature.ReadInventory().Rank);
			}
		}

		public List<ThemeableElement> GetThemeableElements()
		{
			List<ThemeableElement> themeableElements = new List<ThemeableElement>();
			foreach (BaseItem baseItem in _items)
			{
				themeableElements.AddRange(baseItem.GetThemeableElements());
			}

			return themeableElements;
		}
	}
}
