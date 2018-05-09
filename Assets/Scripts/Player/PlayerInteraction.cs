using Assets.Scripts.Interactive.Abstract;
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
        public GameObject ColliderCatchable { get; set; }
        [HideInInspector]
        public GameObject ColliderUsable
        {
            get { return _colliderUsable; }
            set
            {
                FinishInteraction(_colliderUsable);
                _colliderUsable = value;
            }
        }

        private GameObject _takenObject;
        private Joystick _joystick;
        private PlayerController _playerController;

        private GameObject _colliderUsable;

        private void Start()
        {
            ColliderCatchable = null;
            ColliderUsable = null;
            _takenObject = null;
        }

        private void Update()
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
                    var catchable = ColliderCatchable.GetComponent<Catchable>();
                    if (catchable != null)
                        Catch(catchable);
                }
                else if (HasObject)
                {
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
                else if (ColliderUsable != null && HasObject)
                {
                    Interact(_takenObject, ColliderUsable);
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
            var usable = obj.GetComponent<Interactive.Abstract.Interactive>();
            if (usable == null)
                return;
            usable.Interact();
            usable.IsInteracting = true;
        }

        private void Interact(GameObject obj, GameObject obj2)
        {
            var usable = obj.GetComponent<Interactive.Abstract.Interactive>();
            if (usable == null)
                return;
            usable.Interact(obj2);
            usable.IsInteracting = true;
        }

        private void FinishInteraction(GameObject obj)
        {
            if (obj == null)
                return;
            var usable = obj.GetComponent<Interactive.Abstract.Interactive>();
            if (usable == null)
                return;
            usable.IsInteracting = false;
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
