using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns) {

            timer = 0;
            int randPoint = Random.Range(0,spawnPoints.Length);
            int randObstacle = Random.Range(0,obstacles.Length);
            Debug.Log("The Obstacle number " + randObstacle + " spawned at the " + randPoint);
            Instantiate(obstacles[randObstacle],spawnPoints[randPoint].transform.position,Quaternion.identity);
        }
    }
}
