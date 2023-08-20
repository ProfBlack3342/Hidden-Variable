using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 150f;
    [SerializeField] private float moveDeceleration = 50f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float maxTorque = 100f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        horizontalInput = 0;
        verticalInput = 0;
        mouseX = 0;
    }
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetButton("up"))
        {
            // Input.GetAxis("Vertical")
        }
        if (Input.GetButton("right"))
        {
            // Input.GetAxis("Horizontal")
        }
        if (Input.GetButton("left"))
        {
            // Input.GetAxis("Horizontal")
        }
        if (Input.GetButton("down"))
        {
            // Input.GetAxis("Vertical")
        }
    }

    private void RotatePlayer()
    {
        if(Input.GetAxis("MouseX") > 0)
        {

        }
        if (Input.GetAxis("MouseX") < 0)
        {

        }
        if (Input.GetAxis("MouseY") > 0)
        {

        }
        if (Input.GetAxis("MouseY") < 0)
        {

        }
    }
}
