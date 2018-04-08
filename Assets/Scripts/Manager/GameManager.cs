using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Environment;
using Assets.Scripts.IA;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static AssetsManager AssetsManager;

        private int _maxFamilySize = 1;
        private const int MinClientSpawn = 100, MaxClientSpawn = 100;
        private List<GameObject> _spawnTableGameObjects;

        private const int FoodSpawnTimer = 100;
        private int _currentFoodSpawnTimer = 0;

        private int _clientSpawnTimer;
        private int _currentClientSpawnTimer = 0;

        // Use this for initialization
        void Start()
        {
            RandommizeClientSpawnTimer();
            AssetsManager = GetComponent<AssetsManager>();
            _spawnTableGameObjects = GameObject.FindGameObjectsWithTag("SpawnTable").ToList();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // ********** FOOD SPAWN
            if (_currentFoodSpawnTimer < FoodSpawnTimer)
            {
                _currentFoodSpawnTimer++;
            }
            else
            {
                _currentFoodSpawnTimer = 0;
                SpawnInteractive(AssetsManager.Interactives[Mathf.CeilToInt(Random.Range(0, AssetsManager.Interactives.Length))]);
            }

            // ********** CLIENT SPAWN
            if (_currentClientSpawnTimer < _clientSpawnTimer)
            {
                _currentClientSpawnTimer++;
            }
            else
            {
                _currentClientSpawnTimer = 0;
                RandommizeClientSpawnTimer();
                SpawnClients(PickClientFamily());
            }
        }

        void SpawnInteractive(GameObject interactiveGameObjectameObject)
        {
            _spawnTableGameObjects.Shuffle();
            var i = 0;
            GameObject parentObject = null;
            while (i < _spawnTableGameObjects.Count - 1 && parentObject == null)
            {
                //TODO: Condition to change
                if (_spawnTableGameObjects[i].transform.childCount < 1)
                    parentObject = _spawnTableGameObjects[i];

                i++;
            }

            if (parentObject != null)
            {
                var childObject = Instantiate(interactiveGameObjectameObject);

                childObject.transform.parent = parentObject.transform;
                childObject.transform.localPosition = new Vector3(0, 0.5f, 0);
                childObject.transform.rotation = Quaternion.identity;
            }
        }

        Table PickTable()
        {
            AssetsManager.Tables.Shuffle();
            var i = 0;
            Table table = null;
            while (i < AssetsManager.Tables.Count - 1 && table == null)
            {
                if (!AssetsManager.Tables[i].IsUsed)
                    table = AssetsManager.Tables[i];

                i++;
            }

            return table;
        }

        void SpawnClients(List<GameObject> gameObjects)
        {

            var table = PickTable();
            if (table != null)
            {
                foreach (var clientGameObject in gameObjects)
                {
                    var seat = table.PickSeat();
                    if (seat != null)
                    {
                        Instantiate(clientGameObject);
                        clientGameObject.SetActive(false);
                        clientGameObject.GetComponent<ClientIA>().GetComponent<NavMeshAgent>().Warp(new Vector3(AssetsManager.ClientSpawner.transform.position.x, 1, AssetsManager.ClientSpawner.transform.position.z));

                        Debug.Log(seat.SeatGameObject.transform.position);
                        clientGameObject.GetComponent<ClientIA>().MoveTo(seat.SeatGameObject.transform.position);

                        clientGameObject.SetActive(true);
                    }
                }
            }
        }

        void RandommizeClientSpawnTimer()
        {
            _clientSpawnTimer = Random.Range(MinClientSpawn, MaxClientSpawn);
        }

        List<GameObject> PickClientFamily()
        {
            int familySize = Random.Range(1, _maxFamilySize);
            var family = new List<GameObject>();
            for (var i = 0; i < familySize; i++)
            {
                family.Add(AssetsManager.Clients[Mathf.CeilToInt(Random.Range(0, AssetsManager.Clients.Length))]);
            }

            return family;
        }
    }
}
