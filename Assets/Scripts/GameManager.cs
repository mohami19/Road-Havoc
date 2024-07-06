using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private float speedMultiplier = 3f;

    public float GetSpeedMultiplier(){
        return speedMultiplier;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime * 0.1f;

        timer += Time.deltaTime;
        
        if (timer > timeBetweenSpawns) {
            timer = 0;
            RandomSpawn();
            Invoke("RandomSpawn()",0.05f);
            Invoke("RandomSpawn()",0.1f);
        }
    }

    void RandomSpawn(){
        int randPoint = Random.Range(0,spawnPoints.Length);
        int randObstacle = Random.Range(0,obstacles.Length);
        Instantiate(obstacles[randObstacle],spawnPoints[randPoint].transform.position,Quaternion.Euler(0,0,180));
    }
}
