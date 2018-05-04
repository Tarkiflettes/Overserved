﻿using Assets.Scripts.Interactive;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public bool HasObject
        {
            get { return _takenObject != null; }
        }

        public GameObject ObjectPosition;

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
                    Debug.Log("Catch " + ColliderCatchable);
                    var catchable = ColliderCatchable.GetComponent<Catchable>();
                    if (catchable != null)
                        Catch(catchable);
                }
                else if (HasObject)
                {
                    Debug.Log("Drop " + _takenObject);
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

            if (Input.GetButtonUp(_joystick.Use))
            {
                if (ColliderUsable != null &&
                    HasObject == false)
                {
                    FinishInteraction(ColliderUsable);
                }
                else if (HasObject)
                {
                    FinishInteraction(_takenObject);
                }
            }
        }

        private void Interact(GameObject obj)
        {
            var usable = obj.GetComponent<Interactive.Interactive>();
            if (usable == null)
                return;
            usable.Interact();
            usable.IsInteracting = true;
        }

        private void FinishInteraction(GameObject obj)
        {
            Debug.Log("Finish Interact");
            var usable = obj.GetComponent<Interactive.Interactive>();
            if (usable == null)
                return;
            usable.IsInteracting = false;
        }

        private void Interact(GameObject obj, GameObject obj2)
        {
            var usable = obj.GetComponent<Interactive.Interactive>();
            if (usable == null)
                return;
            usable.Interact(obj2);
        }

        private void Catch(Catchable catchable)
        {
            var newPosition = new Vector3();
            var catchableCollider = catchable.GetComponent<BoxCollider>();
            if (catchableCollider != null)
            {
                newPosition.y = catchableCollider.size.y / 2;
                newPosition.z = catchableCollider.size.z / 2;
            }

            _takenObject = catchable.GetComponent<Catchable>().Catch(
                ObjectPosition,
                newPosition,
                new Quaternion());
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
