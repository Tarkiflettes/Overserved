using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class Seat
    {
        public bool IsUsed;

        public GameObject SeatGameObject { get; private set; }

        public Seat(GameObject seatGameObject)
        {
            IsUsed = false;
            SeatGameObject = seatGameObject;
        }

    }
}
