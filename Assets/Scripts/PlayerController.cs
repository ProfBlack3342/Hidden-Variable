using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 150f;
    [SerializeField] private float moveDeceleration = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float maxTorque = 1000f;

    private Rigidbody rb;
    private Quaternion targetRotation;
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = rb.rotation;
        horizontalInput = 0;
        verticalInput = 0;
        mouseX = 0;
    }
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        // Read player input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Read mouse movement for rotation
        mouseX = Input.GetAxis("Mouse X");

        MovePlayer(horizontalInput, verticalInput);
        RotatePlayer(mouseX);
    }

    private void MovePlayer(float horizontalInput, float verticalInput)
    {
        if (Mathf.Abs(horizontalInput) <= 1 && Mathf.Abs(verticalInput) <= 1)
        {
            // Calculate movement direction
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            // Calculate move force
            Vector3 moveForce = movementDirection * moveSpeed;
            // Apply force to the rigidbody
            rb.AddForce(moveForce, ForceMode.Force);
            // Apply opposing force for deceleration
            rb.AddForce(-rb.velocity * moveDeceleration, ForceMode.Force);
        }
    }

    private void RotatePlayer(float mouseX)
    {
        if (Mathf.Abs(mouseX) <= 1)
        {
            // Calculate target rotation based on mouse movement
            targetRotation *= Quaternion.Euler(Vector3.up * mouseX * rotationSpeed * Time.fixedDeltaTime);
            // Interpolate rotation gradually
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime);
            // Apply torque force to reach the new rotation
            rb.AddTorque(CalculateTorque(rb.rotation, newRotation) * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
    private Vector3 CalculateTorque(Quaternion fromRotation, Quaternion toRotation)
    {
        Quaternion deltaRotation = toRotation * Quaternion.Inverse(fromRotation);
        float angle;
        Vector3 axis;
        deltaRotation.ToAngleAxis(out angle, out axis);

        // Ensure torque magnitude is within the maxTorque limit
        float torqueMagnitude = Mathf.Min(maxTorque, angle * Mathf.Deg2Rad);
        return torqueMagnitude * axis;
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {

    }
}
