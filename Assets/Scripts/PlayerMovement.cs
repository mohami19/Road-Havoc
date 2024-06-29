using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 20f;
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip turnRightAnimationClip;
    [SerializeField] private AnimationClip turnLeftAnimationClip;
    private int turnRightAnimationId;
    private int turnLeftAnimationId;


    private Vector3 startPosition;
    private Vector3 endPosition;
    private float suddenMovementThreshold = 0.5f;
    private float rightLimit = 10f;
    private float leftLimit = -10f;
    private Vector3 movement = new Vector3(4, 0, 0);

    
    private void Awake() {
        turnRightAnimationId = Animator.StringToHash("TurnRight");
        turnLeftAnimationId = Animator.StringToHash("TurnLeft");
    }


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
                    StartCoroutine(TurnLeft()); 
                }
                if (distance.x < -suddenMovementThreshold && transform.position.x - 2 > leftLimit) {
                    StartCoroutine(TurnRight()); 
                }
            }
        }
    }

    private IEnumerator TurnRight(){
        // Play the turn animation
        animator.Play(turnRightAnimationId);

        // Capture the starting position
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition - movement;

        // Interpolate the position over the duration of the animation
        float duration = turnRightAnimationClip.length / animator.speed;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        transform.position = targetPosition;
    }

    private IEnumerator TurnLeft(){
        // Play the turn animation
        animator.Play(turnLeftAnimationId);

        // Capture the starting position
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + movement;

        // Interpolate the position over the duration of the animation
        float duration = turnLeftAnimationClip.length / animator.speed;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        transform.position = targetPosition;
    }
}
