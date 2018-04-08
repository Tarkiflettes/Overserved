using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table
{

    private GameObject _tableGameObject;
    public List<Seat> Seats { get; private set; }
    public bool IsUsed { get; set; }

    public Table(GameObject tableGameObject) {
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
        int i = 0;
        Seat seat = null;
        while (i < Seats.Count - 1 && seat == null) {
            if (!Seats[i].IsUsed)
                seat = Seats[i];
            i++;
        }

        return seat;
    }

}
