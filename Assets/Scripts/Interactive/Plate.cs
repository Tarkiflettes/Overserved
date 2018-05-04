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
            var stackedPlate = StackedPlatePosition.GetComponentInChildren<Plate>();
            if (stackedPlate != null)
                Stack(stackedPlate);
        }

        public void Stack(Plate plate)
        {
            if (!Finished)
                return;

            plate.CanBeCaught = false;

            var newPosition = new Vector3();
            var catchableCollider = plate.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            plate.Catch(StackedPlatePosition, newPosition, new Quaternion());
        }

        public IEnumerator Consume()
        {
            if (Finished)
                yield break;
            yield return _food.Consume();
        }

    }
}
