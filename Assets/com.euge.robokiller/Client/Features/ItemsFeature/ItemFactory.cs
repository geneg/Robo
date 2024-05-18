

using System;
using System.Threading.Tasks;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.PathFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class ItemFactory
	{
		private Transform _parent;
		private readonly ItemsConfiguration _itemsConfig;

		public ItemFactory(Transform parent, ItemsConfiguration itemsConfig)
		{
			_parent = parent;	
			_itemsConfig = itemsConfig;
		}
		
		public async Task<BaseItem> CreateItem(ItemLayout itemLayout)
		{
			BaseItem item;
			switch (itemLayout.Type)
			{
				case ItemType.chest:
					item = await Loaders.Instantiate<Chest>(_itemsConfig.ChestKey, _parent);
					item.transform.position = itemLayout.Position;
					return item;
				case ItemType.enemy:
				// Choose a color and damage rate
				//string color = // ...
				//	float damageRate = // ...
				//return new Robot(color, damageRate) { Position = position };
				case ItemType.rank:
				// Choose XP points
				//int xpPoints = // ...
				//return new Rank(xpPoints) { Position = position };
				default:
					item = await Loaders.Instantiate<Chest>(_itemsConfig.ChestKey, _parent);
					item.transform.position = itemLayout.Position;
					return item;
			}
		}
	}
}
