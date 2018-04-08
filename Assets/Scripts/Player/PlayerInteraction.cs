using Assets.Scripts.Interactive;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public bool HasObject
        {
            get { return _takenObject != null; }
        }

        [HideInInspector]
        public GameObject ColliderGameObject;
        [HideInInspector]
        public GameObject ColliderTableGameObject;
        [HideInInspector]
        public GameObject ColliderTrashGameObject;

        private GameObject _takenObject;
        private GameObject _interactive;
        private Joystick _joystick;
        private PlayerController _playerController;


        void Start()
        {
            ColliderGameObject = null;
            ColliderTableGameObject = null;
            ColliderTrashGameObject = null;
            _takenObject = null;
            _interactive = GameObject.Find("/Interactive");
        }

        void FixedUpdate()
        {
            if (_joystick == null)
            {
                _playerController = GetComponent<PlayerController>();
                _joystick = _playerController.Joystick;
                return;
            }
            if (Input.GetButtonDown(_joystick.Action))
            {
                if (ColliderGameObject != null &&
                    ColliderGameObject.tag == "Catchable" &&
                    HasObject == false)
                {
                    Debug.Log("Catch");
                    Catch(ColliderGameObject);
                }
                else if (HasObject)
                {
                    Debug.Log("Drop");
                    Drop();
                }
            }

            if (Input.GetButtonDown(_joystick.Use))
            {
                if (ColliderGameObject != null &&
                    ColliderGameObject.tag == "Usable" &&
                    HasObject == false)
                {
                    Interact(ColliderGameObject);
                }
                else if (HasObject &&
                        _takenObject.tag == "Catchable")
                {
                    Interact(_takenObject);
                }
            }
        }

        public void Hit(GameObject colliderGameObject)
        {
            ColliderGameObject = colliderGameObject;
        }

        private void Interact(GameObject obj)
        {
            var usable = obj.GetComponent<Interactive.Interactive>();
            usable.Interact();
        }

        private void Catch(GameObject obj)
        {
            obj.transform.parent = transform;
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            var position = transform.forward + transform.position;
            obj.transform.rotation = new Quaternion();
            obj.transform.position = position;
            _takenObject = obj;
            _takenObject.GetComponent<Catchable>().EnableUi(false);
        }


        private void Drop()
        {
            if (ColliderTableGameObject != null)
            {
                var objectOnTable = false;
                foreach (var tableChild in ColliderTableGameObject.transform.GetComponentsInChildren<Transform>())
                {
                    if (tableChild.tag.Equals("Catchable"))
                    {
                        objectOnTable = true;
                        break;
                    }
                }

                if (!objectOnTable)
                {
                    var tableCollider = ColliderTableGameObject.GetComponent<BoxCollider>();
                    _takenObject.transform.parent = ColliderTableGameObject.transform;
                    _takenObject.transform.localPosition = new Vector3(tableCollider.center.x, tableCollider.size.y + (1 - tableCollider.center.y) * 2 - _takenObject.GetComponent<BoxCollider>().center.y, tableCollider.center.z);
                    _takenObject.transform.rotation = Quaternion.identity;
                    _takenObject.GetComponent<Catchable>().EnableUi(true);
                    _takenObject = null;
                }
            }
            else if (ColliderTrashGameObject != null)
            {
                Destroy(_takenObject);
                _takenObject = null;
            }
            else
            {
                _takenObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                _takenObject.transform.parent = _interactive.transform;
                _takenObject.GetComponent<Catchable>().EnableUi(true);
                _takenObject = null;
            }
        }

    }
}
