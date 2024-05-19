using UnityEngine;

namespace com.euge.robokiller.Client.Features.ItemsFeature.Items
{
	public class Rank : BaseItem
	{
		[SerializeField] private GameObject _rankIcon;
		
		public Rank()
		{
		}

		public override void Interact()
		{
			// Give XP points
		}
	}
}
