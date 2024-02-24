using System;
using UnityEngine;

namespace HomeTask.Lesson1
{
    [Serializable]
    internal class BallsSettings
    {
        [SerializeField] private BallComponent[] _ballsPrefabs;
        [SerializeField] private int _singleColorBallsCount=3;
        [SerializeField] private float _gridWidth=8;
        [SerializeField] private float _gridHeight=4;
        [SerializeField] private float _minDistance= 2;

        public BallComponent[] BallsPrefabs => _ballsPrefabs;
        public int SingleColorBallsCount => _singleColorBallsCount; 
        public float GridWidth => _gridWidth;
        public float GridHeight => _gridHeight;
        public float MinDistance => _minDistance;
    }
}
