using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns = 5f;
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
            Instantiate(obstacles[randObstacle],spawnPoints[randPoint].transform.position,Quaternion.identity);
        }
    }
}
