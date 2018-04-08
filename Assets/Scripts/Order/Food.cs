using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public enum FoodName {Hamburger,Salad};
    private FoodName name;

    public Food(FoodName food)
    {
        name = food;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string getFoodName()
    {
        //return (string)name;
    }
}
