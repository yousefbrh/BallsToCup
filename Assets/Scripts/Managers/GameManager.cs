using System;
using DefaultNamespace;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        
        private void Awake()
        {
            if (!instance)
                instance = this;
        }

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

        public void LevelFinished(bool isWin)
        {
            if (isWin)
                UIManager.instance.TurnOnWinView();
            else 
                UIManager.instance.TurnOnLoseView();
        }

        public void Win()
        {
            LevelManager.instance.LevelFinished(true);
            UIManager.instance.TurnOnInGameView();
        }

        public void Lose()
        {
            LevelManager.instance.LevelFinished(false);
            UIManager.instance.TurnOnInGameView();
        }
    }
}