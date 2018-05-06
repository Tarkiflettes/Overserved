using Assets.Scripts.IA;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Seat : MonoBehaviour
    {

        public bool HasClient
        {
            get { return Client != null; }
        }
        public bool HasPlate
        {
            get { return Plate != null; }
        }
        public Plate Plate
        {
            get { return PlatePosition.GetComponentInChildren<Plate>(); }
        }
        public Client Client
        {
            get { return CharacterPosition.GetComponentInChildren<Client>(); }
        }

        public GameObject PlatePosition;
        public GameObject CharacterPosition;
        
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

            Plate.CanBeCaught = false;

            Client.Eat(Plate);
                
            return true;
        }

        public bool Sit(Client character)
        {
            if (HasClient)
                return false;
            // todo : move client to seat
            return true;
        }

    }
}
