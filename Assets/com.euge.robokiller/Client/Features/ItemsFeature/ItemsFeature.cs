using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.minigame.Configs;
using com.euge.minigame.Services;
using com.euge.minigame.Utils;
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
		
		public ItemsFeature(AppConfiguration appConfig)
		{
			_items = new List<BaseItem>();
			_itemsConfigurationKey = appConfig.ItemsConfigurationKey;
		}
		
		public override async Task Initialize()
		{
			PathFeature.PathFeature pathFeature = GetServiceResolver.GetService<PathFeature.PathFeature>();
			InventoryFeature.InventoryFeature inventoryFeature = GetServiceResolver.GetService<InventoryFeature.InventoryFeature>();
			
			ItemLayout[] pathItemsLayout = pathFeature.GetPathItemsLayout();
			Transform itemsParent = pathFeature.GetItemsParent();
			List<Task<BaseItem>> tasks = new List<Task<BaseItem>>();
			
			_itemsConfig = await Loaders.LoadAsset<ItemsConfiguration>(_itemsConfigurationKey);
			ItemFactory itemFactory = new ItemFactory(itemsParent, _itemsConfig);
			PowerUpFactory powerUpFactory = new PowerUpFactory(itemsParent, inventoryFeature, _itemsConfig);
			
			foreach (ItemLayout itemMeta in pathItemsLayout)
			{
				BaseItem item = await itemFactory.Create(itemMeta);
				
				if (powerUpFactory.IsConstantPowerUp(itemMeta.Type))
				{
					IPowerUp powerUp = powerUpFactory.Create(itemMeta.Type);
					item.InjectPowerUp(powerUp); 
				}
				
				tasks.Add(Task.FromResult(item));
			}

			BaseItem[] items = await Task.WhenAll(tasks);

			_items.AddRange(items);
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
