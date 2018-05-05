using System;
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

        private Icon _iconUI;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
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
        public abstract bool AcceptRaycast();

        public void EnableUi(bool state) {
            if (_iconUI == null)
                    return;
            _iconUI.Enable(state);
        }

    }
}
