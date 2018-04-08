using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{
    public GameObject[] Interactives;
    public GameObject[] Clients;
    public GameObject ClientSpawner;
    public List<Table> Tables;
    
    void Start() {
        Tables = new List<Table>();
        var tablesGameObjects = GameObject.FindGameObjectsWithTag("Table");
        foreach (var tablesGameObject in tablesGameObjects) {
            Tables.Add(new Table(tablesGameObject));
        }
    }
}
