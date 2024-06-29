using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private GameManager gm;
    private Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        gm =  FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedMultiplier = gm.GetComponent<GameManager>().GetSpeedMultiplier();
        rd.velocity = Vector2.down * (moveSpeed + speedMultiplier);
        //rigidbody.velocity = Vector2.left * moveSpeed * Time.deltaTime;
    }
}
