using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class BigPlate : Catchable
    {

        public GameObject[] FoodPosition;

        private Food.Food[] _food;

        protected override void Init()
        {
            base.Init();
            _food = new Food.Food[FoodPosition.Length];
        }

    }
}
