using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameView : View
    {
        [SerializeField] private TextMeshProUGUI ballsCountText;

        public void SetBallsCountText(int currentCount, int wholeCount)
        {
            ballsCountText.text = currentCount + " / " + wholeCount;
        }
    }
}