using UnityEngine.Events;

namespace MagicSpace.LS
{
    public class MainMenuController : BaseScreen
    {
        public UnityEvent playClicked;

        public void OnPlayButtonClicked()
        {
            HideAllViews();
            playClicked.Invoke();
        }

        private void Start()
        {
            ShowAllViews();
        }
    }
}

