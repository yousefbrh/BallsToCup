using Managers;

namespace UI
{
    public class LoseView : FinishView
    {
        protected override void FinishAction()
        {
            base.FinishAction();
            GameManager.instance.Lose();
        }
    }
}