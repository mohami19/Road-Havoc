using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyPlyerDelay = 0.6f;
    [SerializeField] private ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Obstacle") {
            hitEffect.Play();
            Invoke("DestroyPlayer",destroyPlyerDelay);
        }
    }
    void DestroyPlayer(){
        gameObject.SetActive(false);
    }
}
