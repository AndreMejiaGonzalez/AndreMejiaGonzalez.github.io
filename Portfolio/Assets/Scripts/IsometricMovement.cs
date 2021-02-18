using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;

    private Rigidbody rb;
    private Vector3 forward, right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }

    void Update()
    {
        if(Input.anyKey)
        {
            movePlayer();
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    void movePlayer()
    {
        Vector3 rightMovement = right * moveSpeed * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Input.GetAxisRaw("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;

        rb.velocity = (rightMovement + upMovement);
    }
}
