using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
