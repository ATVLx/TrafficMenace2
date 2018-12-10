using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class scnemgr : MonoBehaviour {


    public PostProcessingProfile ppProfile;
    public Gamesettings gamesettings;
    public GameObject playbtn;
    public GameObject optionsbtn;
    public GameObject Quitbtn;
    //public GameObject pausebtn;
    public GameObject backbtn;
    public GameObject displaytext;
    public GameObject dropdown1;
    public GameObject mute;
    public GameObject unmute;
    public GameObject dropdown;
    public GameObject slidergraphics;
    public GameObject slidergraphics1;
    public GameObject toggle;
    public AudioSource penclick;
    public AudioSource tickSound;
    public GameObject LoadingSlider;
    public Slider loadingslid;
    public float prog;
    public GameObject pubnubmgr;
    public Text HighScore;
    public GameObject highscoreobj;
    public GameObject leaderboardbtn;
    public GameObject emailinput;
    public GameObject howtoplaybtn;
    public GameObject howtoPlayPanel;



    //=======  declared variables======================================//






    void onEnable()
    {
        gamesettings = new Gamesettings();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        LoadingSlider.SetActive(false);
        playbtn.SetActive(true);
        Quitbtn.SetActive(true);
        optionsbtn.SetActive(true);
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("Score");

    }


    public void HowToPLay(){
        tickSound.Play();//plays tick voice
        playbtn.SetActive(false);
        Quitbtn.SetActive(false);
        optionsbtn.SetActive(false);
        howtoplaybtn.SetActive(false);
        howtoPlayPanel.SetActive(true);
        leaderboardbtn.SetActive(false);
        emailinput.SetActive(false);
        // function here =====================//

    }
    public void HowToPlayBaCKBTN(){
        playbtn.SetActive(true);
        Quitbtn.SetActive(true);
        optionsbtn.SetActive(true);
        howtoPlayPanel.SetActive(false);
        howtoplaybtn.SetActive(true);
        leaderboardbtn.SetActive(true);
        emailinput.SetActive(true);

    }


    IEnumerator LoadSceneASync()
    {
        LoadingSlider.SetActive(true);
        playbtn.SetActive(false);
        Quitbtn.SetActive(false);
        optionsbtn.SetActive(false);
        howtoplaybtn.SetActive(false);
        leaderboardbtn.SetActive(false);
        emailinput.SetActive(false);
        

        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");

        while (operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            prog = progress;
            loadingslid.value = progress;
            Debug.Log("Progress: " + progress);
            loadingslid.value = progress;

            yield return null;
        }
    }



    public void OnTextureChange(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void OnPlayCLick(){
        tickSound.Play();
        // AsyncOperation operation =  SceneManager.LoadSceneAsync("SampleScene");
        // SceneManager.LoadSceneAsync("SampleScene");
        StartCoroutine(LoadSceneASync());

    }

    public void OnbackPubnubClick(){
        tickSound.Play();   pubnubmgr.SetActive(false);
        playbtn.SetActive(true);    Quitbtn.SetActive(true);    
        optionsbtn.SetActive(true);     emailinput.SetActive(true);
        leaderboardbtn.SetActive(true);

    }

    public void OnleaderBOardsClick(){
        penclick.Play();
        pubnubmgr.SetActive(true);
        playbtn.SetActive(false);
        Quitbtn.SetActive(false);
        optionsbtn.SetActive(false);
        emailinput.SetActive(false);
        leaderboardbtn.SetActive(false);
        howtoplaybtn.SetActive(false);

    }

    public void onOptionsClick(){
        tickSound.Play();
        playbtn.SetActive(false);
        Quitbtn.SetActive(false);
        optionsbtn.SetActive(false);
        displaytext.SetActive(false);
        dropdown.SetActive(true);
        backbtn.SetActive(true);
        slidergraphics.SetActive(true);
        slidergraphics1.SetActive(true);
        toggle.SetActive(true);
        mute.SetActive(true);
        leaderboardbtn.SetActive(false);
        emailinput.SetActive(false);
        howtoplaybtn.SetActive(false);


    }
    public void OnQuitClick(){
        tickSound.Play();
        Application.Quit();

    }
    public void OnoptionsBackClick(){
        tickSound.Play();
        playbtn.SetActive(true);
        Quitbtn.SetActive(true);
        optionsbtn.SetActive(true);
        displaytext.SetActive(true);
        dropdown.SetActive(false);
        backbtn.SetActive(false);
        slidergraphics.SetActive(false);
        slidergraphics1.SetActive(false);
        toggle.SetActive(false);
        mute.SetActive(false);
        unmute.SetActive(false);
        leaderboardbtn.SetActive(true);
        emailinput.SetActive(true);
        howtoplaybtn.SetActive(true);


    }
    public void OnMuteClick(){
        tickSound.Play();
        mute.SetActive(false);
        unmute.SetActive(true);
        AudioListener.volume = 0;

    }
    public void OnUnmuteClick(){
        tickSound.Play();
        mute.SetActive(true);
        unmute.SetActive(false);
        AudioListener.volume = 1;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        loadingslid.value = prog;
    }



    //=====================Post Processing stack=========================//




    public void SetBloom(float intensity)
    {
        tickSound.Play();
        //Debug.Log("intensity: " + intensity);
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;
        bloomSettings.bloom.intensity = intensity * 10;
        ppProfile.bloom.settings = bloomSettings;
        AmbientOcclusionModel.Settings ABOCL = ppProfile.ambientOcclusion.settings;
        ABOCL.intensity = intensity;
    }
    public void toggleambientocl(float ambientoCL)
    {
        tickSound.Play();
        AmbientOcclusionModel.Settings ABOCL = ppProfile.ambientOcclusion.settings;
        // ABOCL.ambientOcclusion.intensity = ambientoCL;
        // VignetteModel.Settings bgn = ppProfile.vignette.settings;
        ABOCL.intensity = ambientoCL * 10;
        ppProfile.ambientOcclusion.settings = ABOCL;
    }
    public void onAntiailisingEffects(bool Ailising)
    {
        if (Ailising == true)
        {


            ppProfile.antialiasing.enabled = true;
            penclick.Play();
        }
        if (Ailising == false)
        {


            ppProfile.antialiasing.enabled = false;
            penclick.Play();
        }

    }


}
                                                                                                                                                                                                                                                                                                                                                                                                                    