using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Order
{
    public class Order
    {
        private List<Food> _orderedFood = new List<Food>();
        private int _maxTime;

        void AddFoodWithName(Food.FoodName food)
        {
            var newFood = new Food(food);
            _orderedFood.Add(newFood);
        }

        public void GenerateRandomFood(int nbr)
        {
            for (var i = 0; i < nbr; i++)
            {
                var nbrOfDifferentFood = Enum.GetNames(typeof(Food.FoodName)).Length;
                var choice = (Food.FoodName)Random.Range(0, nbrOfDifferentFood);
                AddFoodWithName(choice);
            }
        }

        public string toString()
        {
            var aff = "";
            foreach (var food in _orderedFood)
            {
                aff += food.GetFoodName() + " ";
            }
            return aff;
        }

        public List<Food> GetOrderedFood()
        {
            return _orderedFood;
        }
    }
}


