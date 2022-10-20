using Managers;

namespace UI
{
    public class WinView : FinishView
    {
        protected override void FinishAction()
        {
            base.FinishAction();
            GameManager.instance.Win();
        }
    }
}