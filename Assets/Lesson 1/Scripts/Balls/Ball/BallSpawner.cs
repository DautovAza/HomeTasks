using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeTask.Lesson1
{
    internal class BallSpawner
    {
        private const int MaxIterations = 10000;
        private BallComponent[] _ballsPrefabs;
        private int _signgleColorBallsCount;
        private float _minDistance;
        private float _gridHalfWidth;
        private float _gridHalfHeight;

        public BallSpawner(BallsSettings settings)
        {
            _ballsPrefabs = settings.BallsPrefabs;
            _signgleColorBallsCount = settings.SingleColorBallsCount;
            _gridHalfWidth = settings.GridWidth;
            _gridHalfHeight = settings.GridHeight;
            _minDistance = settings.MinDistance;
        }

        public IEnumerable<BallComponent> Spawn()
        {
            List<Vector3> spawnPositions = GenerateSpawnPositions();
            List<BallComponent> balls = new List<BallComponent>();
            int prefabIndex = 0;

            foreach (Vector3 spawnPosition in spawnPositions)
            {
                var ball = UnityEngine.Object.Instantiate(_ballsPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
                prefabIndex = (prefabIndex + 1) % _ballsPrefabs.Length;

                balls.Add(ball);
            }

            return balls;
        }

        private List<Vector3> GenerateSpawnPositions()
        {
            List<Vector3> spawnPositions = new List<Vector3>();

            int totalObjects = _signgleColorBallsCount * _ballsPrefabs.Length;
            for (int i = 0; i < totalObjects; i++)
            {
                bool validPosition = false;
                Vector3 spawnPosition = Vector3.zero;

                int iterations = 0;

                while (!validPosition)
                {
                    iterations ++;

                    if (iterations > MaxIterations)
                    {
                        throw new Exception("Не удалось построить уровень с задаными параметрами!");
                    }

                    float randomX = Random.Range(-_gridHalfWidth, _gridHalfWidth);
                    float randomY = Random.Range(-_gridHalfHeight, _gridHalfHeight);
                    spawnPosition = new Vector3(randomX, randomY, 0f);

                    validPosition = true;
                    foreach (Vector3 occupiedPos in spawnPositions)
                    {
                        if (Vector3.Distance(spawnPosition, occupiedPos) < _minDistance)
                        {
                            validPosition = false;
                            break;
                        }
                    }

                }

                spawnPositions.Add(spawnPosition);
            }

            return spawnPositions;
        }
    }
}
