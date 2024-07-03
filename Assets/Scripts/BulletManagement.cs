using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private float distanceToLive = 40f;
    private GameManager gm;
    private Rigidbody2D rd;
    
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        gm =  FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        float speedMultiplier = gm.GetComponent<GameManager>().GetSpeedMultiplier();
        rd.velocity = Vector2.up * (moveSpeed + speedMultiplier);
        DestroyObject();
    }

    void DestroyObject(){
        if (transform.position.y > distanceToLive) {
            gameObject.SetActive(false);
        }
    }
}
