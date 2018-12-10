using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficlight : MonoBehaviour {

    public GameObject redlight, redlight2, yellowlight, yellowlight2, greenlight, greenlight2;

    public float starttime = 2;
	// Use this for initialization
	void Start () {
        redlight.SetActive(true);
        redlight2.SetActive(true);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        StartCoroutine(startLight());
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void StartCycling(){
        redlight.SetActive(true);
        redlight2.SetActive(true);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        StartCoroutine(startyellowLight());
    }

    IEnumerator startLight(){
        yield return new WaitForSeconds(starttime);
        redlight.SetActive(true);
        redlight2.SetActive(true);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        StartCoroutine(startyellowLight());
    }
    IEnumerator startyellowLight(){
        yield return new WaitForSeconds(4);
        redlight.SetActive(false);
        redlight2.SetActive(false);
        yellowlight.SetActive(true);
        yellowlight2.SetActive(true);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        StartCoroutine(greenlightshow());

    }
    IEnumerator greenlightshow(){
        yield return new WaitForSeconds(2);
        redlight.SetActive(false);
        redlight2.SetActive(false);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(true);
        greenlight2.SetActive(true);
        StartCoroutine(turningbacktoRed());


    }
    IEnumerator turningbacktoRed(){
        yield return new WaitForSeconds(4);
        redlight.SetActive(false);
        redlight2.SetActive(false);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(true);
        greenlight2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        greenlight.SetActive(true);
        greenlight2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        greenlight.SetActive(true);
        greenlight2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
        initalize();
        StartCycling();
       // StartCoroutine(startLight());

    }
    void initalize(){
        redlight.SetActive(false);
        redlight2.SetActive(false);
        yellowlight.SetActive(false);
        yellowlight2.SetActive(false);
        greenlight.SetActive(false);
        greenlight2.SetActive(false);
    }
}
