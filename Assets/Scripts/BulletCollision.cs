using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
    private int obstacleHealth;
    [SerializeField] private ParticleSystem hitEffect;
    private float destroyPlyerDelay = 0.1f;

    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<ObstacleHealthBarController>().Health;
        if (other.tag == "Bullet" && obstacleHealth <= 1){
            hitEffect.Play();
            Invoke("DestroyPlayer",destroyPlyerDelay);
        } else {
            gameObject.GetComponent<ObstacleHealthBarController>().Health -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Bullet"){
            other.gameObject.SetActive(false);
        }
    }
    
    void DestroyPlayer(){
        gameObject.SetActive(false);
    }
        
}
