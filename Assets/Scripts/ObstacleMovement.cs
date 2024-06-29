using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rd.velocity = Vector2.down * moveSpeed;
        //rigidbody.velocity = Vector2.left * moveSpeed * Time.deltaTime;
    }
}
