using System;
using DefaultNamespace;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            LoadGameData();
        }

        private void LoadGameData()
        {
            var currentLevel = Prefs.CurrentLevel;
            LevelManager.instance.SetCurrentLevel(currentLevel);
            StartLevel();
        }

        private void StartLevel()
        {
            LevelManager.instance.LoadLevel();
            UIManager.instance.TurnOnInGameView();
        }

        public void Win()
        {
            UIManager.instance.TurnOnWinView();
            LevelManager.instance.LevelFinished(true);
        }

        public void Lose()
        {
            UIManager.instance.TurnOnLoseView();
            LevelManager.instance.LevelFinished(false);
        }
    }
}