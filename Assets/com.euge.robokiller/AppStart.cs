using com.euge.minigame;
using com.euge.robokiller.Client;
using UnityEngine;

namespace com.euge.robokiller
{
	public class AppStart : MonoBehaviour
	{
		private Minigame _minigame;
		
		
		[SerializeField] 
		[Tooltip("Contains some of the top level visual elements to reference them.")]
		private VisualBridge _visualBridge;
		
		private void Awake()
		{
			_minigame = new RoboKiller(_visualBridge);
		}
		
		private async void Start()
		{
			await _minigame.Initialize();
		}
		
		private void OnDestroy()
		{
			
		}
	}
}
