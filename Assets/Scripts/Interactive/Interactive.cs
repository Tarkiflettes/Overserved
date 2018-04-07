using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public abstract class Interactive : MonoBehaviour
    {
        public Sprite Image;

        private UIObject _uiObject;

        protected void InitGui()
        {
            _uiObject = GetComponentInChildren<UIObject>();
            _uiObject.SetImage(Image);
        }

        public abstract void Interact();

        public void EnableUi(bool state)
        {
            _uiObject.Enable(state);
        }
    }
}
