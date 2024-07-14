using UnityEngine;

public class AdjustRoadSize : MonoBehaviour
{
    public Transform roadTransform;

    void Start()
    {
        roadTransform = transform;
        AdjustRoad();
    }

    void AdjustRoad()
    {
        Debug.Log("Width : " + Screen.width);
        Debug.Log("Heigh : " + Screen.height);
        float aspectRatio = (float)Screen.height / Screen.width;
        Debug.Log("Aspect Ratio : " + aspectRatio);
        
        if (aspectRatio > 1.5f) {
            roadTransform.localScale = new Vector3(roadTransform.localScale.x * 1.1f, roadTransform.localScale.y, roadTransform.localScale.z);
        } else {
            roadTransform.localScale = new Vector3(roadTransform.localScale.x, roadTransform.localScale.y, roadTransform.localScale.z);
        }
    }
}
