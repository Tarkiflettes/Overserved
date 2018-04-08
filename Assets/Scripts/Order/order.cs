using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order {

    List<Food> orderedFood = new List<Food>();
    private int maxTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Méthodes
    void addFoodWithName(Food.FoodName food) {
        Food newFood = new Food(food);
        orderedFood.Add(newFood);
    }

    public void generateRandomFood(int nbr)
    {
        for(int i=0; i<nbr; i++)
        {
            int nbrOfDifferentFood = Food.FoodName.GetNames(typeof(Food.FoodName)).Length;
            Food.FoodName choice = (Food.FoodName)Random.Range(0, nbrOfDifferentFood);
            addFoodWithName(choice);
        }
    }

    //toString
    public string toString()
    {
        string aff = "";
        foreach (var food in orderedFood)
        {
            aff += food.getFoodName()+" ";
        }
        return aff;
    }
    
}


