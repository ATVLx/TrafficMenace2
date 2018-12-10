using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
   

    bool counting=true;
    public TextMeshProUGUI points;
    public int point;
    public GameObject Panel;
    public GameObject mute;
    public GameObject unmute;
    public GameObject pausebtn,gameovertxt,resumebtn,leaderboard,pubnubmgr;
    float backbtncount = 0;
    bool gameover=false;

    Admanager admanager;
	// Use this for initialization
	void Start () {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        pausebtn.SetActive(true);
        Time.timeScale = 1; // start at normal time mode
        backbtncount = 0f;
        Admanager.Instance.HideBanner();

	}


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update () {

        if(gameover){
            resumebtn.SetActive(false);
           // pausebtn2.SetActive(false);
        }

        if(Time.timeScale==0 && gameover){
           // pausebtn2.SetActive(true);
            pausebtn.SetActive(false);
        }
        else{
           // pausebtn2.SetActive(false);
            //pausebtn.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            backbtncount += 1;
            ONpause();
            StartCoroutine(resetter());
        }

        if(backbtncount==2f){
            OnQuitClick();
        }
        points.text = "SCORE " + point;
        if(Input.GetKeyDown(KeyCode.Escape)){
            Panel.SetActive(true);
            pausebtn.SetActive(false);
        }
        

    }
    public void OnGameOver(){
        gameover = true;
        counting = false;
        Time.timeScale = 2; // fastens time.
        FindObjectOfType<spawner>().OnMenaceMode(); // activates the quick spawning cars!
        StartCoroutine(WaitForGameOver());
        counting = false;
        gameovertxt.SetActive(true);
        if (PlayerPrefs.GetInt("Score", point) <= point)
        {
            Debug.Log("playerPref highscore called");
            PlayerPrefs.SetInt("Score", point); //saves the score into memory
        }
    /*    else
            return;*/

    }
    IEnumerator WaitForGameOver(){

        yield return new WaitForSecondsRealtime(8);
        Time.timeScale = 0;
        Panel.SetActive(true);
        gameovertxt.SetActive(false);
        Admanager.Instance.ShowBanner();
        admanager.ShowBanner();
    }

    public void OnMute()
    {
        AudioListener.volume = 0; // UI Section
        mute.SetActive(false);
        unmute.SetActive(true);
    }
    public void OnUnmute() // UI Section.
    {
        AudioListener.volume = 1;
        mute.SetActive(true);
        unmute.SetActive(false);
    }
    public void Counter()
    {
        if (counting)
        {
            // this is called by the barriers through pointCounter script!

            point += 50;
        }
        else return;
    }
    public void ONpause()
    {
       // pausebtn2.SetActive(false);
        pausebtn.SetActive(false);
        Panel.SetActive(true);
        gameovertxt.SetActive(false);
        if (gameover == true)
        {
            resumebtn.SetActive(false); // hides the resume when game is over when bool is true
        }

        else
        {
            resumebtn.SetActive(true); 
        }

        //===================================
        Time.timeScale = 0; //stops the time oof the game
    }


    public void OnLeaderBoardClick()
    {
        Panel.SetActive(false);
        pubnubmgr.SetActive(true);
        leaderboard.SetActive(true);
        //pausebtn2.SetActive(false);

    }
    public void OnLEaderBoarBAckCLick()
    {
        Time.timeScale = 1;
        if (gameover){
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
        pubnubmgr.SetActive(false);
        leaderboard.SetActive(false);
        pausebtn.SetActive(true);

        if(gameover){
            pausebtn.SetActive(false);
            //pausebtn2.SetActive(false);
        }
        //Time.timeScale = 1;
    }

    public void OnreSume()
    {
       
        pausebtn.SetActive(true);
        Time.timeScale = 1;
        Panel.SetActive(false);
        //pausebtn2.SetActive(false);
        Admanager.Instance.HideBanner();


    }
    public void OnRestart()
    {
        SceneManager.LoadScene("SampleScene"); //reloads the scene
        gameover = false;
        
    }
    public void OnQuitClick(){
        SceneManager.LoadSceneAsync("Menu");
        Admanager.Instance.ShowBanner();
        Admanager.Instance.ShowVideo();
    }
    IEnumerator resetter(){
        yield return new WaitForSecondsRealtime(.5f);
        backbtncount = 0;
    }

}
