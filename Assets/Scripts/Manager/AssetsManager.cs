using System.Collections.Generic;
using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class AssetsManager : MonoBehaviour
    {

        public GameObject Icon;
        public GameObject ProgressBar;

        public GameObject[] Interactives;
        public GameObject[] Clients;
        public GameObject ClientSpawner;
        public List<Table> Tables;

        private void Start()
        {
            Tables = new List<Table>();
            var tablesGameObjects = GameObject.FindGameObjectsWithTag("Table");
            foreach (var tablesGameObject in tablesGameObjects)
            {
                Tables.Add(new Table(tablesGameObject));
            }
        }

    }
}
