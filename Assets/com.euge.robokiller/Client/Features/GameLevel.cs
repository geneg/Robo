
using System;
using System.Collections.Generic;
using UnityEngine;


namespace com.euge.robokiller.Client.Features
{

    public class GameLevel : MonoBehaviour, IThemeable
    {
        [Header("Game Level Path for Hero Movement")]
        [SerializeField] private LineRenderer _movementPath;
        
        [Space(10)]
        [Header("POI Coords and Types")]
        [SerializeField] private POI[] _pointsOfInterest;

        public POI[] PointsOfInterest => _pointsOfInterest;
        
        [SerializeField] private List<ThemeableElement> _themeableElements;

        public List<ThemeableElement> GetThemeableElements() => _themeableElements;
        public LineRenderer MovementPath => _movementPath;
        
        private void Start()
        {
            _movementPath.enabled = false;
        }
    }
}
