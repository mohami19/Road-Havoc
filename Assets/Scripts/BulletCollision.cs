using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Obstacle"){
            //hitEffect.Play();
            other.gameObject.SetActive(false);
        }
    }
        
}
