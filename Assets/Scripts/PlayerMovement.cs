using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    // Update is called once per frame
    void Update() {
        for (int i = 0; i < Input.touchCount; i++) {
            if (Input.touches[i].phase != TouchPhase.Ended) {
                transform.position += new Vector3(0,moveSpeed*Time.deltaTime,0);
            } else {
                transform.position = new Vector3(0,0,0);
            }
        }
    }
}
