using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ProgressBar : InteractiveUI
    {

        public Scrollbar ScrollBarUI;

        private void Start()
        {
            SetCamera();
            ScrollBarUI.size = 0;
        }

        private void Update()
        {
            UpdateUI();
        }

        public void SetValue(float value)
        {
            ScrollBarUI.size = value;
        }

    }
}
