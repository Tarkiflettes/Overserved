using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EventUI : MonoBehaviour
    {

        public Scrollbar ScrollBarUI;
        public Image Icon;

        public Sprite _image;

        private void Start()
        {
            ScrollBarUI.size = 1;
        }

        public void Init(Sprite image)
        {
            Icon.sprite = image;
        }

        public void SetValue(float value)
        {
            ScrollBarUI.size = 1 - value;
        }

    }
}
