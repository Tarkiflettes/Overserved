using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Worktop : Usable
    {

        public bool HasObject
        {
            get { return GetObject != null; }
        }

        public Catchable GetObject
        {
            get { return ObjectPosition.GetComponentInChildren<Catchable>(); }
        }

        public GameObject ObjectPosition;

        public override void Interact()
        {
            if (HasObject)
                GetObject.Interact();
        }
        
        public override void Interact(GameObject obj)
        {
            var catchable = obj.GetComponent<Catchable>();
            if (catchable != null)
                PutOnWorktop(catchable);
        }

        public void PutOnWorktop(Catchable catchable)
        {
            if (HasObject)
            {
                GetObject.Interact(catchable.gameObject);
                return;
            }

            var newPosition = new Vector3();
            var catchableCollider = catchable.GetComponent<BoxCollider>();
            if (catchableCollider != null)
                newPosition.y = catchableCollider.size.y / 2;

            catchable.Catch(ObjectPosition, newPosition, new Quaternion());
        }

    }
}
