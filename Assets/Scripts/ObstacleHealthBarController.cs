using UnityEngine;
using UnityEngine.UI;

public class ObstacleHealthBarController : MonoBehaviour
{
    private int maxHealth = 3;
    private int _health;
    [SerializeField] Slider progressBar; 


    public int Health
    {
        get { return _health; }
        set 
        { 
            _health = value; 
        }
    }
    void Start()
    {
        _health = maxHealth;
        progressBar.maxValue = maxHealth;
        progressBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = _health;
    }
}
