using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class BigPlate : Dish
    {

        public override bool Finished
        {
            get { return GetFoods().All(food => food == null || food.Finished); }
        }
        public GameObject[] FoodPositions;

        private HashSet<Food.Food> _consumed; // consumed and in progress

        protected override void Init()
        {
            base.Init();
            _consumed = new HashSet<Food.Food>();
        }

        public override void AddFood(Food.Food food)
        {
            var foodPosition = GetFreePosition();
            if (foodPosition == null)
                return;

            var newPosition = new Vector3();
            var catchableCollider = food.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            food.Catch(foodPosition, newPosition, new Quaternion());

            food.CanBeCaught = false;
        }

        public override IEnumerator Consume()
        {
            var food = GetNotFinishedFood();
            if (food == null)
                yield break;
            _consumed.Add(food);
            yield return food.Consume();
        }

        public Food.Food GetNotFinishedFood()
        {
            return GetFoods().FirstOrDefault(food => food != null && !food.Finished && !_consumed.Contains(food));
        }

        public IEnumerable<Food.Food> GetFoods()
        {
            return FoodPositions.Select(foodPosition => foodPosition.GetComponentInChildren<Food.Food>());
        }

        public GameObject GetFreePosition()
        {
            return FoodPositions.FirstOrDefault(pos => pos.GetComponentInChildren<Food.Food>() == null);
        }

    }
}
