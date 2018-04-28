using Assets.Scripts.Manager;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public abstract class Interactive : MonoBehaviour
    {
        public Sprite Image;

        private Icon _iconUI;

        private void Start()
        {
            SetUI();
        }

        protected void SetUI()
        {
            if (Image == null)
                return;
            var Ui = Instantiate(GameManager.AssetsManager.InteractivesUI);
            _iconUI = Ui.GetComponentInChildren<Icon>();
            _iconUI.transform.SetParent(transform, false);
            if (_iconUI != null)
                _iconUI.SetImage(Image);
        }

        public abstract void Interact();
        public abstract void Interact(GameObject obj);

        public void EnableUi(bool state)
        {
            _iconUI.Enable(state);
        }
    }
}
