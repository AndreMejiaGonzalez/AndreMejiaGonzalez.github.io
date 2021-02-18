using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public float maxSpeed;

    void Update()
    {
        // this.transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, 0, target.position.y) + offset,
        // ref velocity, smoothTime, maxSpeed);

        this.transform.position = new Vector3(target.position.x, 0, target.position.z) + offset;
    }
}
