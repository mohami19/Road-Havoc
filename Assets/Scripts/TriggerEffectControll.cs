using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectControll : MonoBehaviour
{
    private int obstacleHealth;
    [SerializeField] private ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D other) {
        obstacleHealth = gameObject.GetComponent<ObstacleHealthBarController>().Health;
        if (other.tag == "Bullet" && obstacleHealth <= 1){
            effect.Play();
            //Invoke("DestroyPlayer",0.5f);
        } else {
            gameObject.GetComponent<ObstacleHealthBarController>().Health -= 1;
        }
    }

}
