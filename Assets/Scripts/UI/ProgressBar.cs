using UnityEngine;
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

        public void SetValue(float value)
        {
            ScrollBarUI.size = 1 - value;
        }

    }
}
