using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private int health = 4;
    [SerializeField] private ParticleSystem hitEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet" && health <= 0){
            //hitEffect.Play();
            gameObject.SetActive(false);
        } else {
            health -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Bullet"){
            other.gameObject.SetActive(false);
        }
    }
        
}
