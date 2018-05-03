using System;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Catchable : Interactive
    {
        private GameObject _interactive;

        private void Start()
        {
            SetUI();
            _interactive = GameObject.Find("/Interactive");
        }

        public GameObject Catch(GameObject catcher, Vector3 position, Quaternion rotation)
        {
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
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.parent = _interactive.transform;
            GetComponent<Catchable>().EnableUi(true);
        }

        public override void Interact()
        {
            Debug.Log("Interact Catchable : " + name);
        }

        public override void Interact(GameObject obj)
        {
        }

    }
}
