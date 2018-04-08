using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class order : MonoBehaviour {

    private List<Food> orderedFood;
    private int maxTime;

    //constructor
    public order()
    {

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Méthodes
    void addFood(Food food) {
        orderedFood.Add(food);
    }

    void generateRandomFood(int nbr)
    {
        for(int i=0; i<nbr; i++)
        {
            int nbrOfDifferentFood = Food.FoodName.GetNames(typeof(Food.FoodName)).Length;
            Debug.Log(nbrOfDifferentFood);
            //addFood((Food)Random.Range(0, 2));
        }
    }
    
}


