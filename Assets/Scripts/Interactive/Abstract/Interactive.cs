using Assets.Scripts.Manager;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Interactive.Abstract
{
    public abstract class Interactive : MonoBehaviour
    {

        public Sprite Image;
        [HideInInspector]
        public bool IsInteracting = false;
        public bool HasProgressBar = false;

        protected ProgressBar ProgressBar;

        private Icon _icon;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            SetUI();
        }

        public abstract void Interact();
        public abstract void Interact(GameObject obj);
        public abstract bool AcceptRaycast();

        private void SetUI()
        {
            InitIcon();
            InitProgressBar();
        }

        private void InitIcon()
        {
            if (Image == null)
                return;
            var ui = Instantiate(GameManager.AssetsManager.Icon);
            _icon = ui.GetComponentInChildren<Icon>();
            if (_icon == null)
                return;
            _icon.transform.SetParent(transform, false);
            _icon.SetImage(Image);
        }

        private void InitProgressBar()
        {
            if (!HasProgressBar)
                return;
            var ui = Instantiate(GameManager.AssetsManager.ProgressBar);
            ProgressBar = ui.GetComponentInChildren<ProgressBar>();
            if (ProgressBar == null)
                return;
            ProgressBar.transform.SetParent(transform, false);
            ProgressBar.Enable(false);
        }

        public void EnableUi(bool state)
        {
            EnableIcon(state);
            EnableProgressbar(state);
        }

        public void EnableIcon(bool state)
        {
            if (_icon != null)
                _icon.Enable(state);
        }

        public void EnableProgressbar(bool state)
        {
            if (HasProgressBar && ProgressBar != null)
                ProgressBar.Enable(state);
        }

    }
}
