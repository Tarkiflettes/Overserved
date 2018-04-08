﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int _maxFamilySize = 1;
    private const int MinClientSpawn = 100, MaxClientSpawn = 100;
    private List<GameObject> _spawnTableGameObjects;

    private const int FoodSpawnTimer = 100;
    private int _currentFoodSpawnTimer = 0;

    private int _clientSpawnTimer;
    private int _currentClientSpawnTimer = 0;

    public static AssetsManager AssetsManager { get; private set; }

    // Use this for initialization
    void Start() {
        RandommizeClientSpawnTimer();
        AssetsManager = GetComponent<AssetsManager>();
        _spawnTableGameObjects = GameObject.FindGameObjectsWithTag("SpawnTable").ToList();
    }

    // Update is called once per frame
    void FixedUpdate() {
        // ********** FOOD SPAWN
        if (_currentFoodSpawnTimer < FoodSpawnTimer) {
            _currentFoodSpawnTimer++;
        } else {
            _currentFoodSpawnTimer = 0;
            SpawnInteractive(AssetsManager.Interactives[Mathf.CeilToInt(Random.Range(0, AssetsManager.Interactives.Length))]);
        }

        // ********** CLIENT SPAWN
        if (_currentClientSpawnTimer < _clientSpawnTimer) {
            //_currentClientSpawnTimer++;
        } else {
            _currentClientSpawnTimer = 0;
            RandommizeClientSpawnTimer();
            SpawnClients(PickClientFamily());
        }
    }

    void SpawnInteractive(GameObject interactiveGameObjectameObject) {
        _spawnTableGameObjects.Shuffle();
        int i = 0;
        GameObject parentObject = null;
        while (i < _spawnTableGameObjects.Count - 1 && parentObject == null) {
            //TODO: Condition to change
            if (_spawnTableGameObjects[i].transform.childCount < 1)
                parentObject = _spawnTableGameObjects[i];

            i++;
        }

        if (parentObject != null) {
            GameObject childObject = Instantiate(interactiveGameObjectameObject) as GameObject;

            childObject.transform.parent = parentObject.transform;
            childObject.transform.localPosition = new Vector3(0, 0.5f, 0);
            childObject.transform.rotation = Quaternion.identity;
        }
    }

    Table PickTable() {
        AssetsManager.Tables.Shuffle();
        int i = 0;
        Table table = null;
        while (i < AssetsManager.Tables.Count - 1 && table == null) {
            if (!AssetsManager.Tables[i].IsUsed)
                table = AssetsManager.Tables[i];

            i++;
        }

        return table;
    }

    void SpawnClients(List<GameObject> gameObjects) {

        var table = PickTable();
        if (table != null) {
            foreach (var clientGameObject in gameObjects) {
                var seat = table.PickSeat();
                if (seat != null) {
                    GameObject instanceGameObject = Instantiate(clientGameObject);
                    instanceGameObject.transform.position = new Vector3(AssetsManager.ClientSpawner.transform.position.x, 1, AssetsManager.ClientSpawner.transform.position.z);

                    clientGameObject.GetComponent<ClientIA>().Destination = seat.SeatGameObject.transform.position;
                }
            }
        }
    }


    void RandommizeClientSpawnTimer() {
        _clientSpawnTimer = Random.Range(MinClientSpawn, MaxClientSpawn);
    }

    List<GameObject> PickClientFamily() {
        int familySize = Random.Range(1, _maxFamilySize);
        List<GameObject> family = new List<GameObject>();
        for (int i = 0; i < familySize; i++) {
            family.Add(AssetsManager.Clients[Mathf.CeilToInt(Random.Range(0, AssetsManager.Clients.Length))]);
        }

        return family;
    }
}
