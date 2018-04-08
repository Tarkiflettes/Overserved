using UnityEngine;
using System.Collections;

public class Seat
{
    public bool IsUsed { get; set; }

    public GameObject SeatGameObject { get; private set; }

    public Seat(GameObject seatGameObject)
    {
        IsUsed = false;
        SeatGameObject = seatGameObject;
    }

}
