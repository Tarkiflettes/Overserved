using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Order;
using UnityEngine;

public class OrderController : MonoBehaviour
{

    public List<Order> orderList = new List<Order>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Order> getOrderList()
    {
        return orderList;
    }
}
