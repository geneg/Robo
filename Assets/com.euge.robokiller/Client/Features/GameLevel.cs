
using System.Collections.Generic;
using UnityEngine;


namespace com.euge.robokiller.Client.Features
{

    public class GameLevel : MonoBehaviour, IThemeable
    {
        [Header("Game Level Path Curve for Hero Movement")]
        [SerializeField] private AnimationCurve _pathCurve;
        [Space(10)]
        [Header("POI Coords and Types")]
        [SerializeField] private POI[] _pointsOfInterest;

        public POI[] PointsOfInterest => _pointsOfInterest;
        
        [SerializeField] private List<ThemeableElement> _themeableElements;

        public List<ThemeableElement> GetThemeableElements() => _themeableElements;
    }
}
