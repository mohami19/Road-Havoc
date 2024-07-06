using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private float distanceToLive = -10f;
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
        float speedMultiplier = gm.GetComponent<GameManager>().SpeedMultiplier;
        rd.velocity = Vector2.down * (moveSpeed + speedMultiplier);
        DestroyObject();
        //rigidbody.velocity = Vector2.left * moveSpeed * Time.deltaTime;
    }

    void DestroyObject(){
        if (transform.position.y < distanceToLive) {
            gameObject.SetActive(false);
        }
    }
}
