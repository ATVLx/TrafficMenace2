using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationofdir : MonoBehaviour {

    Quaternion value = new Quaternion(0, 180, 0, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeDir(){
        transform.rotation = value;
    }
}
