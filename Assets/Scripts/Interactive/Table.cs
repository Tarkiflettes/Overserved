using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Table : Usable
    {

        public int NumberOfSeat;

        private bool _objectOnTable;
        private GameObject[] _objectsOnTable;

        private void Start()
        {
            SetUI();
            _objectsOnTable = new GameObject[NumberOfSeat];
            _objectOnTable = false;
        }

        public override void Interact()
        {
        }

        public override void Interact(GameObject obj)
        {
            foreach (var tableChild in transform.GetComponentsInChildren<Transform>())
            {
                if (tableChild.tag.Equals("Catchable"))
                {
                    _objectOnTable = true;
                    break;
                }
            }

            if (!_objectOnTable)
            {
                var tableCollider = GetComponent<BoxCollider>();
                obj.transform.parent = transform;

                obj.transform.localPosition = new Vector3(tableCollider.center.x,
                    tableCollider.size.y + (1 - tableCollider.center.y) * 2 -
                    obj.GetComponent<BoxCollider>().center.y, tableCollider.center.z);

                obj.transform.rotation = Quaternion.identity;
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }

    }
}
