using System;
using UnityEngine;

namespace Entities
{
    public class Tube : MonoBehaviour
    {
        [SerializeField] private Ball ballPrefab;
        [SerializeField] private Transform ballPlacement;
        
        private int _tubeCapacity;

        public void Initialize(int tubeCapacity)
        {
            SetTubeCapacity(tubeCapacity);
            CreateBalls();
        }

        private void SetTubeCapacity(int amount)
        {
            _tubeCapacity = amount;
        }

        private void CreateBalls()
        {
            for (var i = 0; i < _tubeCapacity; i++)
            {
                var ballClone = Instantiate(ballPrefab, ballPlacement.position, Quaternion.identity);
                ballClone.Initialize();
                ballClone.transform.SetParent(ballPlacement, true);
            }
        }
    }
}