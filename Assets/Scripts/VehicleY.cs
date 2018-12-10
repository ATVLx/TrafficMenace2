using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleY : MonoBehaviour {
    public bool isrunning = false;
    public bool OnZdir = false;// if true then move positive if false then move negative
    public GameObject signboard;
    public Transform reference;
    public GameObject taillight1;
    public GameObject taillight2;
    public GameObject cardir;
    public AudioSource Horn;
    bool menaceMode = false;
    public int car;
    bool called = false;


    // public Animator anim;

    // Use this for initialization
    void Start () {
        isrunning = true;
        if (transform.position.z < reference.transform.position.z)
        {
            //cardir.transform.eulerAngles = new Vector3(0, 180, 0);
            OnZdir = true;
            cardir.transform.Rotate(0, 180, 0);
        }
        if (transform.position.z > reference.transform.position.z)
        {
           
            OnZdir = false;
        }
        //GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isrunning)
        {
            signboard.SetActive(false);
            taillight1.SetActive(false);
            taillight2.SetActive(false);

           // anim.SetTrigger("animstate");
            
        }
        else
            signboard.SetActive(true);
            taillight1.SetActive(true);
            taillight2.SetActive(true);
       // StartCoroutine(CarHOrnPlay());
        // anim.SetTrigger("normalstate");
        if(car>=3){
            if (!called)
            {
                called=true;
                FindObjectOfType<GameManager>().OnGameOver();
            }
        }
    }
   
   

        private void FixedUpdate()
    {

        if (isrunning && OnZdir)
        {
            transform.Translate(0, 0, 5 * Time.deltaTime);
           // signboard.SetActive(false);
        }
        if (isrunning && !OnZdir)
        {
            transform.Translate(0, 0, -5 * Time.deltaTime);
           // signboard.SetActive(false);
        }
        else {// signboard.SetActive(true); 
        }
    }
    void UPDATEStatus(){
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
        if (collision.gameObject.tag == "car")
        {
            car += 1;
            Debug.Log(car);
            Horn.Play();
           // FindObjectOfType<GameManager>().OnGameOver();
        }
    }
}
