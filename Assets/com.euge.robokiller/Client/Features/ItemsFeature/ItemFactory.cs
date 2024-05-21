using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using com.euge.minigame.Common;
using com.euge.minigame.Utils;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.PathFeature;
using com.euge.robokiller.Configs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class ItemFactory
	{
		private Transform _parent;
		private readonly ItemsConfiguration _itemsConfig;
		private readonly Dictionary<ItemType, Func<ItemLayout, Task<BaseItem>>> _itemCreators;
		private readonly List<PowerUpEffect> _collection;

		public ItemFactory(Transform parent, List<PowerUpEffect> collection, ItemsConfiguration itemsConfig)
		{
			_collection = collection;
			_parent = parent;
			_itemsConfig = itemsConfig;

			_itemCreators = new Dictionary<ItemType, Func<ItemLayout, Task<BaseItem>>>
			{
				{ ItemType.chest, CreateChest },
				{ ItemType.enemy, CreateEnemy },
				{ ItemType.rank, CreateRank },
			};
		}

		public Task<BaseItem> Create(ItemLayout itemLayout)
		{
			if (_itemCreators.TryGetValue(itemLayout.Type, out var createItem))
			{
				return createItem(itemLayout);
			}

			throw new TypeLoadException($"Unknown item type {itemLayout.Type}");
		}
		
		private async Task<BaseItem> CreateChest(ItemLayout itemLayout)
		{
			Chest item = await Loaders.Instantiate<Chest>(_itemsConfig.ChestKey, _parent);
			item.transform.position = itemLayout.Position;
			return item;
		}

		private async Task<BaseItem> CreateEnemy(ItemLayout itemLayout)
		{
			Enemy item = await Loaders.Instantiate<Enemy>(_itemsConfig.EnemyKey, _parent);

			ItemData data = _itemsConfig.GetItemData(itemLayout.Type);
			item.SetAdditionalData(data.additionalDataJson);
			item.SetCollection(_collection);
			
			item.transform.position = itemLayout.Position;
			return item;
		}

		private async Task<BaseItem> CreateRank(ItemLayout itemLayout)
		{
			Rank item = await Loaders.Instantiate<Rank>(_itemsConfig.RankKey, _parent);
			item.transform.position = itemLayout.Position;
			return item;
		}
	}
	
	
}
