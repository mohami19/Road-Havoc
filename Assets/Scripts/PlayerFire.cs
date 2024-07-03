using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireSpeed;
    [SerializeField] GameObject fireButton;

    void Update() {
        Fire();
    }
    public void Fire(){
        for (int i = 0; i < Input.touchCount; i++){
            if (Input.touches[i].phase == TouchPhase.Stationary || Input.touches[i].phase == TouchPhase.Moved) {
                Instantiate(bullet,transform.position,Quaternion.identity);
            }
        }
    }
}
