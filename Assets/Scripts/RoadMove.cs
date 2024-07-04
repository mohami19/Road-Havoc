using UnityEngine;

public class roadMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 offset;

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
        _speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(0, Time.time * _speed);
        GetComponent<Renderer> ().material.mainTextureOffset = offset;
    }
}
