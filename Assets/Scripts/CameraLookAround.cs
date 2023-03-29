using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour
{
    public float rotationX = 0f;
    public float rotationY = 0f;

    public float sensitivity = 10f;
    public float orbitDamping = 10f;

    public Transform target;
    public float radius = 5f;
    public float distance = 10f;
    public float rotationSpeed = 10f;

    public float maxVerticalAngle = 360f;
    public float minVerticalAngle = -360f;

    public float movementSmoothing = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //  transform.position = target.position;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * sensitivity;
        rotationX += mouseY * -1 * sensitivity;


        //rotationX = Mathf.Clamp(rotationY, 0f, 88f);

        Quaternion QT = Quaternion.Euler(rotationX, rotationY, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);

        // Move camera away from player based on radius
        Vector3 cameraTargetPosition = target.position - transform.forward * radius;

        // Rotate camera around player based on mouse movement
        transform.RotateAround(target.position, Vector3.up, mouseX * rotationSpeed);

        // Apply vertical limit to camera rotation
        float newAngle = transform.eulerAngles.x - mouseY * rotationSpeed;
        if (newAngle > maxVerticalAngle && newAngle < 180f)
            mouseY = (maxVerticalAngle - transform.eulerAngles.x) / -rotationSpeed;
        else if (newAngle < minVerticalAngle && newAngle > 180f)
            mouseY = (minVerticalAngle - transform.eulerAngles.x) / -rotationSpeed;
        transform.RotateAround(target.position, transform.right, -mouseY * rotationSpeed);

        // Move camera back to its position relative to the player
        //transform.position = cameraPosition;

        // Smooth camera movement towards target position
        // transform.position = Vector3.Lerp(transform.position - transform.forward, cameraTargetPosition, movementSmoothing);

        transform.position = target.position - transform.forward * distance;


        // transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        // transform.RotateAround(target.position, Vector3.up, orbitDamping * Time.deltaTime);

        //transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

    }
}
