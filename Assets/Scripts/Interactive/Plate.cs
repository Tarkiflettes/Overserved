using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Plate : Catchable
    {

        public bool Finished
        {
            get { return _food == null || _food.Finished; }
        }
        public GameObject StackedPlatePosition;
        public GameObject FoodPosition;

        private Food.Food _food;

        protected override void Init()
        {
            base.Init();
            _food = FoodPosition.GetComponentInChildren<Food.Food>();
            if (_food != null)
                AddFood(_food);
            var stackedPlate = StackedPlatePosition.GetComponentInChildren<Plate>();
            if (stackedPlate != null)
                Stack(stackedPlate);
        }

        public override void Interact(GameObject obj)
        {
            var food = obj.GetComponent<Food.Food>();
            if (food != null)
                AddFood(food);

            var plate = obj.GetComponent<Plate>();
            if (plate != null)
                Stack(plate);
        }

        public void Stack(Plate plate)
        {
            if (!Finished)
                return;

            plate.CanBeCaught = true;

            var newPosition = new Vector3();
            var catchableCollider = plate.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            plate.Catch(StackedPlatePosition, newPosition, new Quaternion());
        }

        public void AddFood(Food.Food food)
        {
            var newPosition = new Vector3();
            var catchableCollider = food.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            food.Catch(FoodPosition, newPosition, new Quaternion());
        }

        public IEnumerator Consume()
        {
            if (Finished)
                yield break;
            yield return _food.Consume();
        }

    }
}
