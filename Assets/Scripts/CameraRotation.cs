using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;      // The target to follow (player character)
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Camera offset from the target
    public float rotationSpeed = 5f;

    private void Update()
    {
        if (target == null)
            return;

        // Calculate the desired position and rotation of the camera
        Vector3 desiredPosition = target.position + offset;
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        // Smoothly move the camera towards the desired position and rotation
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
