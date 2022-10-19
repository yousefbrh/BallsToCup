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
        private bool _isCupReachItsLimit;

        public Action onCupLimitReached;

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
            if (!_isCupReachItsLimit) 
                CheckIfCupReachItsLimit();
        }

        private void CheckIfCupReachItsLimit()
        {
            if (_currentBallsCount != _cupCapacity) return;
            onCupLimitReached?.Invoke();
            _isCupReachItsLimit = true;
        }

        private void UpdateBallsCountUI()
        {
            UIManager.instance.InGameView.SetBallsCountText(_currentBallsCount, _cupCapacity);
        }
    }
}