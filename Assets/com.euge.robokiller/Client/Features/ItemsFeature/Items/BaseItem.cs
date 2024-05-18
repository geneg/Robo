using System.Numerics;

namespace com.euge.robokiller.Client.Features.ItemsFeature
{
	public abstract class BaseItem
	{
		public Vector2 Position { get; set; }
		public abstract void Interact();
	}
}
