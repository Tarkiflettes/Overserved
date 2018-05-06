using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interactive.Abstract
{
    public abstract class Dish : Catchable
    {

        public virtual bool Finished { get; set; }

        public override void Interact(GameObject obj)
        {
            var food = obj.GetComponent<Food.Food>();
            if (food != null)
                AddFood(food);
        }

        public abstract void AddFood(Food.Food food);
        public abstract IEnumerator Consume();

    }
}
