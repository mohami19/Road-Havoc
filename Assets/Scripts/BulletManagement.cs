using UnityEngine;

public class BulletManagement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private float distanceToLive = 25f;
    private GameManager gm;
    private Rigidbody2D rd;
    private Vector2 _direction;

    public Vector2 Direction
    {
        get { return _direction; }
        set 
        { 
            _direction = value.normalized; 
        }
    }

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        gm =  FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        float speedMultiplier = gm.GetComponent<GameManager>().SpeedMultiplier;
        rd.velocity = Direction * (moveSpeed + speedMultiplier);
        DestroyObject();
    }
    void DestroyObject(){
        if (transform.position.y > distanceToLive) {
            gameObject.SetActive(false);
        }
    }
}
