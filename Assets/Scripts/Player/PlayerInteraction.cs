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
        public GameObject ColliderCatchable;
        [HideInInspector]
        public GameObject ColliderUsable;

        private GameObject _takenObject;
        private Joystick _joystick;
        private PlayerController _playerController;

        private void Start()
        {
            ColliderCatchable = null;
            ColliderUsable = null;
            _takenObject = null;
        }

        private void FixedUpdate()
        {
            if (_joystick == null)
            {
                _playerController = GetComponent<PlayerController>();
                _joystick = _playerController.Joystick;
                return;
            }

            if (Input.GetButtonDown(_joystick.Action))
            {
                if (ColliderCatchable != null &&
                    HasObject == false)
                {
                    Debug.Log("Catch");
                    Catch(ColliderCatchable);
                }
                else if (HasObject)
                {
                    Debug.Log("Drop");
                    Drop();
                }
            }

            if (Input.GetButtonDown(_joystick.Use))
            {
                if (ColliderUsable != null &&
                    HasObject == false)
                {
                    Interact(ColliderUsable);
                }
                else if (HasObject)
                {
                    Interact(_takenObject);
                }
            }
        }

        private void Interact(GameObject obj)
        {
            var usable = obj.GetComponent<Interactive.Interactive>();
            usable.Interact();
        }

        private void Interact(GameObject obj, GameObject obj2)
        {
            var usable = obj.GetComponent<Interactive.Interactive>();
            usable.Interact(obj2);
        }

        private void Catch(GameObject obj)
        {
            _takenObject = obj.GetComponent<Catchable>().Catch(transform);
        }

        private void Drop()
        {
            _takenObject.GetComponent<Catchable>().Drop(transform);
            var tmpObj = _takenObject;
            _takenObject = null;

            if (ColliderUsable != null)
                Interact(ColliderUsable, tmpObj);
        }

    }
}
