using System;
using Entities;
using UnityEngine;

namespace GameCore
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int levelNumber;
        [SerializeField] private int ballsCountOnTube;
        [SerializeField] private int ballsCountOnCup;
        [SerializeField] private Cup cup;
        [SerializeField] private Tube tube;

        public int LevelNumber => levelNumber;

        private void Start()
        {
            cup.Initialize(ballsCountOnCup);
            tube.Initialize(ballsCountOnTube);
            tube.onLevelFinished += LevelFinished;
        }

        private void LevelFinished()
        {
            
        }

        private void OnDestroy()
        {
            tube.onLevelFinished -= LevelFinished;
        }
    }
}