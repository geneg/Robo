using System;
using System.Collections.Generic;
using com.euge.robokiller.Client;
using UnityEngine;
using UnityEngine.Serialization;

namespace com.euge.robokiller.Configs
{
	[Serializable]
	public class PointOfInterest
	{
		public ItemType type;
		public Sprite[] sprites;
	}
	
	[CreateAssetMenu(fileName = "New Theme", menuName = "Configs/Create New Theme")]
	public class ThemeTemplate : ScriptableObject
	{
		public Sprite background;
		public Sprite path;
		public Sprite[] player;
		public List<PointOfInterest> poi;
	}
}
