using System;
using Entities;
using Managers;
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

        private bool _isPlayerWon;

        public int LevelNumber => levelNumber;

        private void Start()
        {
            cup.Initialize(ballsCountOnCup);
            tube.Initialize(ballsCountOnTube);
            cup.onCupLimitReached += PlayerWon;
            tube.onLevelFinished += LevelFinished;
        }

        private void PlayerWon()
        {
            _isPlayerWon = true;
        }

        private void LevelFinished()
        {
            if (_isPlayerWon)
                GameManager.instance.Win();
            else 
                GameManager.instance.Lose();
        }

        private void OnDestroy()
        {
            tube.onLevelFinished -= LevelFinished;
        }
    }
}