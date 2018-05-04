namespace Assets.Scripts.Interactive
{
    public class Phone : Usable
    {

        private bool _isOffTheHook
        {
            get { return _callDuration > 0; }
        }
        private bool _isRigging = false;
        private int _callDuration;
        private int _clientDuration;

        public Phone()
        {
            _callDuration = 0;
            _clientDuration = 0;
        }

        private void Update()
        {
            if (_isOffTheHook)
            {
                if (IsInteracting)
                    Talk();
                else
                    ClientIsWaiting();
            }
        }

        public override void Interact()
        {
            PickUp();
        }

        private void Talk()
        {
            _callDuration--;

            if (_callDuration == 0)
                HangUp();
        }

        private void ClientIsWaiting()
        {
            _clientDuration--;
            if (_clientDuration == 0)
                ClientHasHangedUp();
        }

        private void PickUp()
        {
            if (_isOffTheHook && !_isRigging)
                return;
            _isRigging = false;
            _callDuration = 100; // todo : random
            _clientDuration = 200; // todo : random
        }

        private void HangUp()
        {
            _clientDuration = 0;
            BookTable();
            _isRigging = false;
        }

        private void ClientHasHangedUp()
        {
            _callDuration = 0;
            // todo : lose points
        }

        public void Ring()
        {
            _isRigging = true;
        }

        private void BookTable()
        {
            // todo : book an order (observer)
        }

    }
}
