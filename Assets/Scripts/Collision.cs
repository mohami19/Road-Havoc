using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyPlyerDelay = 0.6f;
    [SerializeField] private ParticleSystem hitEffect;
    private int obstacleHealth;
    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<PlayerManage>().Health;
        if (other.tag == "Obstacle"){
            gameObject.GetComponent<PlayerManage>().Health -= 1;
            other.gameObject.SetActive(false);
        } 
        if(obstacleHealth <= 0){
            hitEffect.Play();
            Invoke("DestroyPlayer",destroyPlyerDelay);
        }
    }

    void DestroyPlayer(){
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
