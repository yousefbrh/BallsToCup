using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private List<Material> materials = new List<Material>();
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private PhysicMaterial bounceMaterial;
        [SerializeField] private Collider collider;
        [SerializeField] private bool isBouncing;
        private Transform _rootTransform;

        public void Initialize()
        {
            _rootTransform = transform.parent;
            SetRandomMaterial();
        }

        private void SetRandomMaterial()
        {
            var randomNumber = Random.Range(0, materials.Count - 1);
            var randomMaterial = materials[randomNumber];
            meshRenderer.material = new Material(randomMaterial);
        }

        public void BallIsOutsideOfTube()
        {
            transform.SetParent(_rootTransform, true);
            ActiveBouncing();
        }

        private void ActiveBouncing()
        {
            collider.material = bounceMaterial;
        }
    }
}