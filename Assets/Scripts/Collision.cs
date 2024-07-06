using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyPlyerDelay = 0.6f;
    [SerializeField] private ParticleSystem hitEffect;
    private bool gotHit = true;
    private int obstacleHealth;
    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<PlayerManage>().Health;
        Debug.Log(gotHit);
        if (other.tag == "Obstacle" && gotHit){
            gameObject.GetComponent<PlayerManage>().Health -= 1;
            gotHit = false;
            Invoke("GotHit",3f);
            other.gameObject.SetActive(false);
        } else if (other.tag == "Obstacle") {
            other.gameObject.SetActive(false);
        }
        if(obstacleHealth <= 0){
            hitEffect.Play();
            Invoke("DestroyPlayer",destroyPlyerDelay);
        }
    }

    void GotHit(){
        gotHit = true;
    }

    void DestroyPlayer(){
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
