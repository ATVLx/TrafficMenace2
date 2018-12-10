using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {
    //this will destroy the game object after sspecific interval

	// Use this for initialization
	void Start () {
        StartCoroutine(deleteObject());
	}

    IEnumerator deleteObject(){
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(this.gameObject);
    }
	
}
