using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [Header("References")]

    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform cameraTransform;

    [Header("General Variables")]

    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float mouseSensitivity;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private Vector3 velocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        applyGravity();
        cameraMovement();
        playerMovement();
    }

    void playerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * x) + (transform.forward * z);

        controller.Move(movement * movementSpeed * Time.deltaTime);
    }

    void cameraMovement()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        this.transform.Rotate(Vector3.up * mouseX);
    }

    void applyGravity()
    {
        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
