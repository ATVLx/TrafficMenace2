using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "car"){
            FindObjectOfType<GameManager>().Counter();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="car"){
            FindObjectOfType<GameManager>().Counter();
        }
    }
}
