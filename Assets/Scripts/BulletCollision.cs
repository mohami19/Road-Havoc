using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private int obstacleHealth;
    [SerializeField] private ParticleSystem hitEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<ObstacleHealthBarController>().Health;
        if (other.tag == "Bullet" && obstacleHealth <= 1){
            //hitEffect.Play();
            gameObject.SetActive(false);
        } else {
            gameObject.GetComponent<ObstacleHealthBarController>().Health -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Bullet"){
            other.gameObject.SetActive(false);
        }
    }
        
}
