using UnityEngine;

namespace UI
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject container;

        public void Show()
        {
            container.SetActive(true);
        }

        public void Hide()
        {
            container.SetActive(false);
        }
    }
}