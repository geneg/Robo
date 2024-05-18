using com.euge.robokiller.Client.Features.ItemsFeature.Items;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class Rank : BaseItem
	{
		private int _xpPoints;

		public Rank(int xpPoints)
		{
			_xpPoints = xpPoints;
		}

		public override void Interact()
		{
			// Give XP points
		}
	}
}
