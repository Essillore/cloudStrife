using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2LookAround : MonoBehaviour
{
    public Transform target;

    public float rotationX = 0f;
    public float rotationY = 0f;

    public float sensitivity = 10f;
    public float orbitDamping = 10f;

    // Define the distance from the airship for the camera to rotate around
    public float distanceFromAirship = 20.0f;

    // Define the constant height of the camera relative to the airship
    public float cameraHeight = 2.0f;

    public float movementSmoothing = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * sensitivity;
        rotationX += mouseY * -1 * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -50f, 50f);

        // Calculate the position of the camera in a circular motion around the airship
        Vector3 cameraPosition = new Vector3(
        distanceFromAirship * -Mathf.Sin(rotationY * Mathf.Deg2Rad) * Mathf.Cos(rotationX * Mathf.Deg2Rad),
        cameraHeight,
        distanceFromAirship * -Mathf.Cos(rotationY * Mathf.Deg2Rad) * Mathf.Cos(rotationX * Mathf.Deg2Rad)
        );

        // Update the position of the camera relative to the airship
       // transform.position = target.transform.position + cameraPosition;

        // Smooth camera movement towards target position
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraPosition, movementSmoothing);

        Quaternion QT = Quaternion.Euler(rotationX, rotationY, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
    }
}