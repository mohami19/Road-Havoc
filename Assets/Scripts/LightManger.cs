using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManger : MonoBehaviour
{
    [SerializeField] Light2D rightLight;
    [SerializeField] Light2D leftLight;
    [SerializeField] Light2D gameLight;
    [SerializeField] Light2D sun;
    private readonly float minGameLight = 0;
    private readonly float maxCarLight = 2;
    private bool changeSun = true;
    private float speedMultiplier = 0;
    private float sunMultiplier = 0;
    private void Start() {
        sun.enabled = true;
        gameLight.intensity = 1;
        rightLight.intensity = 0;
        leftLight.intensity = 0;
        sun.intensity = 0;
    } 
    private void Update() {
        speedMultiplier += Time.deltaTime * 0.0000009f;
        if (gameLight.intensity > 0.5f) {   
            sunMultiplier += Time.deltaTime * 0.0000009f;
        } else {
            sunMultiplier -= Time.deltaTime * 0.0000009f;
        }
        if (gameLight.intensity > minGameLight && rightLight.intensity <= maxCarLight){
            gameLight.intensity -= speedMultiplier;
            leftLight.intensity += speedMultiplier * 2;
            rightLight.intensity += speedMultiplier * 2 ;
            sun.intensity += sunMultiplier * 200;
            if (gameLight.intensity < 0.5f && changeSun) {
                changeSun = false;
                sunMultiplier = -sunMultiplier;   
            }
        }
    }
}
