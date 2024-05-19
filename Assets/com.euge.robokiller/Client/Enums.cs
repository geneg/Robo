using System;

namespace com.euge.robokiller.Client
{
	[Serializable]
	public enum ItemType
	{
		enemy = 0,
		chest = 1,
		rank = 2,

	}
	
	[Serializable]
	public enum PowerUpType
	{
		health = 0,
		bomb = 1,
		shield = 2,
		sword = 3,
		rankUp = 4,
		damage = 5, //negative powerup
		
	}
}
