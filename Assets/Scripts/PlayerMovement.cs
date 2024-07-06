using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip turnRightAnimationClip;
    [SerializeField] private AnimationClip turnLeftAnimationClip;
    private int turnRightAnimationId;
    private int turnLeftAnimationId;

    [Header("Score Management")]
    [SerializeField] TextMeshProUGUI scoreText;
    private float score = 0;


    [SerializeField] private float moveSpeed = 20f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float suddenMovementThreshold = 0.5f;
    private float rightLimit = 4f;
    private float leftLimit = -4f;
    private Vector3 movement = new Vector3(3, 0, 0);

    private void Awake() {
        turnRightAnimationId = Animator.StringToHash("TurnRight");
        turnLeftAnimationId = Animator.StringToHash("TurnLeft");
        animator.speed = animator.speed * 2.5f;
    }


    // Update is called once per frame
    void Update() {
        score += Time.deltaTime * Time.timeScale * 2;
        scoreText.text =  Mathf.RoundToInt(score).ToString();

        MovementWitHoldInputSystem();
    }

    private void SuddenMovement()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began) {
                startPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            }
            if (Input.touches[i].phase == TouchPhase.Ended) {
                endPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
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

    private void MovementWitHoldInputSystem() {
        for (int i = 0; i < Input.touchCount; i++) {
            
            Time.timeScale = 1f;
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            touchPosition.z = 0;

            Vector3 direction = (touchPosition - transform.position).normalized;

            float distance = Vector3.Distance(touchPosition, transform.position);
            Vector3 movement = direction * moveSpeed * Time.deltaTime;
            
            if (movement.magnitude > distance) {
                movement = direction * distance ;
            }
            movement.y = 0;
            transform.position += movement;
            
            if (Input.touches[i].phase == TouchPhase.Ended) {
                Time.timeScale = 0.15f;
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
        float duration = turnRightAnimationClip.length /( animator.speed * 3);
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
        float duration = turnLeftAnimationClip.length / ( animator.speed * 3);
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
