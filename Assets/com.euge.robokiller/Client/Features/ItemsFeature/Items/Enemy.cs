using com.euge.robokiller.Client.Features.ItemsFeature.Items;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class Enemy : BaseItem
	{
		private string _color;
		private float _damageRate;

		public Enemy(string color, float damageRate)
		{
			_color = color;
			_damageRate = damageRate;
		}

		public override void Interact()
		{
			// Apply damage every 1.5 seconds
		}
	}
}
