using UnityEngine;

public class AdjustRoadSize : MonoBehaviour
{
    private Transform roadTransform;

    void Start()
    {
        roadTransform = transform;
        AdjustRoad();
    }

    void AdjustRoad()
    {
        float aspectRatio = (float)Screen.height / Screen.width;
        if (aspectRatio > 1.5f) {
            roadTransform.localScale = new Vector3(roadTransform.localScale.x * 1.1f, roadTransform.localScale.y, roadTransform.localScale.z);
        } else {
            roadTransform.localScale = new Vector3(roadTransform.localScale.x, roadTransform.localScale.y, roadTransform.localScale.z);
        }
    }
}
