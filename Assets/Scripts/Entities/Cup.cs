using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Entities
{
    public class Cup : MonoBehaviour
    {
        private int _cupCapacity;
        private int _currentBallsCount;

        public void Initialize(int cupCapacity)
        {
            _cupCapacity = cupCapacity;
            UpdateBallsCountUI();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Ball")) return;
            _currentBallsCount++;
            UpdateBallsCountUI();
            other.tag = "BallInsideCup";
        }

        private void UpdateBallsCountUI()
        {
            UIManager.instance.InGameView.SetBallsCountText(_currentBallsCount, _cupCapacity);
        }
    }
}