using UnityEngine;

namespace UI
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject container;

        public virtual void Show()
        {
            container.SetActive(true);
        }

        public virtual void Hide()
        {
            container.SetActive(false);
        }
    }
}