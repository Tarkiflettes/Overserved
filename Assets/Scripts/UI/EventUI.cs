using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EventUI : MonoBehaviour
    {

        public Scrollbar ScrollBarUI;
        public Image Icon;

        private void Start()
        {
            ScrollBarUI.size = 1;
        }

        public void SetValue(float value)
        {
            ScrollBarUI.size = 1 - value;
        }

    }
}
