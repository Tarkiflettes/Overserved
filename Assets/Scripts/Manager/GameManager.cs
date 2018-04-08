using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        private List<GameObject> _spawnTableGameObjects;

        private const int SpawnTimer = 100;
        private int _currentSpawnTimer = 0;

        public static AssetsManager AssetsManager { get; private set; }

        // Use this for initialization
        void Start ()
        {
            AssetsManager = GetComponent<AssetsManager>();
            _spawnTableGameObjects = GameObject.FindGameObjectsWithTag("SpawnTable").ToList();
        }
	
        // Update is called once per frame
        void FixedUpdate ()
        {
            if (_currentSpawnTimer < SpawnTimer)
            {
                _currentSpawnTimer++;
            }
            else
            {
                _currentSpawnTimer = 0;
                SpawnInteractive(AssetsManager.Interactives[Mathf.CeilToInt(Random.Range(0, AssetsManager.Interactives.Length))]);
            }
        }

        void SpawnInteractive(GameObject gameObject)
        {
            _spawnTableGameObjects.Shuffle();
            var i = 0;
            GameObject parentObject = null;
            while (i < _spawnTableGameObjects.Count - 1 && parentObject == null)
            {
                if(_spawnTableGameObjects[i].transform.childCount < 1)
                    parentObject = _spawnTableGameObjects[i];

                i++;
            }

            if (parentObject != null) 
            {
                var childObject = Instantiate(gameObject);

                childObject.transform.parent = parentObject.transform;
                childObject.transform.localPosition = new Vector3(0, 0.5f, 0);
                childObject.transform.rotation = Quaternion.identity;
            }
        }


    }
}
