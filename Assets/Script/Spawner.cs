using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeSpawn;
    public float startTime;
    public float decreaseTime;
    public float minTime;
    private int rand;
    private int points;
   /* private void Start()
    {
        
    }*/

    private void Update()
    {
        if (timeSpawn <= 0)
        {
            rand = Random.Range(0, obstaclePatterns.Length);
            /*rand += Random.Range(0,3)-1;
            rand = Mathf.Clamp(rand, 0, 2);*/
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeSpawn = startTime;
            if (startTime > minTime && ScoreManager.score > points)
            {
                startTime -= decreaseTime;
                points += 50;
            }

        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}
