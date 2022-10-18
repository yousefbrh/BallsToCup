using System;
using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InGameView inGameView;
        [SerializeField] private WinView winView;
        [SerializeField] private LoseView loseView;

        public static UIManager instance;
        private void Awake()
        {
            TurnOffAllViews();
            SetInstance();
        }

        private void SetInstance()
        {
            if (!instance)
                instance = this;
        }

        private void TurnOffAllViews()
        {
            inGameView.Hide();
            winView.Hide();
            loseView.Hide();
        }

        public void TurnOnInGameView()
        {
            TurnOffAllViews();
            inGameView.Show();
        }
        
        public void TurnOnWinView()
        {
            TurnOffAllViews();
            winView.Show();
        }
        
        public void TurnOnLoseView()
        {
            TurnOffAllViews();
            loseView.Show();
        }
    }
}