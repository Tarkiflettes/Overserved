using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }
}
