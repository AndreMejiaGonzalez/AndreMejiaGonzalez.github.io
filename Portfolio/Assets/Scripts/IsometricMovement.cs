using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    [SerializeField]
    private Transform model;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateRate;

    private Rigidbody rb;
    private Vector3 forward, right;
    private float heading;
    private float rotateTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        rotateTimer = rotateRate;
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            movePlayer();
            rotateTimer += Time.deltaTime;
            if(rotateTimer >= rotateRate)
            {
                rollForward();
                rotateTimer = 0;
            }
        } else {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rotateTimer = rotateRate;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rollForward();
        }
    }

    void movePlayer()
    {

        Vector3 rightMovement = right * moveSpeed * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        switch (direction.x, direction.y)
        {
            case (1, 0):
                heading = 135;
                break;
            case (-1,0):
                heading = -45;
                break;
            case (0,1):
                heading = 45;
                break;
            case (0,-1):
                heading = -135;
                break;
            case (1,1):
                heading = 90;
                break;
            case (1,-1):
                heading = -180;
                break;
            case (-1,1):
                heading = 0;
                break;
            case (-1,-1):
                heading = -90;
                break;
            default:
                break;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, heading, transform.rotation.eulerAngles.z);

        rb.velocity = (rightMovement + upMovement);
    }

    void rollForward()
    {
        model.Rotate(new Vector3(-90,0,0), Space.Self);
        model.localPosition = (model.localRotation.eulerAngles.x == 90) ? new Vector3(model.localPosition.x, 2, model.localPosition.z) : Vector3.zero;
    }
}
