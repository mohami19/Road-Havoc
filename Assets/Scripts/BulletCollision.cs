using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private Canvas canvas;
    private float destroyObstacleDelay = 0.6f;
    private int obstacleHealth;

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
        canvas.enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("DestroyObstacle",destroyObstacleDelay);
    }

    void DestroyObstacle(){
        gameObject.SetActive(false);
    }
        
}
