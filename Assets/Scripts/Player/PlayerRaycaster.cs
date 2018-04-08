using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerRaycaster : MonoBehaviour
    {
        public float RayDistance = 1.5f;

        private PlayerInteraction _playerInteraction;

        private void Start()
        {
            _playerInteraction = GetComponent<PlayerInteraction>();
        }

        private void FixedUpdate()
        {
            var characterController = GetComponent<CharacterController>();
            var p1 = transform.position + characterController.center + Vector3.up * -characterController.height * 0.5F;
            var p2 = p1 + Vector3.up * characterController.height;

            var hits = Physics.CapsuleCastAll(p1, p2,
                characterController.radius,
                transform.forward,
                RayDistance);

            if (hits.Length > 0)
            {
                var gamesObjects = hits.Select(x => x.collider.gameObject);
                var colliderGameObjects = gamesObjects as IList<GameObject> ?? gamesObjects.ToList();

                var closestGameObject = ClosestGameObject(colliderGameObjects, new[] { "Catchable", "Usable" });
                _playerInteraction.ColliderGameObject = closestGameObject;

                var colliderTableGameObject = ClosestGameObject(colliderGameObjects, new[] { "Table" });
                _playerInteraction.ColliderTableGameObject = colliderTableGameObject;

                var colliderTrashGameObject = ClosestGameObject(colliderGameObjects, new[] { "Trash" });
                _playerInteraction.ColliderTrashGameObject = colliderTrashGameObject;
            }
            else
            {
                _playerInteraction.Hit(null);
            }

        }

        private GameObject ClosestGameObject(IEnumerable<GameObject> colliderGameObjects, string[] objectTag)
        {
            var minDist = float.MaxValue;
            GameObject closestTableGameObject = null;
            foreach (var tableGameObject
                in colliderGameObjects)
            {
                if (objectTag.Contains(tableGameObject.tag))
                {
                    var dist = (tableGameObject.transform.position - transform.position).magnitude;
                    if (minDist > dist)
                    {
                        minDist = dist;
                        closestTableGameObject = tableGameObject;
                    }
                }
            }
            return closestTableGameObject;

        }

    }
}
