using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FinishView : View
    {
        [SerializeField] private Button button;

        public override void Show()
        {
            base.Show();
            SubscribeWinButton(true);
        }

        private void SubscribeWinButton(bool isSubscribing)
        {
            if (isSubscribing)
                button.onClick.AddListener(FinishAction);
            else 
                button.onClick.RemoveListener(FinishAction);
        }
        
        protected virtual void FinishAction()
        {
            Hide();
        }

        public override void Hide()
        {
            base.Hide();
            SubscribeWinButton(false);
        }

        private void OnDestroy()
        {
            SubscribeWinButton(false);
        }
    }
}