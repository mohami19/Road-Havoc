using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManger : MonoBehaviour
{
    [SerializeField] Light2D rightLight;
    [SerializeField] Light2D leftLight;
    [SerializeField] Light2D GameLight;
    private readonly float minGameLight = 0;
    private readonly float maxCarLight = 2;
    private float speedMultiplier = 0;
    private void Start() {
        GameLight.intensity = 1;
        rightLight.intensity = 0;
        leftLight.intensity = 0;
    } 
    private void Update() {
        speedMultiplier += Time.deltaTime * 0.0000005f;
        Debug.Log(GameLight.intensity);
        if (GameLight.intensity > minGameLight && rightLight.intensity <= maxCarLight){
            GameLight.intensity -= speedMultiplier;
            leftLight.intensity += speedMultiplier * 2;
            rightLight.intensity += speedMultiplier * 2 ;
        }
    }

}
