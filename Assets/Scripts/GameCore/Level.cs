using System;
using Entities;
using UnityEngine;

namespace GameCore
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int levelNumber;
        [SerializeField] private int ballsCount;
        [SerializeField] private Cup cup;

        public int LevelNumber => levelNumber;

        private void Start()
        {
            cup.Initialize(ballsCount);
        }
    }
}