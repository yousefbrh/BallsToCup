using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameView : View
    {
        [SerializeField] private Text ballsCountText;

        public void SetBallsCountText(int currentCount, int wholeCount)
        {
            ballsCountText.text = currentCount + " / " + wholeCount;
        }
    }
}