using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 100f;
    public float distance = 10f;

    private float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -80f, 80f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        transform.position = playerTransform.position - transform.forward * distance;
    }
}
