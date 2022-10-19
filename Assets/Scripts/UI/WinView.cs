using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinView : View
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
                button.onClick.AddListener(WinAction);
            else 
                button.onClick.RemoveListener(WinAction);
        }

        private void WinAction()
        {
            Debug.Log("sdsdsdsdsd");
        }

        public override void Hide()
        {
            base.Hide();
            SubscribeWinButton(false);
        }
    }
}