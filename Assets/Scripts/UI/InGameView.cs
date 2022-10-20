using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameView : View
    {
        [SerializeField] private TextMeshProUGUI ballsCountText;
        [SerializeField] private Slider slider;

        public void SetBallsCountText(int currentCount, int wholeCount)
        {
            ballsCountText.text = currentCount + " / " + wholeCount;
            if (wholeCount != 0)
                slider.value = (float) currentCount / wholeCount;
            else 
                Debug.LogError("Divided by zero");
        }
    }
}