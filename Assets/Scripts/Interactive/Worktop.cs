using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Worktop : Usable
    {

        public GameObject ObjectPosition;

        public override void Interact()
        {
        }

        public override void Interact(GameObject obj)
        {
            var catchable = obj.GetComponent<Catchable>();
            if (catchable != null)
                PutOnWorktop(catchable);
        }

        public void PutOnWorktop(Catchable catchable)
        {
            var newPosition = new Vector3();
            var catchableCollider = catchable.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            catchable.Catch(ObjectPosition, newPosition, new Quaternion());

            //// Set parent
            //catchable.transform.parent = ObjectPosition;
            //// set constraints
            //catchable.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //// set rotation
            //catchable.transform.rotation = new Quaternion();
            //// set position
            //var catchableCollider = catchable.GetComponent<BoxCollider>();
            //var newPosition = new Vector3 { y = catchableCollider.size.y / 2 };
            //catchable.transform.localPosition = newPosition;
            //// set ui
            //catchable.EnableUi(false);
        }

    }
}
