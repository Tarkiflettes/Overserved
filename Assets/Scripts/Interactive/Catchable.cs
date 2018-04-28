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

        public GameObject Catch(Transform catcher)
        {
            transform.parent = catcher.transform;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            var position = catcher.transform.forward + catcher.transform.position;
            transform.rotation = new Quaternion();
            transform.position = position;
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
