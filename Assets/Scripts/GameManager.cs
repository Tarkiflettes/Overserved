using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> _spawnTableGameObjects;
    private AssetsManager _assetsManager;

    private const int SpawnTimer = 100;
    private int _currentSpawnTimer = 0;

	// Use this for initialization
	void Start ()
	{
	    _assetsManager = GetComponent<AssetsManager>();
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
            SpawnInteractive(_assetsManager.Interactives[Mathf.CeilToInt(Random.Range(0, _assetsManager.Interactives.Length))]);
	    }
	}

    void SpawnInteractive(GameObject gameObject)
    {
        _spawnTableGameObjects.Shuffle();
        int i = 0;
        GameObject parentObject = null;
        while (i < _spawnTableGameObjects.Count - 1 && parentObject == null)
        {
            if(_spawnTableGameObjects[i].transform.childCount < 1)
                parentObject = _spawnTableGameObjects[i];

            i++;
        }

        if (parentObject != null) 
        {
            GameObject childObject = Instantiate(gameObject) as GameObject;

            childObject.transform.parent = parentObject.transform;
            childObject.transform.localPosition = new Vector3(0, 0.5f, 0);
            childObject.transform.rotation = Quaternion.identity;
        }
    }
}
