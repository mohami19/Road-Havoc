using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManger : MonoBehaviour
{
    #region Lights
    [SerializeField] Light2D rightLight;
    [SerializeField] Light2D leftLight;
    [SerializeField] Light2D gameLight;
    [SerializeField] Light2D sun;
    #endregion

    #region Max and Min Light 
    private readonly float minGameLight = 0;
    private readonly float maxGameLight = 1;
    private readonly float maxCarLight = 2;
    private readonly float minCarLight = 0;
    #endregion

    #region Time Setting
    private readonly float nightTime = 50f;
    private bool isNight = false;
    [SerializeField] private float timer = 0.8f;
    private readonly float timeMultiplier = 0.0000009f; // the real constant is : 0.0000009f
    private bool changeSun = true;
    private float speedMultiplier = 0;
    private float sunMultiplier = 0;
    #endregion

    private void Start() {
        sun.enabled = true;
        gameLight.intensity = 1;
        rightLight.intensity = 0;
        leftLight.intensity = 0;
        sun.intensity = 0;
    } 
    private void Update() {
        if (!isNight){    
            speedMultiplier += Time.deltaTime * timeMultiplier * Time.timeScale; 
            if (gameLight.intensity > 0.5f) {   
                sunMultiplier += Time.deltaTime * timeMultiplier * Time.timeScale;
            } else {
                sunMultiplier -= Time.deltaTime * timeMultiplier * Time.timeScale;
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
            } else {
                timer += Time.deltaTime;
            }
        } else {
            speedMultiplier += Time.deltaTime * timeMultiplier * Time.timeScale;
            if (gameLight.intensity > 0.3f) {   
                Debug.Log("Decreeing");
                sunMultiplier -= Time.deltaTime * timeMultiplier * Time.timeScale;
            } else {
                Debug.Log("Adding");
                sunMultiplier += Time.deltaTime * timeMultiplier * Time.timeScale;
            }
            if (gameLight.intensity < maxGameLight && rightLight.intensity >= minCarLight){
                gameLight.intensity += speedMultiplier;
                leftLight.intensity -= speedMultiplier * 2;
                rightLight.intensity -= speedMultiplier * 2 ;
                sun.intensity += sunMultiplier * 100;
                if (gameLight.intensity > 0.5f && !changeSun) {
                    changeSun = true;
                    sunMultiplier = -sunMultiplier;   
                }
            } else {
                timer += Time.deltaTime;
            }
        }

        if (timer > nightTime){
            speedMultiplier = 0;
            sunMultiplier = 0;
            timer = 0;
            isNight = !isNight;
        }
    }
}
