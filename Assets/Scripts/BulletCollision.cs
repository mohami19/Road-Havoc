using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    //[SerializeField] private Canvas canvas;
    private float destroyObstacleDelay = 0.6f;
    private int obstacleHealth;
    [SerializeField] private GameObject[] awards;

    private void Update() {
        obstacleHealth = gameObject.GetComponent<ObstacleHealthBarController>().Health;
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<ObstacleHealthBarController>().Health;
        if (other.tag == "Bullet"){
            gameObject.GetComponent<ObstacleHealthBarController>().Health -= 1;
            if (obstacleHealth <= 1 ){
                DestroyEnemy();
            }
            other.gameObject.SetActive(false);
        }
    }
    
    void DestroyEnemy(){
        hitEffect.Play();
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(awards[Random.Range(0,awards.Length)],transform.position,Quaternion.identity);
        Invoke(nameof(DestroyObstacle), destroyObstacleDelay);
    }

    void DestroyObstacle(){
        gameObject.SetActive(false);
    }
        
}
