using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExitTubePortalHandler : MonoBehaviour
    {
        private List<Ball> _exitBalls = new List<Ball>();
        
        public Action onBallExit;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("BallInsideTube")) return;
            var ball = other.GetComponent<Ball>();
            ball.BallIsOutsideOfTube();
            _exitBalls.Add(ball);
            other.tag = "Ball";
            onBallExit?.Invoke();
        }

        public int ExitBallsCount()
        {
            return _exitBalls.Count;
        }
    }
}