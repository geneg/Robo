using System.Collections.Generic;
using com.euge.robokiller.Client.Features.ThemesFeature;
using UnityEngine;

namespace com.euge.robokiller.Client.Features.PathFeature
{

    public class GameLevel : MonoBehaviour, IThemeable
    {
        [Header("Game Level Path for Hero Movement")]
        [SerializeField] private LineRenderer _movementPath;
        
        [Space(10)]
        [Header("POI Coords and Types")]
        [SerializeField] private ItemLayout[] _pointsOfInterest;
        [SerializeField] private Transform _itemsParent;
        
        public ItemLayout[] PointsOfInterest => _pointsOfInterest;
        
        [SerializeField] private List<ThemeableElement> _themeableElements;

        public List<ThemeableElement> GetThemeableElements() => _themeableElements;
        public LineRenderer MovementPath => _movementPath;
        public Transform ItemsParent => _itemsParent;
        
        private void Start()
        {
            _movementPath.enabled = false;
        }
    }
}
