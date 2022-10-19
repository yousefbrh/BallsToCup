using Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExitTubePortalHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Ball")) return;
            other.GetComponent<Ball>().BallIsOutsideOfTube();
        }
    }
}