using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambulance : MonoBehaviour {


    public GameObject whitelight;
    public GameObject redLight;
	// Use this for initialization
	void Start () {
        StartCoroutine(start());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator start(){
        yield return new WaitForSecondsRealtime(1);
        whitelight.SetActive(true);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(false);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(true);
        redLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(false);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(true);
        redLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(false);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        whitelight.SetActive(true);
        redLight.SetActive(false);
        StartCoroutine(start());
    }
}
