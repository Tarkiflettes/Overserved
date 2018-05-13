using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Manager;
using Assets.Scripts.UI;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Phone : Usable
    {

        public bool IsOffTheHook
        {
            get { return _callDuration > 0; }
        }
        public readonly int CallDuration = 100;
        public readonly int ClientDuration = 200;

        private bool _isRigging;
        private int _callDuration;
        private int _clientDuration;
        private EventUI _eventUI;

        protected override void Init()
        {
            base.Init();
            EnableProgressbar(false);
        }

        private void Update()
        {
            if (IsOffTheHook)
            {
                if (IsInteracting)
                    Talk();
                else
                    ClientIsWaiting();
            }
            else if (_isRigging)
                ClientIsWaiting();
        }

        public override void Interact()
        {
            PickUp();
        }

        private void Talk()
        {
            _callDuration--;
            ProgressBar.SetValue(_callDuration.ToPercent(CallDuration));
            if (_callDuration == 0)
                HangUp();
        }

        private void ClientIsWaiting()
        {
            _clientDuration--;
            _eventUI.SetValue(_clientDuration.ToPercent(ClientDuration));
            if (_clientDuration == 0)
                ClientHasHangedUp();
        }

        private void PickUp()
        {
            if (IsOffTheHook || !_isRigging)
                return;
            _isRigging = false;
            EnableProgressbar(true);
            _callDuration = CallDuration; // todo : random
        }

        private void HangUp()
        {
            BookTable();
            ResetPhone();
        }

        private void ClientHasHangedUp()
        {
            ResetPhone();
            // todo : lose points
        }

        private void ResetPhone()
        {
            GameManager.Instance.UIManager.RemoveEvent(_eventUI);
            EnableProgressbar(false);
            _eventUI = null;
            _clientDuration = 0;
            _callDuration = 0;
            _isRigging = false;
        }

        public void Ring()
        {
            if (IsOffTheHook)
                return;
            _isRigging = true;
            _clientDuration = ClientDuration; // todo : random
            _eventUI = GameManager.Instance.UIManager.AddEvent(null);
            ProgressBar.SetValue(_callDuration.ToPercent(CallDuration));
            _eventUI.SetValue(_clientDuration.ToPercent(ClientDuration));
        }

        private void BookTable()
        {
            // todo : book an order (observer)
        }

    }
}
