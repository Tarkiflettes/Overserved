using System;
using System.Collections;
using System.Collections.Generic;
﻿using Assets.Scripts.Interactive;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerRaycaster : MonoBehaviour {
        public float RayDistance = 1.5f;

        public bool HasObject {
            get { return _takenObject != null; }
        }

        private GameObject _takenObject;
        private GameObject _interactive;

        private PlayerController _playerController;
        private Joystick _joystick;

        private void Start() {
            _takenObject = null;
            _interactive = GameObject.Find("/Interactive");
        }

        private void FixedUpdate() {
            if (_joystick == null) {
                _playerController = GetComponent<PlayerController>();
                _joystick = _playerController.Joystick;
            }

            var colliderGameObjects = new List<GameObject>();

            var charContr = GetComponent<CharacterController>();
            var p1 = transform.position + charContr.center + Vector3.up * -charContr.height * 0.5F;
            var p2 = p1 + Vector3.up * charContr.height;

            RaycastHit[] hits = Physics.CapsuleCastAll(p1, p2,
                charContr.radius,
                transform.forward,
                RayDistance);

            if (hits.Length > 0) {
                foreach (var hit in hits) {
                    colliderGameObjects.Add(hit.collider.gameObject);
                }
            }

            if (Input.GetButtonDown(_joystick.Action)) {
                if (_takenObject != null) {
                    Drop(colliderGameObjects);
                } else if (colliderGameObjects.Count > 0) {
                    var closestTableGameObject = ClosestGameObject(colliderGameObjects, "Catchable");
                    if (closestTableGameObject != null) {
                        Catch(closestTableGameObject);
                    }
                }
            }
        }

        private void Drop(List<GameObject> colliderGameObjects) {
            var closestGameObject = ClosestGameObject(colliderGameObjects, "Table");

            if (closestGameObject != null) {
                var objectOnTable = false;
                foreach (var tableChild in closestGameObject.transform.GetComponentsInChildren<Transform>()) {
                    if (tableChild.tag.Equals("Catchable")) {
                        objectOnTable = true;
                        break;
                    }
                }

                if (!objectOnTable) {
                    var tableCollider = closestGameObject.GetComponent<BoxCollider>();
                    _takenObject.transform.parent = closestGameObject.transform;
                    _takenObject.transform.localPosition = new Vector3(tableCollider.center.x, tableCollider.size.y + (1 - tableCollider.center.y) * 2 - _takenObject.GetComponent<BoxCollider>().center.y, tableCollider.center.z);
                    _takenObject.transform.rotation = Quaternion.identity;
                    _takenObject.GetComponent<Catchable>().EnableUi(true);
                    _takenObject = null;
                }
            } else if ((closestGameObject = ClosestGameObject(colliderGameObjects, "Trash")) != null) {
                Destroy(_takenObject);
                _takenObject = null;
            } else {
                _takenObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                _takenObject.transform.parent = _interactive.transform;
                _takenObject.GetComponent<Catchable>().EnableUi(true);
                _takenObject = null;
            }
        }

        private GameObject ClosestGameObject(List<GameObject> colliderGameObjects, String objectTag) {
            var minDist = float.MaxValue;
            GameObject closestTableGameObject = null;
            foreach (var tableGameObject
                in colliderGameObjects) {
                if (tableGameObject.tag == objectTag) {
                    var dist = (tableGameObject.transform.position - transform.position).magnitude;
                    if (minDist > dist) {
                        minDist = dist;
                        closestTableGameObject = tableGameObject;
                    }
                }
            }

            return closestTableGameObject;

        }

        private void Catch(GameObject obj) {
            obj.transform.parent = this.transform;
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            var position = transform.forward + transform.position;
            obj.transform.rotation = new Quaternion();
            obj.transform.position = position;
            _takenObject = obj;
            _takenObject.GetComponent<Catchable>().EnableUi(false);
        }
    }
}
