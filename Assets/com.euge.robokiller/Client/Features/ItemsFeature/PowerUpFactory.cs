using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.euge.robokiller.Client.Features.InventoryFeature;
using com.euge.robokiller.Client.Features.ItemsFeature.Items;
using com.euge.robokiller.Client.Features.ItemsFeature.PowerUps;
using com.euge.robokiller.Client.Features.PathFeature;
using com.euge.robokiller.Client.Features.PlayerFeature;
using com.euge.robokiller.Configs;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature {
	public class PowerUpFactory
	{
		private readonly ItemsConfiguration _itemsConfig; 
		private readonly Transform _parent;
		private readonly IInventory _inventory;

		public PowerUpFactory(Transform parent, IInventory inventory, ItemsConfiguration powerUpConfig)
		{
			_parent = parent;
			_itemsConfig = powerUpConfig;
			_inventory = inventory;
		}
		
		public IPowerUp Create(ItemType itemType)
		{
			List<PowerUpData> dataList = new List<PowerUpData>();
			PowerUpData data = null;
			
			foreach (PowerUpData powerUpData in _itemsConfig.powerUps) //not many powerups, so it's ok to iterate
			{
				if(powerUpData.relatedItemType == itemType)
				{
					dataList.Add(powerUpData);
				}
			}
			
			//if there is more than one constant powerUp for the same item type, choose one randomly
			data = dataList[UnityEngine.Random.Range(0, dataList.Count)];
			
			switch (data.powerUpType)
			{
				case PowerUpType.rankUp:
					return new RankUp(data);
				case PowerUpType.damage:
					return new DamagePowerUp(data, _inventory);
				default:
					throw new Exception("Unknown powerUp type");
			}
		}
		
		public bool IsConstantPowerUp(ItemType itemMetaType)
		{
			foreach (ItemData itemData in _itemsConfig.itemsData)
			{
				if (itemData.itemType == itemMetaType)
				{
					return itemData.contantPowerUp;
				}
			}
			
			return false; 
		}
	}
	
}