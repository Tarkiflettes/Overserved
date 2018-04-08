using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        launchAnimation();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void launchAnimation() {
        GetComponent<Animation>().Play();
    }
}
