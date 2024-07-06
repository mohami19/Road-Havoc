using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private float _speedMultiplier = 3f;


    public float SpeedMultiplier
    {
        get { return _speedMultiplier; }
        set 
        { 
            _speedMultiplier = value; 
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _speedMultiplier += Time.deltaTime * 0.4f;

        timer += Time.deltaTime;
        
        if (timer > timeBetweenSpawns) {
            timer = 0;
            RandomSpawn();
            //Invoke("RandomSpawn",0.05f);
            //Invoke("RandomSpawn",0.1f);
        }
    }

    void RandomSpawn(){
        int randPoint = Random.Range(0,spawnPoints.Length);
        int randObstacle = Random.Range(0,obstacles.Length);
        Instantiate(obstacles[randObstacle],spawnPoints[randPoint].transform.position,Quaternion.identity);
    }
}
