using System;
using com.euge.robokiller.Client;
using com.euge.robokiller.Client.Features.PlayerFeature;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace com.euge.robokiller.Configs
{
	[CreateAssetMenu(fileName = "ItemsConfigugation", menuName = "Configs/ItemsConfigugation")]
	public class ItemsConfiguration : ScriptableObject
	{
		public string ChestKey;
		public string EnemyKey;
		public string RankKey;
		
		public ItemData[] itemsData;
		public PowerUpData[] powerUps;
	}

	[Serializable]
	public class ItemData
	{
		public ItemType itemType;
		
		[Tooltip("power-up is constant for and does not change during the game")]
		public bool contantPowerUp;
	}
	
	[Serializable]
	public class PowerUpData
	{
		public PowerUpType powerUpType;
		public ItemType relatedItemType;
		public Sprite powerUpSprite;
		
		[Tooltip("If the value is 0.5, the effect is applied every 0.5 seconds. If the value is 0, the effect is applied only once.")]
		public float EffectFrequency;
		
		[field: NonSerialized]
		public Inventory Inventory { get; set;}
	}
}
