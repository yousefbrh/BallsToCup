using System;
using System.Collections.Generic;
using GameCore;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Level> levels = new List<Level>();

        private int _currentLevelNumber;

        private Level _currentLevel;

        public static LevelManager instance;

        private void Awake()
        {
            if (!instance)
                instance = this;
        }

        public void SetCurrentLevel(int value)
        {
            _currentLevelNumber = value;
            _currentLevelNumber %= levels.Count;
        }

        public void LoadLevel()
        {
            var chosenLevel = levels.Find(level => level.LevelNumber - 1 == _currentLevelNumber);
            _currentLevel = Instantiate(chosenLevel);
        }

        public void LevelFinished(bool isWon)
        {
            Destroy(_currentLevel.gameObject);
            if (isWon)
                SetCurrentLevel(_currentLevelNumber + 1);
            LoadLevel();
        }
    }
}