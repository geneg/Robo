using UnityEngine;

namespace com.euge.minigame.Utils
{
	public static class VectorExtentions
	{
		public static Vector2 Unscale(this Vector2 position, Vector2 scale)
		{
			return new Vector2(position.x / scale.x, position.y / scale.y);
		}
		
		public static Vector2 ApplyScale(this Vector2 position, Vector2 scale)
		{
			return new Vector2(position.x * scale.x, position.y * scale.y);
		}
	}
}
