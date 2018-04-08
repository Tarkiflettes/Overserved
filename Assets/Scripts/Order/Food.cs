using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {

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
        switch (name)
        {
            case FoodName.Hamburger: return "Hamburger"; break;
            case FoodName.Salad: return "Salad"; break;
            default: return ""; break;
        }
    }
}
