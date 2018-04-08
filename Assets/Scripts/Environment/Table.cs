using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class Table
    {

        private GameObject _tableGameObject;
        private GameObject[] _seats;

        public Table(GameObject tableGameObject) {
            _tableGameObject = tableGameObject;
        }
    }
}
