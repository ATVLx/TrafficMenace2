using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;
using MiniJSON;
using SimpleJSON;

public class MyClass
{
    public string username;
    public string score;
    public string test;
}
public class PUNHUBManager : MonoBehaviour
{
    public string publishKey;
    public string subscribeKey;
    public static PubNub pubnub;
    public Text Line1;
    public Text Line2;
    public Text Line3;
    public Text Line4;
    public Text Line5;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5,log;
    public Button SubmitButton;
    public InputField FieldUsername;
    public InputField FieldScore;
    // Use this for initialization
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("EMAIL"));
        Debug.Log(PlayerPrefs.GetInt("Score"));
                  
        publishKey = "pub-c-ed03b041-dbd1-4421-af39-404baa9fdcce";
        subscribeKey = "sub-c-22588262-e977-11e8-8495-720743810c32";
        Button btn = SubmitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        // Use this for initialization
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = publishKey;
        pnConfiguration.SubscribeKey = subscribeKey;
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = Random.Range(0f, 999999f).ToString();
        pubnub = new PubNub(pnConfiguration);
        Debug.Log(pnConfiguration.UUID);

        MyClass myFireObject = new MyClass();
        myFireObject.test = "new user";
        string fireobject = JsonUtility.ToJson(myFireObject);
        pubnub.Fire()
          .Channel("LEaderBoardchannel")
          .Message(fireobject)
          .Async((result, status) => {
              if (status.Error)
              {
                  Debug.Log(status.Error);
                  Debug.Log(status.ErrorData.Info);
                  log.text = status.Error.ToString();
                    
              }
              else
              {
                  Debug.Log(string.Format("Fire Timetoken: {0}", result.Timetoken));
                  log.text = string.Format("Fire Timetoken: {0}", result.Timetoken);
              }
          }); pubnub.SusbcribeCallback += (sender, e) => {
              SusbcribeEventEventArgs mea = e as SusbcribeEventEventArgs;
              if (mea.Status != null)
              {
                  log.text = "called mea.status";
              }
              if (mea.MessageResult != null)
              {
                  log.text = "called mea.status";
                  Debug.Log("Entered in Mea.Subscribe");
                  Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;
                  string[] strArr = msg["username"] as string[];
                  string[] strScores = msg["score"] as string[];
                  int usernamevar = 1;
                  foreach (string username in strArr)
                  {
                      string usernameobject = "Line" + usernamevar;
                      GameObject.Find(usernameobject).GetComponent<Text>().text = usernamevar.ToString() + ". " + username.ToString();
                      usernamevar++;
                      Debug.Log(username);
                      log.text = "username: " + username + "";
                  }
                  int scorevar = 1;
                  foreach (string score in strScores)
                  {
                      string scoreobject = "Score" + scorevar;
                      GameObject.Find(scoreobject).GetComponent<Text>().text = "Score: " + score.ToString();
                      scorevar++;
                      Debug.Log(score);
                      log.text = "score: " + score + "";
                  }
              }
              if (mea.PresenceEventResult != null)
              {
                  Debug.Log("In Example, SusbcribeCallback in presence" + mea.PresenceEventResult.Channel + mea.PresenceEventResult.Occupancy + mea.PresenceEventResult.Event);
              }
          };
        pubnub.Subscribe()
          .Channels(new List<string>() {
        "LEaderBoardchannel"
          })
          .WithPresence()
          .Execute();


    }

    public void Onsubscribe(){
        pubnub.SusbcribeCallback += (sender, e) => {
            SusbcribeEventEventArgs mea = e as SusbcribeEventEventArgs;
            if (mea.Status != null)
            {
                log.text="called mea.status";
            }
            if (mea.MessageResult != null)
            {
                log.text = "called mea.status";
                Debug.Log("Entered in Mea.Subscribe");
                Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;
                string[] strArr = msg["username"] as string[];
                string[] strScores = msg["score"] as string[];
                int usernamevar = 1;
                foreach (string username in strArr)
                {
                    string usernameobject = "Line" + usernamevar;
                    GameObject.Find(usernameobject).GetComponent<Text>().text = usernamevar.ToString() + ". " + username.ToString();
                    usernamevar++;
                    Debug.Log(username);
                    log.text = "username: " + username + "";
                }
                int scorevar = 1;
                foreach (string score in strScores)
                {
                    string scoreobject = "Score" + scorevar;
                    GameObject.Find(scoreobject).GetComponent<Text>().text = "Score: " + score.ToString();
                    scorevar++;
                    Debug.Log(score);
                    log.text = "score: " + score + "";
                }
            }
            if (mea.PresenceEventResult != null)
            {
                Debug.Log("In Example, SusbcribeCallback in presence" + mea.PresenceEventResult.Channel + mea.PresenceEventResult.Occupancy + mea.PresenceEventResult.Event);
            }
        };
        pubnub.Subscribe()
          .Channels(new List<string>() {
        "LEaderBoardchannel"
          })
          .WithPresence()
          .Execute();
    }

    public void saveuserName(){
        string username = FieldUsername.text+"";
        PlayerPrefs.SetString("EMAIL", username);
        Debug.Log("stringusername:" + username);
        log.text = "EMail: " + PlayerPrefs.GetString("EMAIL") + "";
    }

   public void TaskOnClick()
    {
        Debug.Log(PlayerPrefs.GetString("EMAIL"));
        var usernametext = PlayerPrefs.GetString("EMAIL");// this would be set somewhere else in the code
        var scoretext = PlayerPrefs.GetInt("Score");
        MyClass myObject = new MyClass();
        myObject.username = PlayerPrefs.GetString("EMAIL");
        myObject.score = PlayerPrefs.GetInt("Score").ToString();
        string json = JsonUtility.ToJson(myObject);
        pubnub.Publish()
          .Channel("LEaderBoardchannel")
          .Message(json)
          .Async((result, status) => {
              if (!status.Error)
              {
                  Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                  log.text = string.Format("Publish Timetoken: {0}", result.Timetoken);
              }
              else
              {
                  Debug.Log(status.Error);
                  Debug.Log(status.ErrorData.Info);
              }
          });
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
    }
}