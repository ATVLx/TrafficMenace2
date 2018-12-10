using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracast : MonoBehaviour {

    public Camera cam;
    public GameObject marker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r,out hit))
            {
                Instantiate(marker, hit.point,Quaternion.identity);
            }
        }
		
	}
}
