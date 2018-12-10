using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{


    public Transform[] SpawnPoints;
    //public GameObject Prefab;
    public float levelincreaseseconds = 15f;
    public float timetoSpawnAtFirst = 2;
    public float IntervalsbetweenWave = 5;
    public GameObject[] cars;
    bool awake = false;
	// Use this for initialization
	void Start () {
        awake = true;
        StartCoroutine(DecreaseOverTime());
	}


    private void Update()
    {
        if (awake)
        {
            if (Time.timeSinceLevelLoad >= timetoSpawnAtFirst)
            {
                spawnblock();
                timetoSpawnAtFirst = Time.timeSinceLevelLoad + IntervalsbetweenWave;
            }
        }
    }

    void spawnblock(){
        int j = Random.Range(0, cars.Length);
        int randomIndex = Random.Range(0, SpawnPoints.Length);
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(cars[j], SpawnPoints[i].position, Quaternion.identity);
            }
        }
        for (int x = 0; x < SpawnPoints.Length; x++)
        {

        }
    }
    public void OnMenaceMode()
    {
        IntervalsbetweenWave = 2f;
    }
	// Update is called once per frame
    IEnumerator DecreaseOverTime(){
        yield return new WaitForSecondsRealtime(levelincreaseseconds);
        if (IntervalsbetweenWave <= 4)
        {
            IntervalsbetweenWave = 4;
            yield return null;
            
        }
        else
        {
            IntervalsbetweenWave -= 1f;
            StartCoroutine(DecreaseOverTime());
        }
    }
}
