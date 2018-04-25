using Assets.Scripts.Manager;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public abstract class Interactive : MonoBehaviour
    {
        public Sprite Image;

        private InteractiveUI _interactiveUI;

        void Start()
        {
            SetUI();
        }

        protected void SetUI()
        {
            if (Image == null)
                return;
            var Ui = Instantiate(GameManager.AssetsManager.InteractivesUI);
            _interactiveUI = Ui.GetComponentInChildren<InteractiveUI>();
            _interactiveUI.transform.SetParent(transform, false);
            if (_interactiveUI != null)
                _interactiveUI.SetImage(Image);
        }

        public abstract void Interact();
        public abstract void Interact(GameObject obj);

        public void EnableUi(bool state)
        {
            _interactiveUI.Enable(state);
        }
    }
}
