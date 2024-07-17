using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float comeDownTime = 0.4f;
    private float distanceToLive = -10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();    
        rb.velocity = new Vector2(0, 10);
    
    }

    // Update is called once per frame
    void Update() {
        Invoke(nameof(MoveDown), comeDownTime);
        DestroyObject();
    }

    void MoveDown(){
        rb.velocity = Vector2.down * moveSpeed;
    }
    void DestroyObject(){
        if (transform.position.y < distanceToLive) {
            gameObject.SetActive(false);
        }
    }
}
