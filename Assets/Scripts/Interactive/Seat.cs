using Assets.Scripts.IA;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Seat : MonoBehaviour
    {

        public bool HasClient
        {
            get { return _client != null; }
        }
        public bool HasPlate
        {
            get { return _plate != null; }
        }

        public GameObject PlatePosition;
        public GameObject CharacterPosition;

        private Client _client;
        private Plate _plate;

        private void Start()
        {
            _client = CharacterPosition.GetComponentInChildren<Client>();
            _plate = CharacterPosition.GetComponentInChildren<Plate>();
        }

        public bool Serve(Plate plate)
        {
            if (!HasClient)
                return false;
            if (HasPlate)
                return false;

            var newPosition = new Vector3();
            var catchableCollider = plate.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            var takenObject = plate.Catch(PlatePosition, newPosition, new Quaternion());
            if (takenObject == null)
                return false;

            _plate = takenObject.GetComponent<Plate>();

            if (_plate == null)
                return false;

            _plate.CanBeCaught = false;

            _client.StartEating(_plate);
                
            return true;
        }

        public bool Sit(Client character)
        {
            if (HasClient)
                return false;
            _client = character;
            return true;
        }

    }
}
