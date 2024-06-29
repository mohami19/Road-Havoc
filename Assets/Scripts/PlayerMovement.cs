using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 20f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float suddenMovementThreshold = 0.5f;
    private float rightLimit = 10f;
    private float leftLimit = -10f;




    // Update is called once per frame
    void Update() {
        SuddenMovement();
    }

    private void SuddenMovement()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began) {
                startPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                Debug.Log("Start Position is : " + startPosition);
            }
            if (Input.touches[i].phase == TouchPhase.Ended) {
                endPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                Debug.Log("End Position is : " + endPosition);
                Vector2 distance = endPosition - startPosition;
                if (distance.x > suddenMovementThreshold && transform.position.x + 2 < rightLimit) {
                    transform.position += new Vector3(4,0,0);
                }
                if (distance.x < -suddenMovementThreshold && transform.position.x - 2 > leftLimit) {
                    transform.position -= new Vector3(4,0,0);
                }
            }
        }
    }
}
