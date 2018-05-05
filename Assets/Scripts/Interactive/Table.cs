using System.Linq;
using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Table : Usable
    {

        public bool HasBigPlate
        {
            get { return BigPlatePosition.GetComponentInChildren<BigPlate>() != null; }
        }
        public Seat[] Seats;
        public GameObject BigPlatePosition;
        public GameObject FinishedPlatePosition;

        public override void Interact()
        {
            TakeOrder();
        }

        public override void Interact(GameObject obj)
        {
            var plate = obj.GetComponent<Plate>();
            if (plate != null)
                Serve(plate);

            var bigPlate = obj.GetComponent<BigPlate>();
            if (bigPlate != null)
                ServeBigPlate(bigPlate);
        }

        private void Serve(Plate plate)
        {
            if (HasBigPlate)
                return;

            var seatToServe = FindSeatWithoutPlate();
            if (seatToServe == null)
                return;

            seatToServe.Serve(plate);
        }

        private void ServeBigPlate(BigPlate bigPlate)
        {
            if (HasBigPlate)
                return;

            var newPosition = new Vector3();
            var catchableCollider = bigPlate.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;
            bigPlate.Catch(BigPlatePosition, newPosition, new Quaternion());
        }

        public void AddPlateToFinishPosition(Dish dish)
        {
            var plate = dish.GetComponent<Plate>();
            if (plate == null)
            {
                dish.CanBeCaught = true;
                return;
            }

            var plateInFinisgPosition = FinishedPlatePosition.GetComponentInChildren<Plate>();
            
            if (plateInFinisgPosition != null)
            {
                plateInFinisgPosition.Stack(plate);
            }
            else
            {
                plate.CanBeCaught = true;
                var newPosition = new Vector3();
                var catchableCollider = plate.GetComponent<BoxCollider>();
                if (catchableCollider != null)
                    newPosition.y = catchableCollider.size.y / 2;
                plate.Catch(FinishedPlatePosition, newPosition, new Quaternion());
            }
        }

        private void TakeOrder()
        {
            Debug.Log("Take an order");
        }

        private Seat FindUnoccupiedSeat()
        {
            return Seats.FirstOrDefault(seat => !seat.HasClient);
        }

        private Seat FindSeatWithoutPlate()
        {
            return Seats.FirstOrDefault(seat => seat.HasClient && !seat.HasPlate);
        }

    }
}
