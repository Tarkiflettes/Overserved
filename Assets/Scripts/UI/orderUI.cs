using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Order order = new Order();
        order.generateRandomFood(5);
        Debug.Log(order.toString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
