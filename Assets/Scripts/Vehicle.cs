using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
    public bool isrunning = true;
    public bool OnXdir = false;// if true then move positive if false then move negative
    public GameObject signboard;
    public Transform reference;
    public GameObject taillight1;
    public GameObject taillight2;
    public GameObject cardir;
    public AudioSource crash;
    public AudioSource Horn;
    bool hornPlayd=false;
    bool menaceMode = false;
    public int car;
    bool called;

    // Use this for initialization
    void Start () {
        isrunning = true;
        if (transform.position.x < reference.transform.position.x)
        {
            OnXdir = true;
           
        }
        if (transform.position.x > reference.transform.position.x)
        {
            OnXdir = false;
            cardir.transform.Rotate(0, 180, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (car >= 3)
        {
            if (!called)
            {
                called = true;
                FindObjectOfType<GameManager>().OnGameOver();
            }
        }

        if (isrunning)
        {
            signboard.SetActive(false);
            taillight1.SetActive(false);
            taillight2.SetActive(false);
            StopCoroutine(CarHOrnPlay());
            StopCoroutine(CarHOrnPlay());
            Horn.Stop();
        }
        else
            signboard.SetActive(true);
        taillight1.SetActive(true);
        taillight2.SetActive(true);
        StartCoroutine(CarHOrnPlay());

    }

    IEnumerator CarHOrnPlay(){
        yield return new WaitForSeconds(Random.Range(1, 3));
        if (!hornPlayd)
        {
            Horn.Play();
            hornPlayd = true;
            StartCoroutine(Reset());
        }
        else yield return null;

    }
    IEnumerator Reset(){
        yield return new WaitForSecondsRealtime(2);
        hornPlayd = false;
        StopCoroutine(CarHOrnPlay());
    }
    private void FixedUpdate()
    {

        if (isrunning && OnXdir)
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
           // signboard.SetActive(false);
        }
        if (isrunning && !OnXdir)
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
           // signboard.SetActive(false);
        }
        else {// signboard.SetActive(true); 
        }
    }
   public void UPDATEStatus(){
        if (isrunning==true){
            isrunning = false;
        }else
            if(isrunning==false){
            isrunning = true;
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ctrl"){
            Debug.Log("trigger called");
            UPDATEStatus();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "car"){
            crash.Play();
            Horn.Play();
            car += 1;
            // FindObjectOfType<GameManager>().OnGameOver();
        }
    }
}
