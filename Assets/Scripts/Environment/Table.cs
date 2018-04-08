using System.Collections.Generic;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class Table
    {

        public List<Seat> Seats;
        public bool IsUsed;

        private readonly GameObject _tableGameObject;

        public Table(GameObject tableGameObject)
        {
            _tableGameObject = tableGameObject;
            Seats = new List<Seat>();

            foreach (var child in _tableGameObject.GetComponentsInChildren<Transform>())
            {
                if (child.tag.Equals("Seat"))
                {
                    Seats.Add(new Seat(child.gameObject));
                }
            }

        }

        public Seat PickSeat()
        {
            Seats.Shuffle();
            var i = 0;
            Seat seat = null;
            while (i < Seats.Count - 1 && seat == null)
            {
                if (!Seats[i].IsUsed)
                    seat = Seats[i];
                i++;
            }

            return seat;
        }

    }
}
