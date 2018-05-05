using UnityEngine;

namespace Assets.Scripts.Interactive.Abstract
{
    public class Catchable : Interactive
    {
        public bool CanBeCaught = true;

        private GameObject _interactive;

        protected override void Init()
        {
            base.Init();
            _interactive = GameObject.Find("/Interactive");
        }

        public GameObject Catch(GameObject catcher, Vector3 position, Quaternion rotation)
        {
            if (!CanBeCaught)
                return null;

            // Set parent
            transform.parent = catcher.transform;
            // set constraints
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            // set rotation
            transform.localRotation = rotation;
            // set position
            transform.localPosition = position;
            // set ui
            GetComponent<Catchable>().EnableUi(false);

            return gameObject;
        }

        public void Drop(Transform dropper)
        {
            // Set parent
            transform.parent = _interactive.transform;
            // set constraints
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            // set ui
            GetComponent<Catchable>().EnableUi(true);
        }

        public override void Interact()
        {
            Debug.Log("Interact Catchable : " + name);
        }

        public override void Interact(GameObject obj)
        {
        }

        public override bool AcceptRaycast()
        {
            return CanBeCaught;
        }

    }
}
