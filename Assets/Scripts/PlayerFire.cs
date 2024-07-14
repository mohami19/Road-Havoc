using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireSpeed;
    [SerializeField] GameObject fireButton;

    [SerializeField] private float timer = 0.8f;
    [SerializeField] private float timeBetweenSpawns = 1f;
    private float straightDirection = 90;
    private float rightDiagonalDirection = 85;
    private float leftDiagonalDirection = 95;

    void Update() {
        Fire();
    }
    public void Fire(){
        for (int i = 0; i < Input.touchCount; i++){
            if (Input.touches[i].phase == TouchPhase.Stationary || Input.touches[i].phase == TouchPhase.Moved) {
                timer += Time.deltaTime;
                if (timer > timeBetweenSpawns) {
                    timer = 0;
                    SpawnBullet(straightDirection);
                    //SpawnBullet(rightDiagonalDirection);
                    //SpawnBullet(leftDiagonalDirection);
                }
            }
        }
    }

    void SpawnBullet(float degree){
        Vector3 spawnPosition = transform.position + new Vector3(0,1,0);
        Vector2 direction = new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));        
        
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.Euler(0,0,90));
        
        BulletManagement bulletManagement = newBullet.GetComponent<BulletManagement>();
        bulletManagement.Direction = direction;
    }
}
