using System.Collections;
using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Plate : Dish
    {

        public bool Finished
        {
            get { return Food == null || Food.Finished; }
        }
        public Food.Food Food
        {
            get { return FoodPosition.GetComponentInChildren<Food.Food>(); }
        }
        public GameObject StackedPlatePosition;
        public GameObject FoodPosition;

        protected override void Init()
        {
            base.Init();
            var stackedPlate = StackedPlatePosition.GetComponentInChildren<Plate>();
            if (stackedPlate != null)
                Stack(stackedPlate);
        }

        public override void Interact(GameObject obj)
        {
            base.Interact(obj);

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

        public override void AddFood(Food.Food food)
        {
            if (Food != null)
                return;
            var newPosition = new Vector3();
            var catchableCollider = food.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            food.Catch(FoodPosition, newPosition, new Quaternion());
        }

        public override IEnumerator Consume()
        {
            if (Finished)
                yield break;
            yield return Food.Consume();
        }

    }
}
