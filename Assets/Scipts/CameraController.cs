using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float smoothSpeed = 0.3f;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -21.3f, 58.3f),Mathf.Clamp(transform.position.y, -61.9f, 13.8f),transform.position.z);
         

    }
}
