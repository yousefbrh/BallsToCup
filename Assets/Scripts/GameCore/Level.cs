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
        [SerializeField] private ParticleSystem levelFinishedParticle;

        private bool _isPlayerWon;
        private bool _isLevelFinished;
        private bool _isParticlePlayed;

        public int LevelNumber => levelNumber;

        private void Start()
        {
            cup.Initialize(ballsCountOnCup);
            tube.Initialize(ballsCountOnTube);
            cup.onCupLimitReached += PlayerWon;
            tube.onLevelFinished += PrepareLevelToFinish;
        }

        private void PlayerWon()
        {
            _isPlayerWon = true;
            if (_isLevelFinished)
                ParticleHandler();
        }

        private void PrepareLevelToFinish()
        {
            _isLevelFinished = true;
            ParticleHandler();
            Invoke("LevelFinished", 2f);
        }

        private void LevelFinished()
        {
            ParticleHandler();
            GameManager.instance.LevelFinished(_isPlayerWon);
        }

        private void ParticleHandler()
        {
            if (!_isPlayerWon || _isParticlePlayed) return;
            levelFinishedParticle.Play();
            _isParticlePlayed = true;
        }

        private void OnDestroy()
        {
            tube.onLevelFinished -= PrepareLevelToFinish;
            cup.onCupLimitReached -= PlayerWon;
        }
    }
}