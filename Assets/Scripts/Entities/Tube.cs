using System;
using DefaultNamespace;
using UnityEngine;

namespace Entities
{
    public class Tube : MonoBehaviour
    {
        [SerializeField] private Ball ballPrefab;
        [SerializeField] private Transform ballPlacement;
        [SerializeField] private ExitTubePortalHandler exitTubePortalHandler;
        
        private int _tubeCapacity;

        public Action onLevelFinished;

        public void Initialize(int tubeCapacity)
        {
            SetTubeCapacity(tubeCapacity);
            CreateBalls();
            exitTubePortalHandler.onBallExit += CheckFinish;
        }

        private void CheckFinish()
        {
            if (exitTubePortalHandler.ExitBallsCount() == _tubeCapacity)
                onLevelFinished?.Invoke();
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

        private void OnDestroy()
        {
            exitTubePortalHandler.onBallExit -= CheckFinish;
            exitTubePortalHandler.DestroyBalls();
        }
    }
}