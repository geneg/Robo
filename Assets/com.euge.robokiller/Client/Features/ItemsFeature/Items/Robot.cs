namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public class Robot : BaseItem
	{
		private string _color;
		private float _damageRate;

		public Robot(string color, float damageRate)
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
