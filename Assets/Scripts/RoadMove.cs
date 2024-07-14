using UnityEngine;

public class roadMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 offset;
    private float speedMultiplier = 0.2f;

    public float Speed
    {
        get { return _speed; }
        set 
        { 
            _speed = value; 
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(0, Time.time * (_speed + speedMultiplier));
        GetComponent<Renderer> ().material.mainTextureOffset = offset;
    }
}
